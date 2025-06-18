using System;
using Domir.Client.Core.Infrastructure;
using Domir.Client.Core.Messages;
using Domir.Client.Core.UI;
using MessagePipe;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Domir.Client.Contents.Services
{
    public sealed class InputService
    {
        private readonly InputActionAsset _inputAction;
        private readonly EventSystem _eventSystem;
        private readonly IPublisher<MoveStartedMessage> _moveStarted;
        private readonly IPublisher<MovePerformedMessage> _movePerformed;
        private readonly IPublisher<MoveCanceledMessage> _moveCancel;

        public InputService(
            InputActionAsset inputAction,
            EventSystem eventSystem,
            IPublisher<MoveStartedMessage> moveStarted,
            IPublisher<MovePerformedMessage> movePerformed,
            IPublisher<MoveCanceledMessage> moveCancel)
        {
            _inputAction = inputAction;
            _eventSystem = eventSystem;
            _moveStarted = moveStarted;
            _movePerformed = movePerformed;
            _moveCancel = moveCancel;
            BindAction("UI/Cancel", performed: Cancel);
            BindAction("Player/Move", MoveStarted, MovePerformed, MoveCanceled);
        }

        private void BindAction(
            string actionName,
            Action<InputAction.CallbackContext> started = null,
            Action<InputAction.CallbackContext> performed = null,
            Action<InputAction.CallbackContext> canceled = null)
        {
            var action = _inputAction.FindAction(actionName);
            if (action == null)
            {
                Debug.LogWarning($"Action '{actionName}' not found.");
                return;
            }

            if (started != null)
            {
                action.started += started;
            }

            if (performed != null)
            {
                action.performed += performed;
            }

            if (canceled != null)
            {
                action.canceled += canceled;
            }


            action.Enable();
        }

        private void Cancel(InputAction.CallbackContext context)
        {
            this.Log();
            var currentSelected = _eventSystem.currentSelectedGameObject;
            if (currentSelected == null) return;

            Debug.Log($"[currentSelected] : {currentSelected.name} / {currentSelected.tag} / {currentSelected.layer}");
            var selectable = currentSelected.GetComponent<IUISelectable>();

            if (selectable != null) { }
        }

        private void MoveStarted(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            this.Log(direction);
            _moveStarted.Publish(new MoveStartedMessage(direction));
        }

        private void MovePerformed(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            this.Log(direction);
            _movePerformed.Publish(new MovePerformedMessage(direction));
        }

        private void MoveCanceled(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            this.Log(direction);
            _moveCancel.Publish(new MoveCanceledMessage(direction));
        }
    }
}