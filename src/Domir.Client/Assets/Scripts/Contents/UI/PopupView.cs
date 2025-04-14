using Common.Component;
using Common.UI.Implementation;
using UnityEngine;

namespace Domir.Client.Contents.UI
{
    public class PopupView : UIView<IPopupMessage>
    {
        [SerializeField] private DomirButton _okButton;
        [SerializeField] private DomirButton _cancelButton;

        public override void OnAwake()
        {
            base.OnAwake();
            _okButton.onClick.AddListener(() => Message.Ok());
            _cancelButton.onClick.AddListener(() => Message.Cancel());
        }

        public void PopupTest()
        {
        }
    }
}