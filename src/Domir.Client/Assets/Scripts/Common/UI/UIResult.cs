namespace Common.UI
{
    public class UIResult : IUIResult
    {
        public UIResultStatus Status { get; }

        public UIResult(UIResultStatus status)
        {
            Status = status;
        }
    }
}