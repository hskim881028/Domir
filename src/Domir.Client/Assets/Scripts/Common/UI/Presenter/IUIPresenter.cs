using Domir.Client.Common.UI.Core;
using UnityEngine;

namespace Domir.Client.Common.UI.Presenter
{
    public interface IUIPresenter : IUIHierarchyControl, IUIActivatable, IUIBehaviour
    {
        public GameObject FirstSelector { get; }
        public GameObject LastSelector { get; set; }
    }
}