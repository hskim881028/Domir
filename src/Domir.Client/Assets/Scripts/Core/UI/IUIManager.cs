using System;
using System.Collections.Generic;
using Domir.Client.Common.UI.Core;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Core.UI
{
    public interface IUIManager : IDisposable
    {
        public IReadOnlyList<UIId> GetStaticUI();
        public T Get<T>(UIId id) where T : IUIPresenter;
        public void Remove(UIId id);
    }
}