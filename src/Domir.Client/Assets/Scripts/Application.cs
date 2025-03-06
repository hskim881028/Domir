using System;
using Domir.Shared;
using MagicOnion;
using MagicOnion.Client;
using UnityEngine;

public class Application : MonoBehaviour
{
    private IMyFirstService service;

    private async void Start()
    {
        try
        {
            var channel = GrpcChannelx.ForAddress("http://localhost:5000");
            service = MagicOnionClient.Create<IMyFirstService>(channel);

            var result = await service.SumAsync(100, 200);
            Debug.Log($"100 + 200 = {result}");
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
    }
}