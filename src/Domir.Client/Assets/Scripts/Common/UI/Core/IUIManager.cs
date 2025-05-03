using System.Collections.Generic;
using Domir.Client.Common.UI.Core.Presenter;

namespace Domir.Client.Common.UI.Core
{
    public interface IUIManager
    {
        public IReadOnlyList<UIId> Preload();
        public T Get<T>(UIId id) where T : IUIPresenter;
        public void Remove(UIId id);
    }
}