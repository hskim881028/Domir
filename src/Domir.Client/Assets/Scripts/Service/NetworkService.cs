using System;
using Domir.Client.Network;
using MagicOnion;

namespace Domir.Client.Service
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
    }
}