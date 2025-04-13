using UnityEngine;

namespace Common.UI
{
    public interface IUIHandle
    {
        public Awaitable<IUIResult> Awaitable { get; }
        public void Complete(IUIResult result);
    }
}