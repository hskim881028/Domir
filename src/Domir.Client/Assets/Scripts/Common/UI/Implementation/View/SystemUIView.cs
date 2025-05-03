using Domir.Client.Common.UI.Core;

namespace Domir.Client.Common.UI.Implementation.View
{
    public class SystemUIView<TMessage> : UIView<TMessage> where TMessage : IUIMessage
    {
        public void SetSiblingIndex(int index)
        {
            Self.SetSiblingIndex(index);
        }
    }
}