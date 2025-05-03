using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;
using Domir.Client.Common.UI.Core.Navigation;
using Domir.Client.Common.UI.Implementation.Presenter;
using Domir.Client.Contents.UI.Generated;

namespace Domir.Client.Contents.UI.System
{
    public class PopupSystemUIPresenter : SystemUIPresenter<PopupSystemUIView, IPopupSystemUIMessage>, IPopupSystemUIMessage
    {
        public override int Priority => 0;

        public PopupSystemUIPresenter(PopupSystemUIView view, IUINavigation navigation) : base(view, navigation)
        {
        }

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