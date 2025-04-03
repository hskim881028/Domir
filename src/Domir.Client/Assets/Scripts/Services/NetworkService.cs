using System;
using Domir.Client.Network;
using Domir.Shared.Response;
using MagicOnion;

namespace Domir.Client.Services
{
    public class NetworkService
    {
        private readonly INetworkConnection _networkConnection;

        public NetworkService(INetworkConnection networkConnection)
        {
            _networkConnection = networkConnection;
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