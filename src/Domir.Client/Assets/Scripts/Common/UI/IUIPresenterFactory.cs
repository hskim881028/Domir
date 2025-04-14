namespace Common.UI
{
    public interface IUIPresenterFactory
    {
        IUIPresenter Get(string id);
    }
}