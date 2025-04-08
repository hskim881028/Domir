using Cysharp.Threading.Tasks;
using Domir.Client.Contents.Command;
using Domir.Client.Contents.Command.Implementation;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Entries
{
    public class LobbyEntry : IStartable, ITickable, IPostTickable
    {
        private readonly CommandExecutor _commandExecutor;
        private readonly CommandHandler _commandHandler;

        public LobbyEntry(CommandExecutor commandExecutor, CommandHandler commandHandler)
        {
            _commandExecutor = commandExecutor;
            _commandHandler = commandHandler;
        }

        public void Start()
        {
            Debug.Log($"{GetType().Name} Started");
            _commandHandler.Execute<Login>();
        }

        public void Tick()
        {
            _commandExecutor.UpdateInputAsync().Forget();
        }

        public void PostTick()
        {
            _commandExecutor.UpdateLogicAsync().Forget();
        }
    }
}