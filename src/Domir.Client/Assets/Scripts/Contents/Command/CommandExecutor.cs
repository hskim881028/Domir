using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Domir.Client.Core.Command;
using UnityEngine;
using VContainer;

namespace Domir.Client.Contents.Command
{
    public sealed class CommandExecutor : ICommandExecutor, IDisposable
    {
        private readonly IObjectResolver _resolver;
        private readonly Queue<ILogicCommand> _commands = new();
        private bool _isExecuting;

        public CommandExecutor(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public void Enqueue<T>() where T : ILogicCommand
        {
            var command = _resolver.Resolve<T>();
            _commands.Enqueue(command);
        }

        public async UniTask TickAsync()
        {
            if (_isExecuting)
            {
                return;
            }

            _isExecuting = true;

            while (_commands.Count > 0)
            {
                var action = _commands.Dequeue();
                var isSuccess = await action.ExecuteAsync();
                if (isSuccess)
                {
                    action.PostExecuteAsync().Forget();
                }
            }

            _isExecuting = false;
        }

        public void Dispose()
        {
            Debug.Log("command disposed");
            _resolver?.Dispose();
        }
    }
}