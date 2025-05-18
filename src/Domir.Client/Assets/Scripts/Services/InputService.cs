using System;
using Domir.Client.Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Domir.Client.Services
{
    public sealed class InputService
    {
        private readonly InputActionAsset _inputAction;
        private readonly EventSystem _eventSystem;

        private const KeyCode LOAD_SCOPE_KEY = KeyCode.Z;
        private const KeyCode UNLOAD_SCOPE_KEY = KeyCode.X;

        public InputService(
            InputActionAsset inputAction,
            EventSystem eventSystem)
        {
            _inputAction = inputAction;
            _eventSystem = eventSystem;
            BindAction("UI/Cancel", Cancel);
        }

        /// <summary>
        /// 스코프 컨트롤러에 대한 키 입력 처리를 등록합니다.
        /// </summary>
        public void RegisterScopeControls(Action loadScope, Action unloadScope)
        {
            // Update 메서드에서 호출될 입력 처리 이벤트를 등록
            InputProcessor.Instance.RegisterKeyDownEvent(LOAD_SCOPE_KEY, loadScope);
            InputProcessor.Instance.RegisterKeyDownEvent(UNLOAD_SCOPE_KEY, unloadScope);
        }

        private void BindAction(string actionName, Action<InputAction.CallbackContext> callback)
        {
            var action = _inputAction.FindAction(actionName);
            if (action == null)
            {
                Debug.LogWarning($"Action '{actionName}' not found.");
                return;
            }

            action.performed += callback;
            action.Enable();
        }

        private void Cancel(InputAction.CallbackContext context)
        {
            Debug.Log("Cancel");
            var currentSelected = _eventSystem.currentSelectedGameObject;
            if (currentSelected == null) return;

            Debug.Log($"[currentSelected] : {currentSelected.name} / {currentSelected.tag} / {currentSelected.layer}");
            var selectable = currentSelected.GetComponent<IUISelectable>();

            if (selectable != null) { }
        }
    }
}