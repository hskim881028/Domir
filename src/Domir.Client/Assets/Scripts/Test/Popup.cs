using System.Threading.Tasks;
using Common.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class Popup : MonoBehaviour, IUIView
    {
        [SerializeField] private Button _leftButton;
        [SerializeField] private Button _rightButton;

        [SerializeField] private Popup _next;

        public IUIHandle Handle { get; private set; }
        public GameObject FirstSelector => _leftButton.gameObject;
        public GameObject LastSelector { get; set; }

        private UINavigation _uiNavigation;

        public void Setup(UINavigation uiNavigation)
        {
            _uiNavigation = uiNavigation;
        }

        private void Awake()
        {
            _leftButton.onClick.AddListener(() =>
            {
                Debug.Log("_leftButton");
                HideAsync().Forget();
            });
            _rightButton.onClick.AddListener(() =>
            {
                Debug.Log("_rightButton");
                _uiNavigation.Show(_next);
            });
        }

        private async UniTaskVoid HideAsync()
        {
            var result = await _uiNavigation.Hide();
           
            if (result.Status == UIResultStatus.Ok)
            {
                Debug.Log("UI Closed");
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
            Wait().Forget();
        }

        private async UniTask Wait()
        {
            await Awaitable.WaitForSecondsAsync(2);
            Handle?.Complete(new UIResult(UIResultStatus.Ok));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            Wait().Forget();
        }

        public IUIHandle GenerateHandle()
        {
            Handle = new UIHandle();
            return Handle;
        }
    }
}