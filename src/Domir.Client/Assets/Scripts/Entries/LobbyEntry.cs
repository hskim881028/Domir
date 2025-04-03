using System;
using Cysharp.Threading.Tasks;
using Domir.Client.Services;
using Domir.Shared.Services;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Entries
{
    public class LobbyEntry : IStartable
    {
        private readonly Lazy<ILoginService> _loginService;
        private readonly NetworkService _networkService;

        public LobbyEntry(NetworkService networkService)
        {
            _networkService = networkService;
            _loginService = networkService.CreateService<ILoginService>();
        }

        public void Start()
        {
            Debug.Log($"{GetType().Name} Started");
            Test().Forget();
        }

        private async UniTaskVoid Test()
        {
            try
            {
                var response = await _loginService.Value.Login();
                if (_networkService.HandleResponse(response)) Debug.Log($"[StatusCode]: {response.StatusCode}");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}