using UnityEngine;

namespace Common.UI
{
    public interface IUIView
    {
        public GameObject FirstSelector { get; }
        public GameObject LastSelector { get; set; }
        public IUIHandle Handle { get; }
        public IUIHandle GenerateHandle();
        public void Show();
        public void Hide();
    }
}