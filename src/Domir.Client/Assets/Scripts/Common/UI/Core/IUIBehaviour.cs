namespace Domir.Client.Common.UI.Core
{
    public interface IUIBehaviour
    {
        public void OnShowEnter();
        public void OnShowExit();
        public void OnHideEnter();
        public void OnHideExit();
    }
}