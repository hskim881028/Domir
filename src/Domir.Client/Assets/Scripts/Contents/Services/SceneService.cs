using System;
using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.Messages;
using Domir.Client.Data.Store;
using MessagePipe;
using R3;
using Unity.Netcode;
using UnityEngine;
using DisposableBag = R3.DisposableBag;
using Object = UnityEngine.Object;

namespace Domir.Client.Contents.Services
{
    public sealed class SceneService
    {
        private readonly NetworkService _networkService;
        private readonly UserStore _userStore;
        private readonly DisposableBag _disposable;

        public SceneService(
            NetworkService networkService,
            UserStore userStore,
            ISubscriber<SceneScopeMessage> subscriber)
        {
            _networkService = networkService;
            _userStore = userStore;
            subscriber.Subscribe(OnSceneScopeMessage).AddTo(ref _disposable);
        }

        private void OnSceneScopeMessage(SceneScopeMessage message)
        {
            switch (message.Type)
            {
                case SceneScopeMessageType.Unload:
                    break;
                case SceneScopeMessageType.Load:
                    this.Log(1);
                    if (_userStore.ClientId > 0) return;

                    this.Log(2);
                    if (_networkService.TryGetScene(message.SceneScope.Id, out var scene))
                    {
                        this.Log(3);
                        var instance = Object.Instantiate(scene);
                        var networkObject = instance.GetComponent<NetworkObject>();
                        networkObject.TrySetParent(message.SceneScope.transform);
                        networkObject.SpawnWithOwnership(_userStore.ClientId);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}