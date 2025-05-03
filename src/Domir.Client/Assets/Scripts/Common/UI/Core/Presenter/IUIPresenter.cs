using UnityEngine;

namespace Domir.Client.Common.UI.Core.Presenter
{
    public interface IUIPresenter : IUIHierarchyControl, IUIActivatable, IUIBehaviour
    {
        public GameObject FirstSelector { get; }
        public GameObject LastSelector { get; set; }
    }
}