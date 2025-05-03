using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Implementation.Presenter;

namespace Domir.Client.Contents.UI.System
{
    public class NetworkWaitingUIPresenter : SystemUIPresenter<NetworkWaitingUIView, IUIMessage>, IUIMessage
    {
        public override int Priority => 99;
        
        public NetworkWaitingUIPresenter(NetworkWaitingUIView view) : base(view)
        {
        }
    }
}