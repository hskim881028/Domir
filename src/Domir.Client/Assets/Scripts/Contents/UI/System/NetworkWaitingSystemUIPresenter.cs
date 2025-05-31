using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Contents.UI.System
{
    public class NetworkWaitingSystemUIPresenter : SystemUIPresenter<NetworkWaitingSystemUIView, IUIMessage>, IUIMessage
    {
        public override UIPriority Priority => UIPriority.NetworkWaiting;

        public NetworkWaitingSystemUIPresenter(NetworkWaitingSystemUIView view, IUINavigation navigation) : base(view, navigation) { }
    }
}