using Common.UI;
using UnityEngine.UI;

namespace Test
{
    public class DomirButton : Button, IUISelectable
    {
        public IUIView Parent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Parent = GetComponentInParent<IUIView>();
        }
    }
}