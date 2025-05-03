using Domir.Client.Common.UI.Core.Presenter;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;

namespace Domir.Client.Common.UI.Core.Component
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public class UIChild : MonoBehaviour, IUI
    {
        private IUIPresenter _presenter;
        private Canvas _canvas;

        public LifetimeScope LifetimeScope { get; private set; }
        public RectTransform Self { get; private set; }

        public IUIPresenter Presenter
        {
            get
            {
                Self.SetAsLastSibling();
                return _presenter;
            }
            set
            {
                _presenter = value;
                _presenter.SetParent(Self);
                switch (_presenter)
                {
                    case ISystemUIPresenter system:
                        system.SetSiblingIndex();
                        break;
                }
            }
        }

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
            _canvas.pixelPerfect = false;
            _canvas.vertexColorAlwaysGammaSpace = this;
        }
    }
}