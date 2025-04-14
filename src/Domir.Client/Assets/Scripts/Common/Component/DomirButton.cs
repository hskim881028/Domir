using Common.UI;
using Common.UI.Implementation;
using UnityEngine.UI;

namespace Common.Component
{
    public class DomirButton : Button, IUISelectable
    {
        public UIViewBase Parent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Parent = GetComponentInParent<UIViewBase>();
        }
    }
}