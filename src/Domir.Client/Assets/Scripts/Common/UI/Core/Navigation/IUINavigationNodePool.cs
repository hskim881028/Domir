using System;

namespace Domir.Client.Common.UI.Core.Navigation
{
    public interface IUINavigationNodePool : IDisposable
    {
        public IUINavigationNode Get(UIId id);
        public void Return(IUINavigationNode node);
    }
}