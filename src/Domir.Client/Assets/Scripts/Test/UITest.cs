using System.Threading.Tasks;
using Common.UI;
using Cysharp.Threading.Tasks;
using Domir.Client.Services;
using Test;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

public class UITest : LifetimeScope
{
    [SerializeField] private InputActionAsset _inputAction;

    [SerializeField] private Button _button;

    [SerializeField] private Popup _popup;
    [SerializeField] private Popup _nextPopup;

    private UINavigation _uiNavigation;

    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.Register<InputService>(Lifetime.Singleton).WithParameter(_inputAction);
        builder.Register<UINavigation>(Lifetime.Singleton).WithParameter(_inputAction);
        builder.RegisterBuildCallback(c =>
        {
            c.Resolve<InputService>();
            _uiNavigation = c.Resolve<UINavigation>();
            _popup.Setup(_uiNavigation);
            _nextPopup.Setup(_uiNavigation);
        });

        _button.onClick.AddListener(() => Test().Forget());
    }

    private async UniTaskVoid Test()
    {
        var result = await _uiNavigation.Show(_popup);
        if (result.Status == UIResultStatus.Ok)
        {
            Debug.Log("UI opened");
        }
    }
}