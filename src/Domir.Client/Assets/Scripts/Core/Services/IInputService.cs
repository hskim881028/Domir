using System;

namespace Domir.Client.Core.Services
{
    public interface IInputService
    {
        void RegisterScopeControls(Action loadScope, Action unloadScope);
    }
} 