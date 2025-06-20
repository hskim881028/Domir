﻿using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Contract;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Core.UI.Presenter;
using UnityEngine;

namespace Domir.Client.Contents.UI.Static
{
    public class QuickSlotStaticUIPresenter : StaticUIPresenter<QuickSlotStaticUIView, IQuickSlotStaticUIMessage>, IQuickSlotStaticUIMessage
    {
        protected override HashSet<UILayer> Layer => UILayer.SetDefault;

        public override UIPriority Priority => UIPriority.QuickSlot;

        public QuickSlotStaticUIPresenter(QuickSlotStaticUIView view, IUINavigation navigation) : base(view, navigation) { }

        public override async UniTask ShowAsync(CancellationToken token, UIParam param, bool immediately = false)
        {
            await Awaitable.WaitForSecondsAsync(1, token);
            await base.ShowAsync(token, param, immediately);
        }
    }
}