using Cysharp.Threading.Tasks;
using Domir.Client.Contents.UI.Generated;
using UnityEngine;

namespace Domir.Client.Contents.Command.Implementation
{
    public class OnClickTester : LogicCommand
    {
        public override UniTask<bool> ExecuteAsync()
        {
            return new UniTask<bool>(true);
        }

        public override async UniTaskVoid PostExecuteAsync()
        {
            Debug.Log("Show OnClickTester");
            SceneScopeManager.LoadScope("Lobby");
            var handle = await UINavigation.ShowSystemUIAsync(SystemUIId.NetworkWaiting);
            // var handle = await UINavigation.ShowSystemUIAsync(SystemUIId.Popup, new PopupUIParam("t", "test", "ok", "no", true));
            Debug.Log("Show End");
            await handle.WaitUntilClosedAsync();
            Debug.Log("Hide End");
        }
    }
}