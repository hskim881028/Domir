using Domir.Client.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public class Application : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.Register<SceneLoader>(Lifetime.Singleton);
        }

        protected override void Awake()
        {
            base.Awake();
            var sceneLoader = Container.Resolve<SceneLoader>();
            sceneLoader.LoadAsync("Lobby");
        }
    }
}