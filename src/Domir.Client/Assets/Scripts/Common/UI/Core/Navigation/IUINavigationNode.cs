using System;
using System.Threading;
using Domir.Client.Common.UI.Core.Contract;

namespace Domir.Client.Common.UI.Core.Navigation
{
    public interface IUINavigationNode : IDisposable
    {
        public UIId Id { get; }
        public CancellationToken Token { get; }
        public void Reset(UIId id);
        public IUIHandle Opened();
        public void Closed(UIResult result);
    }
}