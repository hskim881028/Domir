using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Implementation.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domir.Client.Common.Component
{
    public class DomirButton : Button, IUISelectable
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        public UIViewBase Parent { get; private set; }

        public string Text
        {
            get => _text.text;
            set => _text.text = value;
        }

        protected override void Awake()
        {
            base.Awake();
            _image = GetComponent<Image>();
            _text = GetComponentInChildren<TextMeshProUGUI>();
            Parent = GetComponentInParent<UIViewBase>();
        }
    }
}