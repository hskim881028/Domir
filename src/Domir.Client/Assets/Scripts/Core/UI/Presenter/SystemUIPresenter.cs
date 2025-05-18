using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.View;

namespace Domir.Client.Core.UI.Presenter
{
    public abstract class SystemUIPresenter<TView, TMessage> : UIPresenter<TView, TMessage>, ISystemUIPresenter
        where TView : SystemUIView<TMessage>
        where TMessage : IUIMessage
    {
        public abstract int Priority { get; }

        protected SystemUIPresenter(TView view, IUINavigation navigation) : base(view, navigation) { }
    }
}