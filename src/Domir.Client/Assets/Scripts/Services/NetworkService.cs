using System;
using Domir.Client.Network;
using Domir.Shared.Response;
using MagicOnion;
using Unity.Netcode;

namespace Domir.Client.Services
{
    public class NetworkService
    {
        private readonly INetworkConnection _networkConnection;
        private readonly NetworkManager _networkManager;

        public NetworkService(INetworkConnection networkConnection, NetworkManager networkManager)
        {
            _networkConnection = networkConnection;
            _networkManager = networkManager;
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
    }
}