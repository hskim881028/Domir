using System;
using Cysharp.Threading.Tasks;
using Domir.Client.Core.Scope;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Services;
using VContainer;

namespace Domir.Client.Contents.Command
{
    public abstract class LogicCommand : ILogicCommand, IDisposable
    {
        protected NetworkService NetworkService { get; private set; }
        protected ISceneScopeManager SceneScopeManager { get; private set; }
        protected IUINavigation UINavigation { get; private set; }


        [Inject]
        public void Construct(
            NetworkService networkService,
            ISceneScopeManager sceneScopeManager,
            IUINavigation navigation)
        {
            NetworkService = networkService;
            SceneScopeManager = sceneScopeManager;
            UINavigation = navigation;
        }

        public abstract UniTask<bool> ExecuteAsync();
        public abstract UniTaskVoid PostExecuteAsync();
        public void Dispose() { }
    }
}