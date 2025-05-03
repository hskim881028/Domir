using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;
using Domir.Client.Common.UI.Core.Presenter;
using Domir.Client.Common.UI.Implementation.View;

namespace Domir.Client.Common.UI.Implementation.Presenter
{
    public abstract class StackUIPresenter<TView, TMessage> : UIPresenter<TView, TMessage>, IStackUIPresenter
        where TView : StackUIView<TMessage>
        where TMessage : IUIMessage
    {

        protected StackUIPresenter(TView view) : base(view)
        {
        }

        protected void Close(UIHideResult hideResult)
        {
        }
    }
}
