using System.Collections.Generic;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Navigation;
using Domir.Client.Common.UI.Implementation.Presenter;

namespace Domir.Client.Contents.UI.Static
{
    public class MinimapStaticUIPresenter : StaticUIPresenter<MinimapStaticUIView, IMinimapStaticUIMessage>, IMinimapStaticUIMessage
    {
        protected override HashSet<UILayer> Layer => UILayer.Set(UILayers.Test);
        public override int Priority => 1;
        
        public MinimapStaticUIPresenter(MinimapStaticUIView view, IUINavigation navigation) : base(view, navigation)
        {
        }
    }
}