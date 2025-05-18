using System;

namespace Domir.Client.Core.Scope
{
    public interface ISceneScopeManager : IDisposable
    {
        public void LoadScope(string scopeName);
    }
}