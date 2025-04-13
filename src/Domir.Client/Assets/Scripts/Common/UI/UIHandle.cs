using UnityEngine;

namespace Common.UI
{
    public class UIHandle : IUIHandle
    {
        private readonly AwaitableCompletionSource<IUIResult> _acs = new();

        public Awaitable<IUIResult> Awaitable => _acs.Awaitable;

        public void Complete(IUIResult result)
        {
            _acs.TrySetResult(result);
        }
    }
}