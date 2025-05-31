namespace Domir.Client.Core.UI.Presenter
{
    public interface ISystemUIPresenter : IUIPresenter
    {
        public UIPriority Priority { get; }
    }
}