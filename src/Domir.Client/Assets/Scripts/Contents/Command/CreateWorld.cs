using Cysharp.Threading.Tasks;
using Domir.Client.Contents.UI;
using Domir.Client.Core.Scope;

namespace Domir.Client.Contents.Command
{
    public sealed class CreateWorld : LogicCommand
    {
        public override UniTask<bool> ExecuteAsync()
        {
            SceneScopeManager.LoadScope(SceneScopeId.World);
            EntitySpawnService.Spawn();
            return UniTask.FromResult(true);
        }

        public override async UniTask PostExecuteAsync()
        {
            await UINavigation.ApplyUILayer(UILayers.Default);
        }
    }
}