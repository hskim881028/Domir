namespace Domir.Client.Common.UI.Core.View
{
    public interface IUIView<in TMessage> : IUIHierarchyControl, IUIActivatable
    {
        public void AttachMessage(TMessage message);
    }
}