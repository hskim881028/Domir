namespace Domir.Client.Common.UI.Core.Presenter
{
    public interface ISystemUIPresenter : IUIPresenter
    {
        public int Priority { get; }
    }
}