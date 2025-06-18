using Cysharp.Threading.Tasks;
using Domir.Client.Contents.UI;
using Domir.Client.Core.Scope;
using Domir.Shared.Services;
using UnityEngine;

namespace Domir.Client.Contents.Command
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
            SceneScopeManager.LoadScope(SceneScopeId.Lobby);
            return true;
        }

        public override async UniTask PostExecuteAsync()
        {
            Debug.Log("Show start");
            // var handle = await _navigation.ShowAsync(SystemUIId.NetworkWaiting);
            await UINavigation.ApplyUILayer(UILayers.Login);
        }
    }
}