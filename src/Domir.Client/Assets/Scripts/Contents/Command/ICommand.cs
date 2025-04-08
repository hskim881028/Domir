using Cysharp.Threading.Tasks;

namespace Domir.Client.Contents.Command
{
    public interface ICommand
    {
        public UniTask<bool> ExecuteAsync();
    }
}