using System;
using Domir.Client.Common.UI.Core;

namespace Domir.Client.Common.UI.Navigation
{
    public interface IUINavigationNodePool : IDisposable
    {
        public IUINavigationNode Get(UIId id);
        public void Return(IUINavigationNode node);
    }
}