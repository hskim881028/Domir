using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Navigation;
using Domir.Client.Contents.UI;
using Domir.Client.Contents.UI.Generated;
using Domir.Client.Entries;
using Domir.Client.Network;
using Domir.Client.Network.ClientFilters;
using Domir.Client.SceneManagement;
using Domir.Client.Services;
using MagicOnion.Client;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public class ApplicationLifetimeScope : LifetimeScope
    {
        [SerializeField] private InputActionAsset _inputAction;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<IClientFilter, LoggingFilter>(Lifetime.Singleton).AsSelf();
            builder.Register<IClientFilter, RetryFilter>(Lifetime.Singleton).AsSelf();
            builder.Register<IResponseHandler, ResponseHandler>(Lifetime.Singleton);
            builder.Register<INetworkConnection, NetworkConnection>(Lifetime.Singleton);

            builder.Register<InputService>(Lifetime.Singleton).WithParameter(_inputAction);
            builder.Register<NetworkService>(Lifetime.Singleton);

            builder.Register<SceneLoader>(Lifetime.Singleton);

            builder.Register<ApplicationEntry>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            //ui
            builder.Register<IUIManager, UIManager>(Lifetime.Singleton).WithParameter(UIMapping.UI);
            builder.Register<IUINavigationNodePool, UINavigationNodePool>(Lifetime.Singleton);
            builder.Register<IUINavigation, UINavigation>(Lifetime.Singleton);

            DontDestroyOnLoad(gameObject);
        }
    }
}