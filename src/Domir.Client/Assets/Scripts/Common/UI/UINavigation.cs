using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI
{
    public sealed class UINavigation
    {
        private readonly Stack<IUIView> _stack = new();

        public Awaitable<IUIResult> Show(IUIView view)
        {
            if (view == null) return null;

            if (_stack.TryPeek(out var peek))
            {
                peek.LastSelector = EventSystem.current.currentSelectedGameObject;
            }
            
            _stack.Push(view);
            
            EventSystem.current.SetSelectedGameObject(view.FirstSelector);
            
            var handle = view.GenerateHandle();
            view.Show();
            return handle.Awaitable;
        }

        public Awaitable<IUIResult> Hide()
        {
            if (!_stack.TryPop(out var view))
            {
                return null;
            }

            EventSystem.current.SetSelectedGameObject(_stack.TryPeek(out var peek)
                ? peek.LastSelector
                : EventSystem.current.firstSelectedGameObject);
            
            var handle = view.GenerateHandle();
            view.Hide();
            return handle.Awaitable;
        }
    }
}