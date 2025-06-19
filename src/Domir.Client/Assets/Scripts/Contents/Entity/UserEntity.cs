using Domir.Client.Core.Infrastructure;
using Unity.Netcode;
using UnityEngine;

namespace Domir.Client.Contents.Entity
{
    public class UserEntity : NetworkBehaviour
    {
        public override void OnNetworkSpawn()
        {
            this.Log(IsClient);
            this.Log(OwnerClientId);
            base.OnNetworkSpawn();

            var color = OwnerClientId == 0
                ? Color.green
                : Color.blueViolet;
            GetComponent<SpriteRenderer>().color = color;
        }
    }
}