using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Core.Contract;

namespace Domir.Client.Common.UI.Core
{
    public interface IUIHandle : IDisposable
    {
        public bool IsOpened { get; }
        public bool IsClosed { get; }
        public void Reset(CancellationToken cancellationToken);
        public void Open();
        public void Opened();
        public void Close();
        public void Closed(UIHideResult hideResult);
        public UniTask<UIHideResult> WaitUntilClosedAsync();
    }
}