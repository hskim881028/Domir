using Domir.Client.Common.UI.Core;

namespace Domir.Client.Contents.UI.System
{
    public interface IPopupSystemUIMessage : IUIMessage
    {
        public void Confirm();
        public void Cancel();
    }
}