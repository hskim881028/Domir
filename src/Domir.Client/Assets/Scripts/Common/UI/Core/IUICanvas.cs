using System;

namespace Domir.Client.Common.UI.Core
{
    public interface IUICanvas : IUIScope
    {
        public void SetSortOrder(Type uiType);
    }
}