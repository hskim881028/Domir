namespace Domir.Client.Common.UI.Core.Contract
{
    public record UIShowResult(bool IsSuccess, IUIHandle Handle)
    {
        public static UIShowResult Success(IUIHandle handle) => new(true, handle);
        public static UIShowResult Failure => new(false, null);
    }
}