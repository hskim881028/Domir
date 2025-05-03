using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Presenter;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;

namespace Domir.Client.Common.UI.Scope
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public sealed class UIChild : MonoBehaviour, IUI
    {
        private RectTransform _rectTransform;
        private IUIPresenter _presenter;
        private Canvas _canvas;

        public LifetimeScope LifetimeScope { get; private set; }

        public IUIPresenter Presenter
        {
            get
            {
                switch (_presenter)
                {
                    case IStaticUIPresenter staticPresenter:
                        _rectTransform.SetSiblingIndex(staticPresenter.Priority);
                        break;
                    case IStackUIPresenter stackPresenter:
                        _rectTransform.SetAsLastSibling();
                        break;
                    case ISystemUIPresenter systemPresenter:
                        _rectTransform.SetSiblingIndex(systemPresenter.Priority);
                        break;
                }

                return _presenter;
            }
            set
            {
                _presenter = value;
                _presenter.SetParent(_rectTransform);
            }
        }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.localScale = Vector3.one;
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
            _rectTransform.anchorMin = Vector2.zero;
            _rectTransform.anchorMax = Vector2.one;
            _rectTransform.pivot = Vector2.one * 0.5f;

            _canvas = GetComponent<Canvas>();
            _canvas.pixelPerfect = false;
            _canvas.vertexColorAlwaysGammaSpace = this;

            LifetimeScope = GetComponent<LifetimeScope>();
        }
    }
}