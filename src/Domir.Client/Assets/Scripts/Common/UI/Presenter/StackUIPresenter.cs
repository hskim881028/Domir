using Domir.Client.Common.UI.Contract;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Navigation;
using Domir.Client.Common.UI.View;

namespace Domir.Client.Common.UI.Presenter
{
    public abstract class StackUIPresenter<TView, TMessage> : UIPresenter<TView, TMessage>, IStackUIPresenter
        where TView : StackUIView<TMessage>
        where TMessage : IUIMessage
    {
        protected StackUIPresenter(TView view, IUINavigation navigation) : base(view, navigation) { }

        protected void Close(UIResult result) { }
    }
}