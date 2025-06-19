using Cysharp.Threading.Tasks;
using Domir.Client.Contents.UI;
using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.Scope;

namespace Domir.Client.Contents.Command
{
    public sealed class JoinWorld : LogicCommand
    {
        public override UniTask<bool> ExecuteAsync()
        {
            this.Log();
            SceneScopeManager.LoadScope(SceneScopeId.World);
            return UniTask.FromResult(true);
        }

        public override async UniTask PostExecuteAsync()
        {
            await UINavigation.ApplyUILayer(UILayers.Default);
        }
    }
}