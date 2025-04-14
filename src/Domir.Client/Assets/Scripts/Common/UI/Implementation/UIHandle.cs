using UnityEngine;

namespace Common.UI.Implementation
{
    public class UIHandle : IUIHandle
    {
        private readonly AwaitableCompletionSource<UIResult> _acs = new();

        public Awaitable<UIResult> Awaitable => _acs.Awaitable;

        public void Complete(UIResult result)
        {
            _acs.TrySetResult(result);
        }
    }
}