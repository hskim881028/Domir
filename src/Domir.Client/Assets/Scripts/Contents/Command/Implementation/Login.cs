using Cysharp.Threading.Tasks;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.Core.UI.Contract;
using Domir.Shared.Services;
using UnityEngine;

namespace Domir.Client.Contents.Command.Implementation
{
    public sealed class Login : LogicCommand
    {
        public Login()
        {
            Debug.Log("Login");
        }

        public override async UniTask<bool> ExecuteAsync()
        {
            var loginService = NetworkService.CreateService<ILoginService>();
            var response = await loginService.Value.Login();
            if (!NetworkService.HandleResponse(response)) return false;

            Debug.Log($"[StatusCode]: {response.StatusCode}");
            return true;
        }

        public override async UniTaskVoid PostExecuteAsync()
        {
            Debug.Log("Show start");
            // var handle = await _navigation.ShowAsync(SystemUIId.NetworkWaiting);
            SceneScopeManager.LoadScope("Lobby");
            var handle = await UINavigation.ShowSystemUIAsync(SystemUIId.Popup, new PopupUIParam("t", "test", "ok", "no", true));
            Debug.Log("Show End");
            await handle.WaitUntilClosedAsync();
            Debug.Log("Hide End");
        }
    }
}