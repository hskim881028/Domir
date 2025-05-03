using System.Threading;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;

namespace Domir.Client.Common.UI.Implementation
{
    public class UINavigationNode : IUINavigationNode
    {
        public UIId Id { get; private set; }
        public CancellationToken Token => _cts.Token;

        private readonly IUIHandle _handle;
        private CancellationTokenSource _cts = new();
        private bool _isDisposed;

        public UINavigationNode(UIId id, IUIHandle handle)
        {
            _handle = handle;
            Reset(id);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;
            _cts.Cancel();
            _cts.Dispose();
            _handle.Dispose();
        }

        public void Reset(UIId id)
        {
            ResetCancellationTokenSource();
            Id = id;
            _handle.Reset(Token);
        }

        public void Open()
        {
            _handle.Open();
        }

        public IUIHandle Opened()
        {
            _handle.Opened();
            return _handle;
        }

        public void Close()
        {
            _handle.Close();
        }

        public void Closed(UIHideResult hideResult)
        {
            _handle.Closed(hideResult);
        }

        private void ResetCancellationTokenSource()
        {
            if (_isDisposed)
            {
                return;
            }

            _cts.Cancel();
            _cts.Dispose();
            _cts = new CancellationTokenSource();
        }
    }
}