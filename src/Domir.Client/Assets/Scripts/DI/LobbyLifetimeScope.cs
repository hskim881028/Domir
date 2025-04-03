using Domir.Client.Entries;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public class LobbyLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<LobbyEntry>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}