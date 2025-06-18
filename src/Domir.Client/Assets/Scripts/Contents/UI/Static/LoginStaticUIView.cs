using Domir.Client.Core.UI.View;
using UnityEngine;
using UnityEngine.UI;

namespace Domir.Client.Contents.UI.Static
{
    public class LoginStaticUIView : StaticUIView<ILoginStaticUIMessage>
    {
        [SerializeField] private Button _hostButton;
        [SerializeField] private Button _clientButton;

        protected override void OnAwake()
        {
            base.OnAwake();
            _hostButton.onClick.AddListener(() => Message?.ClickHost());
            _clientButton.onClick.AddListener(() => Message?.ClickClient());
        }
    }
}