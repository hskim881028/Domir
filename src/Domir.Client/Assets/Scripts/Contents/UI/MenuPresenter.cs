using Common.UI;
using Common.UI.Implementation;

namespace Domir.Client.Contents.UI
{
    public class MenuPresenter : UIPresenter<MenuView, IMenuViewMessage>, IMenuViewMessage
    {
        public MenuPresenter(IUIHandleFactory handleFactory, UINavigation navigation, MenuView view)
            : base(handleFactory, navigation, view)
        {
        }
    }
}