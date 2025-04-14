namespace Common.UI.Implementation
{
    public class UIHandleFactory : IUIHandleFactory
    {
        public IUIHandle Create()
        {
            return new UIHandle();
        }
    }
}