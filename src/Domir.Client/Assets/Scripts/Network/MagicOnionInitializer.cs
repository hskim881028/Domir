﻿using Cysharp.Net.Http;
using Grpc.Net.Client;
using MagicOnion.Unity;
using UnityEngine;

namespace Domir.Client.Network
{
    public class MagicOnionInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void OnRuntimeInitialize()
        {
            GrpcChannelProviderHost.Initialize(new DefaultGrpcChannelProvider(() => new GrpcChannelOptions
            {
                HttpHandler = new YetAnotherHttpHandler
                {
                    Http2Only = true,
                },
                DisposeHttpClient = true,
            }));
        }
    }
}