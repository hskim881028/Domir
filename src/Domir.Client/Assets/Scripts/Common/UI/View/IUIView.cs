using Domir.Client.Common.UI.Core;

namespace Domir.Client.Common.UI.View
{
    public interface IUIView<in TMessage> : IUIHierarchyControl, IUIActivatable
    {
        public void AttachMessage(TMessage message);
    }
}