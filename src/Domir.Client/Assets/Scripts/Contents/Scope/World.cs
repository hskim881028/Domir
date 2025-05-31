// using System;
// using Domir.Client.Core.Messages;
// using MessagePipe;
// using R3;
// using VContainer.Unity;
// using DisposableBag = R3.DisposableBag;
//
// namespace Domir.Client.Contents.Scope
// {
//     public sealed class World : IStartable
//     {
//         private readonly ISubscriber<SceneScopeMessage> _subscriber;
//         private DisposableBag _disposable;
//
//         public World(ISubscriber<SceneScopeMessage> subscriber)
//         {
//             _subscriber = subscriber;
//             subscriber.Subscribe(OnSceneScopeMessage).AddTo(ref _disposable);
//         }
//
//         private void OnSceneScopeMessage(SceneScopeMessage message)
//         {
//             switch (message.Type)
//             {
//                 case SceneScopeMessageType.Unload:
//                     break;
//                 case SceneScopeMessageType.Load:
//                     break;
//                 default:
//                     throw new ArgumentOutOfRangeException();
//             }
//         }
//
//         public void Start() { }
//     }
// }