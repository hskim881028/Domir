using Common.UI;

namespace Domir.Client.Contents.UI
{
    public interface IPopupMessage : IUIMessage
    {
        public void Ok();
        public void Cancel();
    }
}