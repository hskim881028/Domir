﻿using Cysharp.Threading.Tasks;

namespace Domir.Client.Contents.Command
{
    public sealed class StartHost : LogicCommand
    {
        public override UniTask<bool> ExecuteAsync()
        {
            return UniTask.FromResult(NetworkService.StartHost());
        }

        public override UniTask PostExecuteAsync()
        {
            return UniTask.FromResult(true);
        }
    }
}