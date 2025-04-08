using Cysharp.Threading.Tasks;
using Domir.Shared.Services;
using UnityEngine;

namespace Domir.Client.Contents.Command.Implementation
{
    public class Login : LogicCommand
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

        public override void Render()
        {
        }
    }
}