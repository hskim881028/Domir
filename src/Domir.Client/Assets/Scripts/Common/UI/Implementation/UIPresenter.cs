using System;
using Cysharp.Threading.Tasks;
using R3;
using UnityEngine;

namespace Common.UI.Implementation
{
    public class UIPresenter<TView, TMessage> : IUIPresenter, IDisposable
        where TView : IUIView<TMessage>
        where TMessage : IUIMessage
    {
        private readonly IUIHandleFactory _handleFactory;
        private IUIHandle _handle;
        private bool _initialized;

        protected readonly UINavigation Navigation;
        protected readonly TView View;
        protected DisposableBag Disposable;

        public string Id => GetType().Name;
        public GameObject FirstSelector { get; }
        public GameObject LastSelector { get; set; }

        protected UIPresenter(IUIHandleFactory handleFactory, UINavigation navigation, TView view)
        {
            if (this is not TMessage message)
            {
                throw new Exception($"");
            }

            _handleFactory = handleFactory;
            Navigation = navigation;
            View = view;
            View.SetId(Id);
            View.AttachMessage(message);
        }

        public void Dispose()
        {
            Disposable.Dispose();
        }

        public IUIHandle GenerateHandle()
        {
            _handle = _handleFactory.Create();
            return _handle;
        }

        public async UniTask InitializeAsync()
        {
            if (_initialized) return;

            _initialized = true;
            await View.InitializeAsync();
        }

        public virtual async UniTask ShowAsync()
        {
            await InitializeAsync();
            await View.ShowAsync();
            _handle.Complete(UIResult.OK);
        }

        public virtual async UniTask HideAsync()
        {
            await View.HideAsync();
        }

        protected void Close()
        {
            Navigation.HideAsync(Id);
        }
    }
}