using System;
using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Presenter;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Core.Scope
{
    [RequireComponent(typeof(Canvas))]
    public sealed class UICanvasScope : LifetimeScope
    {
        public UICanvasScope Initialize(Type uiType, Transform parent)
        {
            gameObject.layer = Layer.UI;

            var rectTransform = GetComponent<RectTransform>();
            rectTransform.SetParent(parent);
            rectTransform.localScale = Vector3.one;
            rectTransform.localPosition = Vector3.zero;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.pivot = Vector2.one * 0.5f;

            var canvas = GetComponent<Canvas>();
            canvas.pixelPerfect = false;
            canvas.vertexColorAlwaysGammaSpace = true;
            canvas.sortingOrder = uiType.Name switch
            {
                nameof(IStaticUIPresenter) => UIOrder.StaticId,
                nameof(IStackUIPresenter) => UIOrder.StackId,
                nameof(ISystemUIPresenter) => UIOrder.SystemId,
                _ => throw new ArgumentOutOfRangeException(nameof(uiType), uiType, null),
            };
            return this;
        }
    }
}