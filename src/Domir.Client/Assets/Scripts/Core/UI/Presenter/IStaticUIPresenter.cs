using Domir.Client.Common.UI.Core;

namespace Domir.Client.Core.UI.Presenter
{
    public interface IStaticUIPresenter : IUIPresenter
    {
        public int Priority { get; }
        public bool HasLayer(UILayer layer);
    }
}