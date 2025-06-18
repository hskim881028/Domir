using System;
using Domir.Client.Core.UI;

namespace Domir.Client.Core.UI.Navigation
{
    public interface IUINavigationNodePool : IDisposable
    {
        public IUINavigationNode Get(UIId id);
        public void Return(IUINavigationNode node);
    }
}