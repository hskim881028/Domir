using Domir.Client.Common.UI.Core;

namespace Domir.Client.Common.UI.Presenter
{
    public interface IStaticUIPresenter : IUIPresenter
    {
        public int Priority { get; }
        public bool HasLayer(UILayer layer);
    }
}