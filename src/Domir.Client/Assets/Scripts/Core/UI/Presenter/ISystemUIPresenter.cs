namespace Domir.Client.Core.UI.Presenter
{
    public interface ISystemUIPresenter : IUIPresenter
    {
        public int Priority { get; }
    }
}