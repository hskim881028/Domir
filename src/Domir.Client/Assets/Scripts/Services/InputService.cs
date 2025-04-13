using System;
using Common.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Domir.Client.Services
{
    public sealed class InputService
    {
        private readonly InputActionAsset _inputAction;
        private readonly UINavigation _navigation;

        public InputService(InputActionAsset inputAction, UINavigation navigation)
        {
            _inputAction = inputAction;
            _navigation = navigation;
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
            var currentSelected = EventSystem.current.currentSelectedGameObject;
            if (currentSelected == null) return;

            Debug.Log($"[currentSelected] : {currentSelected.name} / {currentSelected.tag} / {currentSelected.layer}");
            var selectable = currentSelected.GetComponent<IUISelectable>();

            if (selectable != null)
            {
                _navigation.Hide();
            }
        }
    }
}