using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Contents.UI.System
{
    public class NetworkWaitingSystemUIPresenter : SystemUIPresenter<NetworkWaitingSystemUIView, IUIMessage>, IUIMessage
    {
        public override int Priority => 99;

        public NetworkWaitingSystemUIPresenter(NetworkWaitingSystemUIView view, IUINavigation navigation) : base(view, navigation) { }
    }
}