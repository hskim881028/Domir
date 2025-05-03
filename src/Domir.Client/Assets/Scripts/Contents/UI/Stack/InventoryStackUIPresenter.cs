using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Navigation;
using Domir.Client.Common.UI.Implementation.Presenter;

namespace Domir.Client.Contents.UI.Stack
{
    public class InventoryStackUIPresenter : StackUIPresenter<InventoryStackUIView, IInventoryStackUIMessage>, IInventoryStackUIMessage
    {
        public InventoryStackUIPresenter(InventoryStackUIView view, IUINavigation navigation) : base(view, navigation)
        {
        }
    }
}