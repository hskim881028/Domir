using System.Collections.Generic;
using System.Linq;
using Domir.Client.Data.Repository;
using Unity.Netcode;

namespace Domir.Client.Contents.Services
{
    public class EntitySpawnService
    {
        private readonly NetworkManager _networkManager;
        private readonly UserRepository _userRepository;

        public EntitySpawnService(
            NetworkManager networkManager,
            UserRepository userRepository)
        {
            _networkManager = networkManager;
            _userRepository = userRepository;
        }

        public void Spawn()
        {
            var prefab = _networkManager.NetworkConfig.Prefabs.Prefabs.First().Prefab;
            if (prefab == null) return;

            var instance = UnityEngine.Object.Instantiate(prefab);
            var networkObject = instance.GetComponent<NetworkObject>();
            if (networkObject == null)
            {
                UnityEngine.Object.Destroy(instance);
                return;
            }

            networkObject.SpawnWithOwnership(_userRepository.Model.ClientId);
        }
    }
}