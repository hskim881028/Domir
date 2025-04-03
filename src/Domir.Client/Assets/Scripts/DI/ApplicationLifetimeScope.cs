using Domir.Client.Entry;
using Domir.Client.Network;
using Domir.Client.Network.ClientFilter;
using Domir.Client.SceneManagement;
using Domir.Client.Service;
using MagicOnion.Client;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public class ApplicationLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<IClientFilter, LoggingFilter>(Lifetime.Singleton).AsSelf();
            builder.Register<IClientFilter, RetryFilter>(Lifetime.Singleton).AsSelf();
            builder.Register<IResponseHandler, ResponseHandler>(Lifetime.Singleton);
            builder.Register<INetworkConnection, NetworkConnection>(Lifetime.Singleton);

            builder.Register<NetworkService>(Lifetime.Singleton);

            builder.Register<SceneLoader>(Lifetime.Singleton);

            builder.Register<ApplicationEntry>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            DontDestroyOnLoad(gameObject);
        }
    }
}