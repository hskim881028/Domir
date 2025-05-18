using Domir.Client.Core.Scope;

namespace Domir.Client.Core.Messages
{
    public readonly struct SceneScopeMessage
    {
        public SceneScopeMessageType Type { get; }
        public SceneScope SceneScope { get; }

        private SceneScopeMessage(SceneScopeMessageType type)
        {
            Type = type;
            SceneScope = null;
        }

        private SceneScopeMessage(SceneScopeMessageType type, SceneScope sceneScope)
        {
            Type = type;
            SceneScope = sceneScope;
        }

        public static SceneScopeMessage Load(SceneScope sceneScope) => new(SceneScopeMessageType.Load, sceneScope);
        public static SceneScopeMessage Unload => new(SceneScopeMessageType.Unload);
    }
}