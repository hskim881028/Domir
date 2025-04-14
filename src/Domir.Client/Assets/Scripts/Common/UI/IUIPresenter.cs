using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Common.UI
{
    public interface IUIPresenter : IUIActivatable
    {
        public string Id { get; }
        public GameObject FirstSelector { get; }
        public GameObject LastSelector { get; set; }
        public IUIHandle GenerateHandle();
    }
}