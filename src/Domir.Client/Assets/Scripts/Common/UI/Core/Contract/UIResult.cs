using Domir.Client.Common.UI.Core.State;

namespace Domir.Client.Common.UI.Core.Contract
{
    public record UIResult(UIResultState State)
    {
        public static UIResult Ok => new(UIResultState.Ok);
        public static UIResult Cancel => new(UIResultState.Cancel);
        public static UIResult Close => new(UIResultState.Close);
        public static UIResult Failure => new(UIResultState.Failure);
    }
}