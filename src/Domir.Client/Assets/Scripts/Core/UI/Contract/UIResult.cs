﻿using Domir.Client.Core.UI.State;

namespace Domir.Client.Core.UI.Contract
{
    public record UIResult(UIResultState State)
    {
        public static UIResult Ok => new(UIResultState.Ok);
        public static UIResult Cancel => new(UIResultState.Cancel);
        public static UIResult Close => new(UIResultState.Close);
        public static UIResult Failure => new(UIResultState.Failure);
    }
}