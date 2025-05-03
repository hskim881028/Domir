using System;
using Domir.Client.Common.UI.Core.Presenter;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;

namespace Domir.Client.Common.UI.Core.Component
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public sealed class UICanvas : MonoBehaviour, IUICanvas
    {
        private Canvas _canvas;

        public LifetimeScope LifetimeScope { get; private set; }

        public void SetSortOrder(Type uiType)
        {
            _canvas.sortingOrder = uiType.Name switch
            {
                nameof(IStaticUIPresenter) => UIOrder.StaticId,
                nameof(IStackUIPresenter) => UIOrder.StackId,
                nameof(ISystemUIPresenter) => UIOrder.SystemId,
                _ => _canvas.sortingOrder
            };
        }

        private void Awake()
        {
            var rectTransform = GetComponent<RectTransform>();
            rectTransform.localScale = Vector3.one;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.pivot = Vector2.one * 0.5f;

            _canvas = GetComponent<Canvas>();
            _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            _canvas.vertexColorAlwaysGammaSpace = this;

            var canvasScaler = GetComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1920, 1080);
            canvasScaler.matchWidthOrHeight = 0;
            canvasScaler.referencePixelsPerUnit = 100;

            LifetimeScope = GetComponent<LifetimeScope>();
        }
    }
}