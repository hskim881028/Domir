using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Navigation;
using Domir.Client.Common.UI.Implementation.Presenter;

namespace Domir.Client.Contents.UI.System
{
    public class NetworkWaitingSystemUIPresenter : SystemUIPresenter<NetworkWaitingSystemUIView, IUIMessage>, IUIMessage
    {
        public override int Priority => 99;
        
        public NetworkWaitingSystemUIPresenter(NetworkWaitingSystemUIView view, IUINavigation navigation) : base(view, navigation)
        {
        }
    }
}