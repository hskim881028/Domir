namespace Common.UI.Implementation
{
    public record UIResult(UIResultStatus Status)
    {
        public static UIResult OK => new(UIResultStatus.Ok);
        public static UIResult Cancel => new(UIResultStatus.Cancel);
        public static UIResult Success => new(UIResultStatus.Success);
        public static UIResult Failure => new(UIResultStatus.Failure);
    }
}