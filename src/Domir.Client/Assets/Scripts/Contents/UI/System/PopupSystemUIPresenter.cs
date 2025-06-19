using Domir.Client.Contents.UI.Generated;
using Domir.Client.Core.Command;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Contract;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Contents.UI.System
{
    public class PopupSystemUIPresenter : SystemUIPresenter<PopupSystemUIView, IPopupSystemUIMessage>, IPopupSystemUIMessage
    {
        private readonly ICommandExecutor _commandExecutor;
        public override UIPriority Priority => UIPriority.Popup;

        public PopupSystemUIPresenter(
            PopupSystemUIView view,
            IUINavigation navigation,
            ICommandExecutor commandExecutor) : base(view, navigation)
        {
            _commandExecutor = commandExecutor;
        }

        public void Confirm()
        {
            Close(SystemUIId.Popup, UIResult.Ok);
        }

        public void Cancel()
        {
            Close(SystemUIId.Popup, UIResult.Close);
        }
    }
}