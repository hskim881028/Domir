using System;
using Domir.Client.Contents.Command;
using Domir.Client.Core.Command;
using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.Scene;
using Domir.Client.Core.Scope;
using Domir.Client.Data.Model;
using Domir.Client.Data.Repository;
using Domir.Client.Data.Store;
using Domir.Client.Network;
using Domir.Shared.Response;
using MagicOnion;
using Unity.Netcode;

namespace Domir.Client.Contents.Services
{
    public sealed class NetworkService : IDisposable
    {
        private readonly INetworkConnection _networkConnection;
        private readonly NetworkManager _networkManager;
        private readonly ICommandExecutor _commandExecutor;
        private readonly UserRepository _repository;
        private readonly UserStore _userStore;
        private bool _isDisposed;

        public NetworkService(
            INetworkConnection networkConnection,
            NetworkManager networkManager,
            ICommandExecutor commandExecutor,
            UserRepository repository,
            UserStore userStore)
        {
            _networkConnection = networkConnection;
            _networkManager = networkManager;
            _commandExecutor = commandExecutor;
            _networkManager.OnConnectionEvent += OnConnectionEvent;
            _networkManager.OnServerStarted += OnServerStarted;
            _repository = repository;
            _userStore = userStore;
        }

        public bool TryGetScene(SceneScopeId id, out SceneNetworkBehaviour scene)
        {
            scene = null;
            if (!_networkManager.IsServer) return false;

            var prefabs = _networkManager.NetworkConfig.Prefabs.Prefabs;
            foreach (var prefab in prefabs)
            {
                if (!prefab.Prefab.TryGetComponent<SceneNetworkBehaviour>(out var component)) continue;

                if (component.Id != id) continue;

                scene = component;
                return true;
            }

            return false;
        }

        public void Connect()
        {
            _networkConnection.Connect();
        }

        public Lazy<T> CreateService<T>() where T : IService<T>
        {
            return _networkConnection.CreateService<T>();
        }

        public bool HandleResponse(IResponse response)
        {
            return _networkConnection.HandleResponse(response);
        }

        public bool StartHost()
        {
            return _networkManager.StartHost();
        }

        public bool StartClient()
        {
            return _networkManager.StartClient();
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            _isDisposed = true;
            _networkManager.OnConnectionEvent -= OnConnectionEvent;
            _networkManager.OnServerStarted -= OnServerStarted;
        }

        private void OnServerStarted()
        {
            this.Log();
        }

        private void OnConnectionEvent(NetworkManager networkManager, ConnectionEventData connectionEventData)
        {
            switch (connectionEventData.EventType)
            {
                case ConnectionEvent.ClientConnected: // host와 본인만 알려줌 들어오는 순으로 0, 1, 2
                    if (networkManager.IsHost)
                    {
                        _repository.Update(new UserModel(connectionEventData.ClientId, connectionEventData.ClientId == 0));
                    }

                    _userStore.ClientId = networkManager.LocalClientId;
                    if (networkManager.LocalClientId == connectionEventData.ClientId)
                    {
                        _commandExecutor.Enqueue<JoinWorld>();
                    }

                    break;

                case ConnectionEvent.PeerConnected:
                case ConnectionEvent.ClientDisconnected:
                case ConnectionEvent.PeerDisconnected:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.Log("-------------");
            this.Log(connectionEventData.EventType.ToString());
            this.Log($"local :{networkManager.LocalClientId}");
            this.Log($"ClientId :{connectionEventData.ClientId} / {networkManager.IsHost}");
        }
    }
}