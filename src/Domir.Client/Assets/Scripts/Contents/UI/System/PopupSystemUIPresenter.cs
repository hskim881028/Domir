using Domir.Client.Contents.Command;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.Core.UI.Contract;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Contents.UI.System
{
    public class PopupSystemUIPresenter : SystemUIPresenter<PopupSystemUIView, IPopupSystemUIMessage>, IPopupSystemUIMessage
    {
        private readonly CommandExecutor _commandExecutor;
        public override int Priority => 0;

        public PopupSystemUIPresenter(
            PopupSystemUIView view,
            IUINavigation navigation,
            CommandExecutor commandExecutor) : base(view, navigation)
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