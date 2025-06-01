using Domir.Client.Contents.Command;
using Domir.Client.Contents.Services;
using Domir.Client.Contents.UI;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.Core.Command;
using Domir.Client.Core.Messages;
using Domir.Client.Core.Scope;
using Domir.Client.Core.UI;
using Domir.Client.Core.UI.Navigation;
using Domir.Client.Data.Repository;
using Domir.Client.Data.Store;
using Domir.Client.DI.ScriptableObjects;
using Domir.Client.Network;
using Domir.Client.Network.ClientFilters;
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

            Message(builder);
            Component(builder, Lifetime.Singleton);
            Store(builder, Lifetime.Singleton);
            Repository(builder, Lifetime.Singleton);
            Network(builder, Lifetime.Singleton);
            Service(builder, Lifetime.Singleton);
            Command(builder, Lifetime.Singleton);
            Scene(builder, Lifetime.Singleton);
            UI(builder, Lifetime.Singleton);

            builder.Register<ApplicationEntry>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }

        private static void Message(IContainerBuilder builder)
        {
            var options = builder.RegisterMessagePipe();
            builder.RegisterMessageBroker<SceneScopeMessage>(options);
            builder.RegisterMessageBroker<MoveStartedMessage>(options);
            builder.RegisterMessageBroker<MovePerformedMessage>(options);
            builder.RegisterMessageBroker<MoveCanceledMessage>(options);
        }

        private void Component(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.RegisterInstance(_components.InputAction);
            builder.RegisterComponentInNewPrefab(_components.NetworkManager, lifetime);
            builder.RegisterComponentInNewPrefab(_components.EventSystem, lifetime).UnderTransform(transform);
            builder.RegisterComponentInNewPrefab(_components.CameraSet, lifetime).UnderTransform(transform);
            builder.RegisterComponentInNewPrefab(_components.GlobalLight, lifetime).UnderTransform(transform);
        }

        private void Store(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<UserStore>(lifetime);
        }

        private void Repository(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<UserRepository>(lifetime);
        }

        private void Network(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<IClientFilter, LoggingFilter>(lifetime).AsSelf();
            builder.Register<IClientFilter, RetryFilter>(lifetime).AsSelf();
            builder.Register<IResponseHandler, ResponseHandler>(lifetime);
            builder.Register<INetworkConnection, NetworkConnection>(lifetime);
            builder.Register<NetworkService>(lifetime);
        }

        private void Service(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<InputService>(lifetime);
            builder.Register<CameraService>(lifetime);
            builder.Register<EnvironmentService>(lifetime);
            builder.Register<EntitySpawnService>(lifetime);
        }

        private void Command(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<ICommandExecutor, CommandExecutor>(lifetime);
            builder.Register<Login>(lifetime);
            builder.Register<StartHost>(lifetime);
            builder.Register<StartClient>(lifetime);
            builder.Register<CreateWorld>(lifetime);
            builder.Register<JoinWorld>(lifetime);
        }

        private static void Scene(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<ISceneScopeManager, SceneScopeManager>(lifetime);
            builder.Register<SceneService>(lifetime);
        }

        private void UI(IContainerBuilder builder, Lifetime lifetime)
        {
            builder.Register<IUIManager, UIManager>(lifetime).WithParameter(UIMapping.UI);
            builder.Register<IUINavigationNodePool, UINavigationNodePool>(lifetime);
            builder.Register<IUINavigation, UINavigation>(lifetime);
        }
    }
}