using Cysharp.Threading.Tasks;

namespace Domir.Client.Core.Command
{
    public interface ICommandExecutor
    {
        public void Enqueue<T>() where T : ILogicCommand;
        public void Enqueue(IInputCommand command);
        public void Enqueue(ILogicCommand command);
        public UniTask UpdateInputAsync();
        public UniTask UpdateLogicAsync();
    }
}