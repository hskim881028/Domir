using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;
using Domir.Client.Common.UI.Core.View;
using UnityEngine;

namespace Domir.Client.Common.UI.Implementation.View
{
    [RequireComponent(typeof(CanvasGroup))]
    public class UIView<TMessage> : UIViewBase, IUIView<TMessage> where TMessage : IUIMessage
    {
        // [SerializeField] private UIViewContent _content;

        protected TMessage Message;
        private CanvasGroup _canvasGroup;
        private RectTransform _rectTransform;

        protected RectTransform Self => _rectTransform ?? GetComponent<RectTransform>();

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
        }

        public void AttachMessage(TMessage message)
        {
            Message = message;
        }

        public void SetParent(Transform parent)
        {
            Self.SetParent(parent);
            Self.localScale = Vector3.one;
            Self.offsetMin = Vector2.zero;
            Self.offsetMax = Vector2.zero;
            Self.anchorMin = Vector2.zero;
            Self.anchorMax = Vector2.one;
            Self.pivot = Vector2.one * 0.5f;
        }

        public virtual UniTask InitializeAsync(CancellationToken token)
        {
            return UniTask.CompletedTask;
        }

        public virtual async UniTask ShowAsync(CancellationToken token, UIParam param, bool immediately = false)
        {
            _canvasGroup.interactable = false;
            _canvasGroup.alpha = 1;
            // await _content.ShowAsync(token, immediately);
            _canvasGroup.interactable = true;
        }

        public virtual async UniTask HideAsync(CancellationToken token, bool immediately = false)
        {
            _canvasGroup.interactable = false;
            // await _content.HideAsync(token, immediately);
            gameObject.SetActive(false);
        }

        public void Activate(float opacity = 1)
        {
            _canvasGroup.alpha = opacity;
            // _content.transform.localScale = Vector3.one;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}