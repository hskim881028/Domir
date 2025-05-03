using Domir.Client.Common.UI.Implementation.Presenter;

namespace Domir.Client.Contents.UI.Stack
{
    public class InventoryStackUIPresenter : StackUIPresenter<InventoryStackUIView, IInventoryStackUIMessage>, IInventoryStackUIMessage
    {
        public InventoryStackUIPresenter(InventoryStackUIView view) : base(view)
        {
        }
    }
}