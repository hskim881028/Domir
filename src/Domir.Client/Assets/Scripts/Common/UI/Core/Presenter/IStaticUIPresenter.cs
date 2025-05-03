namespace Domir.Client.Common.UI.Core.Presenter
{
    public interface IStaticUIPresenter : IUIPresenter
    {
        public int Priority { get; }
        public bool HasLayer(UILayer layer);
    }
}