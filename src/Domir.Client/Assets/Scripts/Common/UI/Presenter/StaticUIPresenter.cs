using System.Collections.Generic;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Navigation;
using Domir.Client.Common.UI.View;

namespace Domir.Client.Common.UI.Presenter
{
    public abstract class StaticUIPresenter<TView, TMessage> : UIPresenter<TView, TMessage>, IStaticUIPresenter
        where TView : StaticUIView<TMessage>
        where TMessage : IUIMessage
    {
        protected abstract HashSet<UILayer> Layer { get; }

        public abstract int Priority { get; }

        protected StaticUIPresenter(TView view, IUINavigation navigation) : base(view, navigation) { }

        public bool HasLayer(UILayer layer) => Layer.Contains(layer);
    }
}