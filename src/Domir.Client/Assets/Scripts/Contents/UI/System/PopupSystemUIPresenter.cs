using Domir.Client.Common.UI.Contract;
using Domir.Client.Common.UI.Navigation;
using Domir.Client.Common.UI.Presenter;
using Domir.Client.Contents.UI.Generated;

namespace Domir.Client.Contents.UI.System
{
    public class PopupSystemUIPresenter : SystemUIPresenter<PopupSystemUIView, IPopupSystemUIMessage>, IPopupSystemUIMessage
    {
        public override int Priority => 0;

        public PopupSystemUIPresenter(PopupSystemUIView view, IUINavigation navigation) : base(view, navigation) { }

        public void Confirm()
        {
            Close(SystemUIId.Popup, UIResult.Ok);
        }

        public void Cancel()
        {
            Close(SystemUIId.Popup, UIResult.Close);
        }
    }
}