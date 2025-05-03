using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;
using Domir.Client.Common.UI.Core.State;

namespace Domir.Client.Common.UI.Implementation
{
    public class UIHandle : IUIHandle

    {
        private UniTaskCompletionSource<UIHideResult> _closeSource = new();
        private CancellationToken _cancellationToken;
        private UIHandleState _state = UIHandleState.Created;
        private bool _isDisposed;

        public bool IsOpened => _state >= UIHandleState.Opened;
        public bool IsClosed => _state >= UIHandleState.Closed;

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            _closeSource.TrySetCanceled();
        }

        public void Reset(CancellationToken cancellationToken)
        {
            _cancellationToken = cancellationToken;
            _closeSource = new UniTaskCompletionSource<UIHideResult>();
            _state = UIHandleState.Created;
        }

        public void Open()
        {
            _state = UIHandleState.Opening;
        }

        public void Opened()
        {
            _state = UIHandleState.Opened;
        }

        public void Close()
        {
            _state = UIHandleState.Closing;
        }

        public void Closed(UIHideResult hideResult)
        {
            _state = UIHandleState.Closed;
            _closeSource.TrySetResult(hideResult);
        }

        public async UniTask<UIHideResult> WaitUntilClosedAsync()
        {
            return await _closeSource.Task.AttachExternalCancellation(_cancellationToken);
        }
    }
}