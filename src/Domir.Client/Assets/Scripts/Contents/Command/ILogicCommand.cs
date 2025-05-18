using Cysharp.Threading.Tasks;

namespace Domir.Client.Contents.Command
{
    public interface ILogicCommand : ICommand
    {
        public UniTaskVoid PostExecuteAsync();
    }
}