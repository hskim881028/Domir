using Domir.Client.Common.UI.Core.State;

namespace Domir.Client.Common.UI.Core.Contract
{
    public record UIHideResult(UIResultState State)
    {
        public static UIHideResult Ok => new(UIResultState.Ok);
        public static UIHideResult Cancel => new(UIResultState.Cancel);
        public static UIHideResult Close => new(UIResultState.Close);
        public static UIHideResult Failure => new(UIResultState.Failure);
    }
}