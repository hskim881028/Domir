using Domir.Client.Entries;
using Domir.Client.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.U2D;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.DI
{
    public class ApplicationLifetimeScope : LifetimeScope
    {
        [SerializeField] private InputActionAsset _inputAction;
        [SerializeField] private EventSystem _eventSystem;
        [SerializeField] private Camera _mainCamera;
        [SerializeField] private Light2DBase _globalLight;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            Register.Network(builder, Lifetime.Singleton);
            Register.Services(builder, Lifetime.Singleton, _inputAction, _eventSystem, _mainCamera, _globalLight);

            builder.Register<SceneLoader>(Lifetime.Singleton);
            builder.Register<ApplicationEntry>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            DontDestroyOnLoad(gameObject);
        }
    }
}