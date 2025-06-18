using Domir.Client.Core.Scope;
using Unity.Netcode;

namespace Domir.Client.Core.Scene
{
    public abstract class SceneNetworkBehaviour : NetworkBehaviour
    {
        public abstract SceneScopeId Id { get; }
    }
}