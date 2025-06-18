using Domir.Client.Core.UI;

namespace Domir.Client.Contents.UI.System
{
    public interface IPopupSystemUIMessage : IUIMessage
    {
        public void Confirm();
        public void Cancel();
    }
}