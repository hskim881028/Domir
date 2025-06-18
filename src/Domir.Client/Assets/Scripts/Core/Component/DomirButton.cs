using Domir.Client.Core.UI;
using Domir.Client.Core.UI.View;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Domir.Client.Core.Component
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