using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.Scene;
using Domir.Client.Core.Scope;
using Unity.Netcode;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Domir.Client.Contents.Scene
{
    public sealed class World : SceneNetworkBehaviour
    {
        public override SceneScopeId Id => SceneScopeId.World;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (IsClient)
                {
                    PingRpc(Random.Range(0, 100));
                }
            }
        }

        [Rpc(SendTo.Server)]
        private void PingRpc(int pingCount)
        {
            this.Log(pingCount);
            PongRpc(pingCount, "PONG!");
        }

        [Rpc(SendTo.ClientsAndHost)]
        private void PongRpc(int pingCount, string message)
        {
            this.Log($"Received pong from server for ping {pingCount} and message {message}");
        }
    }
}