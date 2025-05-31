using System.Collections.Generic;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;

namespace Domir.Client.Contents.UI.Static
{
    public class MinimapStaticUIPresenter : StaticUIPresenter<MinimapStaticUIView, IMinimapStaticUIMessage>, IMinimapStaticUIMessage
    {
        public MinimapStaticUIPresenter(MinimapStaticUIView view, IUINavigation navigation) : base(view, navigation) { }

        protected override HashSet<UILayer> Layer => UILayer.Set(UILayers.Minimap);
        public override UIPriority Priority => UIPriority.Minimap;
    }
}