using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Contract;

namespace Domir.Client.Common.UI.Navigation
{
    public interface IUIHandle : IDisposable
    {
        public void Reset(CancellationToken cancellationToken);
        public IUIHandle Opened();
        public IUIHandle Closed(UIResult result);
        public UniTask<UIResult> WaitUntilClosedAsync();
    }
}