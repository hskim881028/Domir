using Domir.Client.Contents.Command;
using Domir.Client.Contents.Command.Implementation;
using Domir.Client.Contents.UI;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.Core.Messages;
using Domir.Client.Core.Scope;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Network;
using Domir.Client.Network.ClientFilters;
using Domir.Client.ScriptableObjects;
using Domir.Client.Services;
using MagicOnion.Client;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public sealed class ApplicationLifetimeScope : LifetimeScope
    {
        [SerializeField] private GlobalComponents _components;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<SceneScopeMessage>(options);

            RegisterComponents(builder, Lifetime.Singleton);
            RegisterNetwork(builder, Lifetime.Singleton);
            RegisterServices(builder, Lifetime.Singleton);
            RegisterCommands(builder, Lifetime.Singleton);

            builder.Register<ISceneScopeManager, SceneScopeManager>(Lifetime.Singleton);
            RegisterUI(builder, Lifetime.Singleton);

            builder.Register<ApplicationEntry>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }

        private void RegisterUI(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<IUIManager, UIManager>(lifetime).WithParameter(UIMapping.UI);
            builder.Register<IUINavigationNodePool, UINavigationNodePool>(lifetime);
            builder.Register<IUINavigation, UINavigation>(lifetime);
        }

        private void RegisterComponents(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.RegisterInstance(_components.InputAction);
            builder.RegisterComponentInNewPrefab(_components.NetworkManager, lifetime);
            builder.RegisterComponentInNewPrefab(_components.EventSystem, lifetime).UnderTransform(transform);
            builder.RegisterComponentInNewPrefab(_components.CameraSet, lifetime).UnderTransform(transform);
            builder.RegisterComponentInNewPrefab(_components.GlobalLight, lifetime).UnderTransform(transform);
        }

        private void RegisterNetwork(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<IClientFilter, LoggingFilter>(lifetime).AsSelf();
            builder.Register<IClientFilter, RetryFilter>(lifetime).AsSelf();
            builder.Register<IResponseHandler, ResponseHandler>(lifetime);
            builder.Register<INetworkConnection, NetworkConnection>(lifetime);
            builder.Register<NetworkService>(lifetime);
        }

        private void RegisterServices(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<InputService>(lifetime);
            builder.Register<CameraService>(lifetime);
            builder.Register<EnvironmentService>(lifetime);
        }

        private void RegisterCommands(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<CommandExecutor>(lifetime);
            builder.Register<CommandHandler>(lifetime);
            builder.Register<Login>(lifetime);
            builder.Register<OnClickTester>(lifetime);
        }
    }
}