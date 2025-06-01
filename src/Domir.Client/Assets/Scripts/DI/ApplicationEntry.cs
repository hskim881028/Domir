using Cysharp.Threading.Tasks;
using Domir.Client.Contents.Command;
using Domir.Client.Contents.Services;
using Domir.Client.Contents.UI;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.Core.Command;
using Domir.Client.Core.Scope;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Contract;
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
            Debug.Log("LobbyEntry.constructor");
        }

        public void Start()
        {
            Debug.Log($"{GetType().Name} Started");
            _cameraService.SetColor(Color.antiqueWhite);
            _commandExecutor.Enqueue<Login>();
        }

        public void Tick()
        {
            _commandExecutor.TickAsync().Forget();
            InputTest();
        }

        private void InputTest()
        {
            if (Input.GetKeyDown(KeyCode.Z)) { }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                _navigation.ShowSystemUIAsync(SystemUIId.Popup, new PopupUIParam("t2", "test", "ok", "no", true));
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _navigation.HideSystemUIAsync(SystemUIId.Popup, UIResult.Close);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ShowStackUIAsync().Forget();
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                HideStackUIAsync().Forget();
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                ShowStatic(UILayer.Default).Forget();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                ShowStatic(UILayers.Minimap).Forget();
            }
        }

        private async UniTaskVoid ShowStatic(UILayer layer)
        {
            Debug.Log($"ShowStatic start");
            await _navigation.ApplyUILayer(layer);
            Debug.Log($"ShowStatic done");
        }

        private async UniTask ShowStackUIAsync()
        {
            Debug.Log("Show start");
            var handle = await _navigation.ShowStackUIAsync(StackUIId.Inventory);
            Debug.Log("Show End");
            var result = await handle.WaitUntilClosedAsync();
            Debug.Log($"Hide End : {result.State}");
        }

        private async UniTask HideStackUIAsync()
        {
            Debug.Log("HideStackUIAsync start");
            var handle = await _navigation.HideStackUIAsync(UIResult.Close);
            Debug.Log($"HideStackUIAsync End : {handle}");
        }
    }
}