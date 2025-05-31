﻿using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Domir.Client.Core.Exceptions;
using Domir.Client.Core.UI.Contract;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Core.UI.Navigation
{
    public sealed class UINavigation : IUINavigation
    {
        private readonly IUINavigationNodePool _navigationNodePool;
        private readonly IUIManager _uiManager;
        private readonly Stack<IUINavigationNode> _stackNodes = new();
        private readonly HashSet<IUINavigationNode> _staticNodes = new();
        private readonly HashSet<IUINavigationNode> _systemNodes = new();
        private bool _isDisposed;

        public UINavigation(IUINavigationNodePool navigationNodePool, IUIManager uiManager)
        {
            _navigationNodePool = navigationNodePool;
            _uiManager = uiManager;
            foreach (var id in _uiManager.GetStaticUI())
            {
                var node = _navigationNodePool.Get(id);
                _staticNodes.Add(node);
            }
        }

        public async UniTask ApplyUILayer(UILayer layer, bool immediately = false)
        {
            try
            {
                var tasks = new List<UniTask>();
                foreach (var node in _staticNodes)
                {
                    var presenter = _uiManager.Get<IStaticUIPresenter>(node.Id);
                    tasks.Add(presenter.HasLayer(layer)
                        ? ShowPresenterAsync(presenter, node, UIParam.Empty, immediately)
                        : HidePresenterAsync(presenter, node, UIResult.Close, immediately));
                }

                await UniTask.WhenAll(tasks);
            }
            catch (InitializationFailedException)
            {
                foreach (var node in _staticNodes)
                {
                    _uiManager.Remove(node.Id);
                }
            }
        }

        public async UniTask<IUIHandle> ShowStackUIAsync(UIId id, UIParam payload = null, bool immediately = false)
        {
            try
            {
                if (_stackNodes.Any(x => x.Id == id))
                {
                    throw new AlreadyOpenedException();
                }

                var node = _navigationNodePool.Get(id);
                var presenter = _uiManager.Get<IStackUIPresenter>(id);
                var uiHandle = await ShowPresenterAsync(presenter, node, payload, immediately);
                _stackNodes.Push(node);
                return uiHandle;
            }
            catch (InitializationFailedException)
            {
                _uiManager.Remove(id);
            }
            catch (AlreadyOpenedException)
            {
                return UIHandle.Error;
            }

            return UIHandle.Error;
        }

        public async UniTask<IUIHandle> ShowSystemUIAsync(UIId id, UIParam payload = null, bool immediately = false)
        {
            try
            {
                var node = _systemNodes.FirstOrDefault(x => x.Id == id);
                if (node == null)
                {
                    node = _navigationNodePool.Get(id);
                    _systemNodes.Add(node);
                }

                var presenter = _uiManager.Get<ISystemUIPresenter>(id);
                return await ShowPresenterAsync(presenter, node, payload ?? UIParam.Empty, immediately);
            }
            catch (InitializationFailedException)
            {
                var node = _navigationNodePool.Get(id);
                _systemNodes.Remove(node);
                _uiManager.Remove(id);
            }

            return UIHandle.Error;
        }

        public async UniTask<bool> HideSystemUIAsync(UIId id, UIResult result, bool immediately = false)
        {
            var node = _systemNodes.FirstOrDefault(x => x.Id == id);
            if (node == null)
            {
                return false;
            }

            _systemNodes.Remove(node);

            var presenter = _uiManager.Get<ISystemUIPresenter>(id);
            await HidePresenterAsync(presenter, node, result, immediately);
            _navigationNodePool.Return(node);
            return true;
        }

        public async UniTask<bool> HideStackUIAsync(UIResult result, bool immediately = false)
        {
            if (!_stackNodes.TryPop(out var node))
            {
                return false;
            }

            var presenter = _uiManager.Get<IStackUIPresenter>(node.Id);
            await HidePresenterAsync(presenter, node, result, immediately);
            _navigationNodePool.Return(node);
            return true;
        }

        private async UniTask<IUIHandle> ShowPresenterAsync(
            IUIPresenter presenter,
            IUINavigationNode node,
            UIParam payload,
            bool immediately)
        {
            node.Reset(node.Id);
            presenter.Activate(0);
            await presenter.InitializeAsync(node.Token);
            presenter.OnShowEnter();
            await presenter.ShowAsync(node.Token, payload, immediately);
            presenter.OnShowExit();
            return node.Opened();
        }

        private async UniTask HidePresenterAsync(
            IUIPresenter presenter,
            IUINavigationNode node,
            UIResult result,
            bool immediately)
        {
            presenter.OnHideEnter();
            await presenter.HideAsync(node.Token, immediately);
            presenter.OnHideExit();
            node.Closed(result);
        }
    }
}