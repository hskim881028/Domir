using Cysharp.Threading.Tasks;
using Domir.Client.Contents.Command;
using Domir.Client.Contents.Services;
using Domir.Client.Core.Command;
using Domir.Client.Core.Scope;
using Domir.Client.Core.UI.Navigation;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public sealed class ApplicationEntry : IStartable, ITickable
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IUINavigation _navigation;
        private readonly CameraService _cameraService;

        public ApplicationEntry(
            NetworkService networkService,
            EntitySpawnService entitySpawnService,
            ICommandExecutor commandExecutor,
            InputService inputService,
            IUINavigation navigation,
            ISceneScopeManager sceneScopeManager,
            SceneService sceneService,
            CameraService cameraService)
        {
            networkService.Connect();
            _commandExecutor = commandExecutor;
            _navigation = navigation;
            _cameraService = cameraService;
        }

        public void Start()
        {
            _cameraService.SetColor(Color.antiqueWhite);
            _commandExecutor.Enqueue<Login>();
        }

        public void Tick()
        {
            _commandExecutor.TickAsync().Forget();
        }
    }
}