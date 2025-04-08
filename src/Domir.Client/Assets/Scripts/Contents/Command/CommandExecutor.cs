using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace Domir.Client.Contents.Command
{
    public sealed class CommandExecutor
    {
        private readonly Queue<IInputCommand> _inputCommands = new();
        private readonly Queue<ILogicCommand> _logicCommands = new();
        private bool _isExecutingInput;
        private bool _isExecutingLogic;

        public void Enqueue(IInputCommand command)
        {
            _inputCommands.Enqueue(command);
        }

        public void Enqueue(ILogicCommand command)
        {
            _logicCommands.Enqueue(command);
        }

        public async UniTask UpdateInputAsync()
        {
            if (_isExecutingInput)
            {
                return;
            }

            _isExecutingInput = true;

            while (_inputCommands.Count > 0)
            {
                var action = _inputCommands.Dequeue();
                await action.ExecuteAsync();
            }

            _isExecutingInput = false;
        }

        public async UniTask UpdateLogicAsync()
        {
            if (_isExecutingLogic)
            {
                return;
            }

            _isExecutingLogic = true;

            while (_logicCommands.Count > 0)
            {
                var action = _logicCommands.Dequeue();
                var isSuccess = await action.ExecuteAsync();
                if (isSuccess)
                {
                    action.Render();
                }
            }

            _isExecutingLogic = false;
        }
    }
}