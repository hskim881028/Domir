using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Common.Component;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Contract;
using Domir.Client.Common.UI.Implementation.View;
using TMPro;
using UnityEngine;

namespace Domir.Client.Contents.UI.System
{
    public class PopupSystemUIView : SystemUIView<IPopupSystemUIMessage>
    {
        [SerializeField] private TextMeshProUGUI _titleText;
        [SerializeField] private TextMeshProUGUI _contentText;
        [SerializeField] private DomirButton _confirmButton;
        [SerializeField] private DomirButton _cancelButton;

        public override async UniTask InitializeAsync(CancellationToken token)
        {
            _confirmButton.onClick.AddListener(() => Message.Confirm());
            _cancelButton.onClick.AddListener(() => Message.Cancel());

            await base.InitializeAsync(token);
        }

        public override async UniTask ShowAsync(CancellationToken token, UIParam param, bool immediately = false)
        {
            var popupUIParam = param.As<PopupUIParam>();
            _titleText.text = popupUIParam.TitleText;
            _contentText.text = popupUIParam.ContentText;
            _confirmButton.Text = popupUIParam.ConfirmButtonText;
            _cancelButton.Text = popupUIParam.CancelButtonText;
            _cancelButton.gameObject.SetActive(popupUIParam.UseTwoButton);
            await base.ShowAsync(token, param, immediately);
        }
    }
}