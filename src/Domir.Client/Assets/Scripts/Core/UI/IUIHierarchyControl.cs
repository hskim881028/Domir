using UnityEngine;

namespace Domir.Client.Core.UI
{
    public interface IUIHierarchyControl
    {
        public void SetParent(Transform parent);
    }
}