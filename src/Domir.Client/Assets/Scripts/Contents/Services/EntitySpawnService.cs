using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Domir.Client.Data.Model;
using Domir.Client.Data.Repository;
using ObservableCollections;
using Unity.Netcode;
using Object = UnityEngine.Object;

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
            _userRepository.Models.CollectionChanged += Test;
        }

        private void Test(in NotifyCollectionChangedEventArgs<KeyValuePair<string, UserModel>> args)
        {
            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Spawn()
        {
            var prefab = _networkManager.NetworkConfig.Prefabs.Prefabs.First().Prefab;
            if (prefab == null) return;

            var instance = Object.Instantiate(prefab);
            var networkObject = instance.GetComponent<NetworkObject>();
            if (networkObject == null)
            {
                Object.Destroy(instance);
                return;
            }

            if (_userRepository.TryGet(0, out var userModel))
            {
                networkObject.SpawnWithOwnership(userModel.ClientId);
            }
        }
    }
}