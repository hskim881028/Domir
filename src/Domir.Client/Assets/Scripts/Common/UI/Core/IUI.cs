using Domir.Client.Common.UI.Core.Presenter;

namespace Domir.Client.Common.UI.Core
{
    public interface IUI : IUICanvas
    {
        public IUIPresenter Presenter { get; set; }
    }
}