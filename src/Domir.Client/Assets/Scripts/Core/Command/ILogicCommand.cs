using Cysharp.Threading.Tasks;

namespace Domir.Client.Core.Command
{
    public interface ILogicCommand : ICommand
    {
        public UniTask PostExecuteAsync();
    }
}