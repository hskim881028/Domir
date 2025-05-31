using System.Collections.Generic;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.View;

namespace Domir.Client.Core.UI.Presenter
{
    public abstract class StaticUIPresenter<TView, TMessage> : UIPresenter<TView, TMessage>, IStaticUIPresenter
        where TView : StaticUIView<TMessage>
        where TMessage : IUIMessage
    {
        protected abstract HashSet<UILayer> Layer { get; }

        public abstract UIPriority Priority { get; }

        protected StaticUIPresenter(TView view, IUINavigation navigation) : base(view, navigation) { }

        public bool HasLayer(UILayer layer) => Layer.Contains(layer);
    }
}