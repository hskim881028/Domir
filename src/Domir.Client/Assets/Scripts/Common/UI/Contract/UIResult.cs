﻿using Domir.Client.Common.UI.State;

namespace Domir.Client.Common.UI.Contract
{
    public record UIResult(UIResultState State)
    {
        public static UIResult Ok => new(UIResultState.Ok);
        public static UIResult Cancel => new(UIResultState.Cancel);
        public static UIResult Close => new(UIResultState.Close);
        public static UIResult Failure => new(UIResultState.Failure);
    }
}