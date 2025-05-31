using VContainer;
using VContainer.Unity;

namespace Domir.Client.Core.Scope
{
    public class SceneScope : LifetimeScope
    {
        public UIRootScope UIRoot { get; private set; }
        public EntityScope Entity { get; private set; }

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterBuildCallback(_ =>
            {
                UIRoot = CreateChild<UIRootScope>(childScopeName: "UI");
                Entity = CreateChild<EntityScope>(childScopeName: "Entities");
            });
        }

        protected override void OnDestroy()
        {
            UIRoot?.Dispose();
            UIRoot = null;
            Entity?.Dispose();
            Entity = null;
            base.OnDestroy();
        }
    }
}