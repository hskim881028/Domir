using System.Collections.Generic;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Implementation.Presenter;

namespace Domir.Client.Contents.UI.Static
{
    public class QuickSlotStaticUIPresenter : StaticUIPresenter<QuickSlotStaticUIView, IQuickSlotStaticUIMessage>, IQuickSlotStaticUIMessage
    {
        protected override HashSet<UILayer> Layer => UILayer.SetDefault;
        
        public override int Priority => 0;

        public QuickSlotStaticUIPresenter(QuickSlotStaticUIView view) : base(view)
        {
        }
    }
}