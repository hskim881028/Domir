using Cysharp.Threading.Tasks;
using Domir.Client.Services;
using VContainer;

namespace Domir.Client.Contents.Command
{
    public abstract class LogicCommand : ILogicCommand
    {
        protected NetworkService NetworkService { get; private set; }

        [Inject]
        public void Construct(NetworkService networkService)
        {
            NetworkService = networkService;
        }

        public abstract UniTask<bool> ExecuteAsync();
        public abstract void Render();
    }
}