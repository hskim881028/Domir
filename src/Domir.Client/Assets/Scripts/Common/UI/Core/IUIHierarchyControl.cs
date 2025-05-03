using UnityEngine;

namespace Domir.Client.Common.UI.Core
{
    public interface IUIHierarchyControl
    {
        public void SetParent(Transform parent);
    }
}