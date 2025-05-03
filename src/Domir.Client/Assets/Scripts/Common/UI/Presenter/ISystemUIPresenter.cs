namespace Domir.Client.Common.UI.Presenter
{
    public interface ISystemUIPresenter : IUIPresenter
    {
        public int Priority { get; }
    }
}