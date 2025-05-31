using Cysharp.Threading.Tasks;

namespace Domir.Client.Contents.Command
{
    public sealed class StartClient : LogicCommand
    {
        public override UniTask<bool> ExecuteAsync()
        {
            return UniTask.FromResult(NetworkService.StartClient());
        }

        public override UniTask PostExecuteAsync()
        {
            return UniTask.FromResult(true);
        }
    }
}