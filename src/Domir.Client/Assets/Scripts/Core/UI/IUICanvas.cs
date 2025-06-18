using System;
using UnityEngine;

namespace Domir.Client.Core.UI
{
    public interface IUICanvas
    {
        public IUICanvas Initialize(Type uiType, Transform parent);
    }
}