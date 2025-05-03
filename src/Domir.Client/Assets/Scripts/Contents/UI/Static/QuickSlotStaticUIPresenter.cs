using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Contract;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Navigation;
using Domir.Client.Common.UI.Presenter;
using UnityEngine;

namespace Domir.Client.Contents.UI.Static
{
    public class QuickSlotStaticUIPresenter : StaticUIPresenter<QuickSlotStaticUIView, IQuickSlotStaticUIMessage>, IQuickSlotStaticUIMessage
    {
        protected override HashSet<UILayer> Layer => UILayer.SetDefault;

        public override int Priority => 0;

        public QuickSlotStaticUIPresenter(QuickSlotStaticUIView view, IUINavigation navigation) : base(view, navigation) { }

        public async override UniTask ShowAsync(CancellationToken token, UIParam param, bool immediately = false)
        {
            await Awaitable.WaitForSecondsAsync(1, token);
            await base.ShowAsync(token, param, immediately);
        }
    }
}