using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Contents.UI.Stack
{
    public class InventoryStackUIPresenter : StackUIPresenter<InventoryStackUIView, IInventoryStackUIMessage>, IInventoryStackUIMessage
    {
        public InventoryStackUIPresenter(InventoryStackUIView view, IUINavigation navigation) : base(view, navigation) { }
    }
}