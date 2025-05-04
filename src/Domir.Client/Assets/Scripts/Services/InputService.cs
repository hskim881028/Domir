using System;
using Domir.Client.Common.UI.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Domir.Client.Services
{
    public sealed class InputService
    {
        private readonly InputActionAsset _inputAction;
        private readonly EventSystem _eventSystem;

        public InputService(
            InputActionAsset inputAction,
            EventSystem eventSystem)
        {
            _inputAction = inputAction;
            _eventSystem = eventSystem;
            BindAction("UI/Cancel", Cancel);
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