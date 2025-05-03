using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;
using Domir.Client.Common.UI.Core.Navigation;
using Domir.Client.Common.UI.Core.Presenter;
using Domir.Client.Common.UI.Core.State;
using Domir.Client.Common.UI.Implementation.Presenter;
using Domir.Client.Contents.UI;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.SceneManagement;
using Domir.Client.Services;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Entries
{
    public class ApplicationEntry : IStartable, ITickable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly NetworkService _networkService;
        private readonly InputService _inputService;
        private readonly IUINavigation _navigation;

        public ApplicationEntry(
            SceneLoader sceneLoader,
            NetworkService networkService,
            InputService inputService,
            IUINavigation navigation)
        {
            _networkService = networkService;
            _inputService = inputService;
            _navigation = navigation;
            _sceneLoader = sceneLoader;
        }

        public void Start()
        {
            // _networkService.Connect();
            // _sceneLoader.LoadAsync("Lobby");
        }

        private async UniTaskVoid ShowStatic(UILayer layer)
        {
            Debug.Log($"ShowStatic start");
            await _navigation.ApplyUILayer(layer);
            Debug.Log($"ShowStatic done");
        }

        private async UniTask Test()
        {
            Debug.Log("Show start");
            // var handle = await _navigation.ShowAsync(SystemUIId.NetworkWaiting);
            var handle = await _navigation.ShowSystemUIAsync(SystemUIId.Popup, new PopupUIParam("t", "test", "ok", "no", true));
            Debug.Log("Show End");
            await handle.WaitUntilClosedAsync();
            Debug.Log("Hide End");
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

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Test().Forget();
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
                ShowStatic(UILayers.Test).Forget();
            }
        }
    }
}