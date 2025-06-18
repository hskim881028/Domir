using System;
using Cysharp.Threading.Tasks;
using Domir.Client.Contents.Services;
using Domir.Client.Core.Command;
using Domir.Client.Core.Scope;
using Domir.Client.Core.UI.Navigation;
using VContainer;

namespace Domir.Client.Contents.Command
{
    public abstract class LogicCommand : ILogicCommand, IDisposable
    {
        protected ISceneScopeManager SceneScopeManager { get; private set; }
        protected NetworkService NetworkService { get; private set; }
        protected EntitySpawnService EntitySpawnService { get; private set; }
        protected IUINavigation UINavigation { get; private set; }


        [Inject]
        public void Construct(
            ISceneScopeManager sceneScopeManager,
            NetworkService networkService,
            EntitySpawnService entitySpawnService,
            IUINavigation navigation)
        {
            SceneScopeManager = sceneScopeManager;
            NetworkService = networkService;
            EntitySpawnService = entitySpawnService;
            UINavigation = navigation;
        }

        public abstract UniTask<bool> ExecuteAsync();
        public abstract UniTask PostExecuteAsync();
        public void Dispose() { }
    }
}