using System;
using System.Threading;
using Domir.Client.Common.UI.Core.Contract;

namespace Domir.Client.Common.UI.Core
{
    public interface IUINavigationNode : IDisposable
    {
        public UIId Id { get; }
        public CancellationToken Token { get; }
        public void Reset(UIId id);
        public void Open();
        public IUIHandle Opened();
        public void Close();
        public void Closed(UIHideResult hideResult);
    }
}