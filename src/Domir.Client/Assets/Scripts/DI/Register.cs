using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Navigation;
using Domir.Client.Contents.Command;
using Domir.Client.Contents.Command.Implementation;
using Domir.Client.Contents.UI;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.Network;
using Domir.Client.Network.ClientFilters;
using Domir.Client.Services;
using MagicOnion.Client;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using VContainer;

namespace Domir.Client.DI
{
    public static class Register
    {
        public static void Network(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<IClientFilter, LoggingFilter>(lifetime).AsSelf();
            builder.Register<IClientFilter, RetryFilter>(lifetime).AsSelf();
            builder.Register<IResponseHandler, ResponseHandler>(lifetime);
            builder.Register<INetworkConnection, NetworkConnection>(lifetime);
            builder.Register<NetworkService>(lifetime);
        }

        public static void Services(
            IContainerBuilder builder,
            Lifetime lifetime,
            InputActionAsset inputAction,
            EventSystem eventSystem,
            Camera mainCamera,
            Light2DBase globalLight)
        {
            builder.Register<InputService>(lifetime).WithParameter(inputAction).WithParameter(eventSystem);
            builder.Register<CameraService>(lifetime).WithParameter(mainCamera);
            builder.Register<EnvironmentService>(lifetime).WithParameter(globalLight);
        }

        public static void Command(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<Login>(lifetime);
            builder.Register<CommandExecutor>(lifetime);
            builder.Register<CommandHandler>(lifetime);
        }

        public static void UI(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<IUIManager, UIManager>(lifetime).WithParameter(UIMapping.UI);
            builder.Register<IUINavigationNodePool, UINavigationNodePool>(lifetime);
            builder.Register<IUINavigation, UINavigation>(lifetime);
        }
    }
}