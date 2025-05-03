using System.Collections.Generic;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Presenter;
using Domir.Client.Common.UI.Implementation.View;
using log4net.Util;

namespace Domir.Client.Common.UI.Implementation.Presenter
{
    public abstract class StaticUIPresenter<TView, TMessage> : UIPresenter<TView, TMessage>, IStaticUIPresenter
        where TView : StaticUIView<TMessage>
        where TMessage : IUIMessage
    {
        protected abstract HashSet<UILayer> Layer { get; }

        public abstract int Priority { get; }

        protected StaticUIPresenter(TView view) : base(view)
        {
        }

        public bool HasLayer(UILayer layer) => Layer.Contains(layer);

        public void Preload(Transform parent)
        {
        }
    }
}