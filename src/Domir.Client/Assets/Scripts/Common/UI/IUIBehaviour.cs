namespace Common.UI
{
    public interface IUIBehaviour
    {
        public void OnInitialize();
        public void OnShowEnter();
        public void OnShowExit();
        public void OnHideEnter();
        public void OnHideExit();
        public void OnRefresh();
        public void OnDestroy();
    }
}