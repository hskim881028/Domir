using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.UI.Presenter;
using UnityEngine;
using UnityEngine.UI;
using VContainer.Unity;

namespace Domir.Client.Core.Scope
{
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(GraphicRaycaster))]
    public sealed class UIScope : LifetimeScope
    {
        private RectTransform _rectTransform;
        private IUIPresenter _presenter;

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
        }

        public UIScope Initialize(IUIPresenter presenter)
        {
            gameObject.layer = Layer.UI;

            _rectTransform = GetComponent<RectTransform>();
            _rectTransform.localScale = Vector3.one;
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
            _rectTransform.anchorMin = Vector2.zero;
            _rectTransform.anchorMax = Vector2.one;
            _rectTransform.pivot = Vector2.one * 0.5f;

            _presenter = presenter;
            _presenter.SetParent(_rectTransform);

            var canvas = GetComponent<Canvas>();
            canvas.pixelPerfect = false;
            canvas.vertexColorAlwaysGammaSpace = true;
            return this;
        }
    }
}