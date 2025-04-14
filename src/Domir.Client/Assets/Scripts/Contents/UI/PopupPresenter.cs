using Common.UI.Implementation;

namespace Domir.Client.Contents.UI
{
    public class PopupPresenter : UIPresenter<PopupView, IPopupMessage>, IPopupMessage
    {
        public PopupPresenter(UIHandleFactory handleFactory, UINavigation navigation, PopupView view)
            : base(handleFactory, navigation, view)
        {
            View.PopupTest();
        }

        public void Ok()
        {
            Close();
        }

        public void Cancel()
        {
            Close();
        }
    }
}