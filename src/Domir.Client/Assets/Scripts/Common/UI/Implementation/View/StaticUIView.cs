using Domir.Client.Common.UI.Core;
using UnityEngine;

namespace Domir.Client.Common.UI.Implementation.View
{
    public class StaticUIView<TMessage> : UIView<TMessage> where TMessage : IUIMessage
    {
        public void Preload(Transform parent)
        {
            Self.SetParent(parent);
            gameObject.SetActive(false);
        }
    }
}