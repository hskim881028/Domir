using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Navigation;
using Domir.Client.Common.UI.Core.Presenter;
using Domir.Client.Common.UI.Implementation.View;

namespace Domir.Client.Common.UI.Implementation.Presenter
{
    public abstract class SystemUIPresenter<TView, TMessage> : UIPresenter<TView, TMessage>, ISystemUIPresenter
        where TView : SystemUIView<TMessage>
        where TMessage : IUIMessage
    {
        public abstract int Priority { get; }

        protected SystemUIPresenter(TView view, IUINavigation navigation) : base(view, navigation)
        {
        }
    }
}