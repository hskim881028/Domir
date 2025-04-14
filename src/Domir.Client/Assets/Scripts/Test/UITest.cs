using System;
using System.Collections.Generic;
using Common.UI.Implementation;
using Cysharp.Threading.Tasks;
using Domir.Client.Contents.UI;
using Domir.Client.Services;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

public class UITest : LifetimeScope
{
    [SerializeField] private InputActionAsset _inputAction;
    [SerializeField] private List<UIViewBase> _uiViews;

    private UINavigation _uiNavigation;

    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.Register<InputService>(Lifetime.Singleton).WithParameter(_inputAction);
        builder.Register<UINavigation>(Lifetime.Singleton).WithParameter(_inputAction);

        builder.Register<UIPresenterFactory>(Lifetime.Singleton);
        builder.Register<UIHandleFactory>(Lifetime.Singleton);

        builder.Register<MenuPresenter>(Lifetime.Singleton);
        builder.Register<PopupPresenter>(Lifetime.Singleton);

        foreach (var view in _uiViews)
        {
            builder.RegisterComponentInNewPrefab(view, Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }


        builder.RegisterBuildCallback(c =>
        {
            c.Resolve<InputService>();
            _uiNavigation = c.Resolve<UINavigation>();
            c.Resolve<UIPresenterFactory>().Initialize(new Dictionary<string, Type>
            {
                {
                    nameof(MenuPresenter), typeof(MenuPresenter)
                },
                {
                    nameof(PopupPresenter), typeof(PopupPresenter)
                },
            });
        });
    }

    private async UniTaskVoid Test()
    {
        var result = await _uiNavigation.ShowAsync(nameof(PopupPresenter));
        if (result.Status == UIResultStatus.Ok)
        {
            Debug.Log("UI opened");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Test().Forget();
        }
    }
}