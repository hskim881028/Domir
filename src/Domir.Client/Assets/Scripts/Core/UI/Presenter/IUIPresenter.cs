using UnityEngine;

namespace Domir.Client.Core.UI.Presenter
{
    public interface IUIPresenter : IUIHierarchyControl, IUIActivatable, IUIBehaviour
    {
        public GameObject FirstSelector { get; }
        public GameObject LastSelector { get; set; }
    }
}