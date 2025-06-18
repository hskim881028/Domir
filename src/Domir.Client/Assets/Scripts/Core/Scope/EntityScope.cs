using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.Core.Scope
{
    public class EntityScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            transform.SetParent(null);
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
        }
    }
}