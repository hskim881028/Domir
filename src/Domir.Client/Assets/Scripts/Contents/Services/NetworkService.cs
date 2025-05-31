using System;
using System.Linq;
using Domir.Client.Contents.Command;
using Domir.Client.Core.Command;
using Domir.Client.Core.Infrastructure;
using Domir.Client.Data.Model;
using Domir.Client.Data.Repository;
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

        public NetworkService(
            INetworkConnection networkConnection,
            NetworkManager networkManager,
            ICommandExecutor commandExecutor,
            UserRepository repository)
        {
            _networkConnection = networkConnection;
            _networkManager = networkManager;
            _commandExecutor = commandExecutor;
            _networkManager.OnConnectionEvent += OnConnectionEvent;
            _networkManager.OnServerStarted += OnServerStarted;
            _repository = repository;
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
            _networkManager.OnConnectionEvent -= OnConnectionEvent;
            _networkManager.OnServerStarted -= OnServerStarted;
        }

        private void OnConnectionEvent(NetworkManager networkManager, ConnectionEventData connectionEventData)
        {
            if (!_networkManager.IsHost) return;

            switch (connectionEventData.EventType)
            {
                case ConnectionEvent.ClientConnected:
                    _repository.Update(new UserModel(connectionEventData.ClientId, _networkManager.IsHost));
                    _commandExecutor.Enqueue<JoinWorld>();
                    break;
                case ConnectionEvent.PeerConnected:
                    break;
                case ConnectionEvent.ClientDisconnected:
                    break;
                case ConnectionEvent.PeerDisconnected:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.Log(_networkManager.IsHost);
            this.Log(connectionEventData.ClientId);
            this.Log(connectionEventData.EventType.ToString());
        }

        private void OnServerStarted()
        {
            this.Log();
        }
    }
}