using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.UI.Implementation
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UIView<TMessage> : UIViewBase, IUIView<TMessage> where TMessage : IUIMessage
    {
        private CanvasGroup _canvasGroup;

        protected TMessage Message;

        private void Awake()
        {
            OnAwake();
        }

        public string Id { get; private set; }

        public virtual void OnAwake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
        }

        public void SetId(string id)
        {
            Id = id;
        }

        public void AttachMessage(TMessage message)
        {
            Message = message;
        }

        public async UniTask InitializeAsync()
        {
            await Awaitable.WaitForSecondsAsync(1);
            _canvasGroup.alpha = 1;
        }

        public async UniTask ShowAsync()
        {
            _canvasGroup.alpha = 0;
            gameObject.SetActive(true);
            _canvasGroup.alpha = 1;
            await UniTask.CompletedTask;
        }

        public async UniTask HideAsync()
        {
            gameObject.SetActive(false);
            await UniTask.CompletedTask;
        }
    }
}