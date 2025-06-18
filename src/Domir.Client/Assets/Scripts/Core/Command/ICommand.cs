using Cysharp.Threading.Tasks;

namespace Domir.Client.Core.Command
{
    public interface ICommand
    {
        public UniTask<bool> ExecuteAsync();
    }
}