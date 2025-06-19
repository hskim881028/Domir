using Domir.Client.Core.Entity;
using Domir.Client.Core.Infrastructure;
using UnityEngine;

namespace Domir.Client.Contents.Entity
{
    public class CharacterView : EntityView
    {
        public override void OnNetworkSpawn()
        {
            this.Log(IsClient);
            this.Log(OwnerClientId);
            base.OnNetworkSpawn();

            var color = OwnerClientId == 0 ? Color.green : Color.blueViolet;
            GetComponent<SpriteRenderer>().color = color;
        }
    }
}