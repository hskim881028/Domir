using System;
using Cysharp.Threading.Tasks;
using Domir.Client.Service;
using Domir.Shared;
using Domir.Shared.Service;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Entry
{
    public class LobbyEntry : IStartable
    {
        private readonly Lazy<IMyFirstService> _myFirstService;
        private readonly Lazy<ILoginService> _loginService;

        public LobbyEntry(NetworkService networkService)
        {
            _myFirstService = networkService.CreateService<IMyFirstService>();
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
                var result = await _myFirstService.Value.SumAsync(100, 200);
                Debug.Log($"100 + 200 = {result}");
                var response = await _loginService.Value.Login();
                Debug.Log($"[response.ResponseCode]: {response.ResponseCode}");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}