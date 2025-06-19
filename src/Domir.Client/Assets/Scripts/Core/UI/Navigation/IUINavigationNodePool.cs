using System;

namespace Domir.Client.Core.UI.Navigation
{
    public interface IUINavigationNodePool : IDisposable
    {
        public IUINavigationNode Get(UIId id);
        public void Return(IUINavigationNode node);
    }
}