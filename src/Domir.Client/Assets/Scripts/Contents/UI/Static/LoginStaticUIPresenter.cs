using System.Collections.Generic;
using Domir.Client.Contents.Command;
using Domir.Client.Core.Command;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Contents.UI.Static
{
    public class LoginStaticUIPresenter : StaticUIPresenter<LoginStaticUIView, ILoginStaticUIMessage>, ILoginStaticUIMessage
    {
        private readonly ICommandExecutor _commandExecutor;

        protected override HashSet<UILayer> Layer => UILayer.Set(UILayers.Login);
        public override UIPriority Priority => UIPriority.Login;

        public LoginStaticUIPresenter(
            LoginStaticUIView view,
            IUINavigation navigation,
            ICommandExecutor commandExecutor)
            : base(view, navigation)
        {
            _commandExecutor = commandExecutor;
        }

        public void ClickHost()
        {
            _commandExecutor.Enqueue<StartHost>();
        }

        public void ClickClient()
        {
            _commandExecutor.Enqueue<StartClient>();
        }
    }
}