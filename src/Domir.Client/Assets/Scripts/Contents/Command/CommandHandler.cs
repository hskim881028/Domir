using VContainer;

namespace Domir.Client.Contents.Command
{
    public sealed class CommandHandler
    {
        private readonly IObjectResolver _resolver;
        private readonly CommandExecutor _executor;

        public CommandHandler(IObjectResolver resolver, CommandExecutor executor)
        {
            _resolver = resolver;
            _executor = executor;
        }

        public void ExecuteInput<T>() where T : IInputCommand
        {
            var command = _resolver.Resolve<T>();
            _executor.Enqueue(command);
        }

        public void Execute<T>() where T : ILogicCommand
        {
            var command = _resolver.Resolve<T>();
            _executor.Enqueue(command);
        }
    }
}