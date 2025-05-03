using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;
using Domir.Client.Common.UI.Core.Presenter;
using Domir.Client.Exceptions;

namespace Domir.Client.Common.UI.Implementation
{
    public class UINavigation : IUINavigation
    {
        private readonly IUINavigationNodePool _navigationNodePool = new UINavigationNodePool();
        private readonly IUIManager _iuiManager;
        private readonly HashSet<IUINavigationNode> _nodes = new();
        private bool _isDisposed;
        
        public bool IsOpened { get; }
        
        public UINavigation(IUIManager iuiManager)
        {
            _iuiManager = iuiManager;
        }
        
        public async UniTask<UIShowResult> ShowAsync(UIId id, UIParam payload = null, bool immediately = false)
        {
            var node = Open(id);
            var presenter = _iuiManager.Get<ISystemUIPresenter>(id);
            try
            {
                presenter.Activate(0);
                await presenter.InitializeAsync(node.Token);
                // Sort();
                presenter.OnShowEnter();
                await presenter.ShowAsync(node.Token, payload ?? new UIParam(), immediately);
                presenter.OnShowExit();
            }
            catch (InitializationFailedException)
            {
                Remove(id);
            }

            return UIShowResult.Success(node.Opened());
        }

        public async UniTask<bool> HideAsync(UIId id, UIHideResult hideResult, bool immediately = false)
        {
            throw new System.NotImplementedException();
        }
        
        public void Remove(UIId id)
        {
            var node = _nodes.FirstOrDefault(x => x.Id == id);
            if (node != null)
            {
                _nodes.Remove(node);
            }

            _iuiManager.Remove(id);
        }


        private IUINavigationNode Open(UIId id)
        {
            var node = _nodes.FirstOrDefault(x => x.Id == id);
            if (node == null)
            {
                node = _navigationNodePool.Get(id);
                _nodes.Add(node);
            }

            node.Reset(id);
            node.Open();
            return node;
        }

        private bool Close(UIId id, out IUINavigationNode node)
        {
            node = _nodes.FirstOrDefault(x => x.Id == id);
            node?.Close();
            return node != null;
        }

        private void Closed(IUINavigationNode node, UIHideResult hideResult)
        {
            node.Closed(hideResult);
            node.Reset(node.Id);
            _nodes.Remove(node);
            _navigationNodePool.Return(node);
        }

        // private void Sort()
        // {
        //     var presenters = new List<ISystemUIPresenter>();
        //     foreach (var presenter in _nodes.Select(node => _uiInstaller.Get<ISystemUIPresenter>(node.Id));
        //     {
        //         presenters.Add(presenter);
        //     }
        //
        //     foreach (var presenter in presenters.OrderBy(x => x.Priority))
        //     {
        //         presenter.SetAsLastSibling();
        //     }
        // }
    }
}