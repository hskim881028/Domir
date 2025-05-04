using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Contract;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Navigation;
using Domir.Client.Contents.Command;
using Domir.Client.Contents.Command.Implementation;
using Domir.Client.Contents.UI;
using Domir.Client.Contents.UI.Generated;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Entries
{
    public class LobbyEntry : IStartable, ITickable, IPostTickable
    {
        private readonly CommandExecutor _commandExecutor;
        private readonly CommandHandler _commandHandler;
        private readonly IUINavigation _navigation;

        public LobbyEntry(
            CommandExecutor commandExecutor,
            CommandHandler commandHandler,
            IUINavigation navigation)
        {
            _commandExecutor = commandExecutor;
            _commandHandler = commandHandler;
            _navigation = navigation;
        }

        public void Start()
        {
            Debug.Log($"{GetType().Name} Started");
            _commandHandler.Execute<Login>();
        }

        public void Tick()
        {
            _commandExecutor.UpdateInputAsync().Forget();
            InputTest();
        }

        public void PostTick()
        {
            _commandExecutor.UpdateLogicAsync().Forget();
        }

        private void InputTest()
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
    }
}