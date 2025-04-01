using System;
using Domir.Shared;
using MagicOnion;
using MagicOnion.Client;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public class Lobby : LifetimeScope
    {
        private IMyFirstService _service;

        private async void Start()
        {
            try
            {
                var channel = GrpcChannelx.ForAddress("http://localhost:5000");
                _service = MagicOnionClient.Create<IMyFirstService>(channel);

                var result = await _service.SumAsync(100, 200);
                Debug.Log($"100 + 200 = {result}");
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}