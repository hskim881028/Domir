using System;
using System.Collections.Generic;
using Domir.Client.Common.UI.Core;
using Domir.Client.Contents.UI.Stack;
using Domir.Client.Contents.UI.System;

namespace Domir.Client.Contents.UI.Generated
{
    public static class UIMapping
    {
        public static readonly Dictionary<UIId, (Type type, string prefabPath)> UI = new()
        {
            {
                SystemUIId.Popup, (typeof(PopupSystemUIPresenter), "UI/System/PopupSystemUI")
            },
            {
                StackUIId.Inventory, (typeof(InventoryStackUIPresenter), "UI/Stack/InventoryStackUI")
            },
        };
    }
}