using Domir.Client.Entry;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public class StageLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<StageEntry>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}