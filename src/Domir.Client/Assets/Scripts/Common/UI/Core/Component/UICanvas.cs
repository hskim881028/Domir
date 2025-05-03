using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;

namespace Domir.Client.Common.UI.Core.Component
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasScaler))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class UICanvas : MonoBehaviour, IUICanvas
    {
        private Canvas _canvas;
        private CanvasScaler _canvasScaler;

        public LifetimeScope LifetimeScope { get; private set; }
        public RectTransform Self { get; private set; }

        private void Awake()
        {
            LifetimeScope = GetComponent<LifetimeScope>();

            Self = GetComponent<RectTransform>();
            Self.localScale = Vector3.one;
            Self.offsetMin = Vector2.zero;
            Self.offsetMax = Vector2.zero;
            Self.anchorMin = Vector2.zero;
            Self.anchorMax = Vector2.one;
            Self.pivot = Vector2.one * 0.5f;

            _canvas = GetComponent<Canvas>();
            _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            _canvas.vertexColorAlwaysGammaSpace = this;

            _canvasScaler = GetComponent<CanvasScaler>();
            _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            _canvasScaler.referenceResolution = new Vector2(1920, 1080);
            _canvasScaler.matchWidthOrHeight = 0;
            _canvasScaler.referencePixelsPerUnit = 100;
        }
    }
}