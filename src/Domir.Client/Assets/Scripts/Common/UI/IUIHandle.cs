using Common.UI.Implementation;
using UnityEngine;

namespace Common.UI
{
    public interface IUIHandle
    {
        public Awaitable<UIResult> Awaitable { get; }
        public void Complete(UIResult result);
    }
}