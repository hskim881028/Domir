using Domir.Client.Common.UI.Implementation.Presenter;

namespace Domir.Client.Contents.UI.System
{
    public class PopupSystemUIPresenter : SystemUIPresenter<PopupSystemUIView, IPopupSystemUIMessage>, IPopupSystemUIMessage
    {
        public override int Priority => 0;

        public PopupSystemUIPresenter(PopupSystemUIView view) : base(view)
        {
        }

        public void Confirm()
        {
        }

        public void Cancel()
        {
        }
    }
}