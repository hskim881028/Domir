using Cysharp.Threading.Tasks;
using Domir.Client.Contents.UI;
using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.Scope;
using Domir.Shared.Services;

namespace Domir.Client.Contents.Command
{
    public sealed class Login : LogicCommand
    {
        public Login()
        {
            this.Log("Login");
        }

        public override async UniTask<bool> ExecuteAsync()
        {
            var loginService = NetworkService.CreateService<ILoginService>();
            var response = await loginService.Value.Login();
            if (!NetworkService.HandleResponse(response)) return false;

            this.Log($"[StatusCode]: {response.StatusCode}");
            SceneScopeManager.LoadScope(SceneScopeId.Lobby);
            return true;
        }

        public override async UniTask PostExecuteAsync()
        {
            // TODO: Need to implement
            // var handle = await _navigation.ShowAsync(SystemUIId.NetworkWaiting);
            await UINavigation.ApplyUILayer(UILayers.Login);
        }
    }
}