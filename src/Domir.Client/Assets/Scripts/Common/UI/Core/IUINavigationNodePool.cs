namespace Domir.Client.Common.UI.Core
{
    public interface IUINavigationNodePool
    {
        public IUINavigationNode Get(UIId id);
        public void Return(IUINavigationNode node);
    }
}