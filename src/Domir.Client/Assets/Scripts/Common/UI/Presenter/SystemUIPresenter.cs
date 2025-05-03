using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Navigation;
using Domir.Client.Common.UI.View;

namespace Domir.Client.Common.UI.Presenter
{
    public abstract class SystemUIPresenter<TView, TMessage> : UIPresenter<TView, TMessage>, ISystemUIPresenter
        where TView : SystemUIView<TMessage>
        where TMessage : IUIMessage
    {
        public abstract int Priority { get; }

        protected SystemUIPresenter(TView view, IUINavigation navigation) : base(view, navigation) { }
    }
}