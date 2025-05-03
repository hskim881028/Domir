using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Common.UI.Core
{
    public interface IUICanvas
    {
        public LifetimeScope LifetimeScope { get; }
        public RectTransform Self { get; }
    }
}