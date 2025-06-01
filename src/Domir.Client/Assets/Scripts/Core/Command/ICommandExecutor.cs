using Cysharp.Threading.Tasks;

namespace Domir.Client.Core.Command
{
    public interface ICommandExecutor
    {
        public void Enqueue<T>() where T : ILogicCommand;
        public UniTask TickAsync();
    }
}