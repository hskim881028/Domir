using Domir.Client.Entries;
using Domir.Client.SceneManagement;
using Domir.Client.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public class ApplicationLifetimeScope : LifetimeScope
    {
        [SerializeField] private InputActionAsset _inputAction;
        [SerializeField] private EventSystem _eventSystem;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            Register.Network(builder, Lifetime.Singleton);

            builder.Register<InputService>(Lifetime.Singleton).WithParameter(_inputAction).WithParameter(_eventSystem);
            builder.Register<SceneLoader>(Lifetime.Singleton);

            builder.Register<ApplicationEntry>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            DontDestroyOnLoad(gameObject);
        }
    }
}