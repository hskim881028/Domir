using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Common.UI.Implementation
{
    public sealed class UINavigation
    {
        private readonly LinkedList<string> _stack = new();
        private readonly IUIPresenterFactory _factory;

        public UINavigation(UIPresenterFactory factory)
        {
            _factory = factory;
        }

        public Awaitable<UIResult> ShowAsync(string id)
        {
            if (_stack.Count > 0)
            {
                var preId = _stack.Last.Value;
                _factory.Get(preId).LastSelector = EventSystem.current.currentSelectedGameObject;
            }

            if (!_stack.Contains(id))
            {
                _stack.AddLast(id);
            }

            var presenter = _factory.Get(id);
            presenter.ShowAsync();
            var handle = presenter.GenerateHandle();

            EventSystem.current.SetSelectedGameObject(presenter.FirstSelector);
            return handle.Awaitable;
        }

        public Awaitable<UIResult> HideAsync(string id)
        {
            if (_stack.Count == 0) return null;

            var presenter = _factory.Get(id);
            var handle = presenter.GenerateHandle();
            presenter.HideAsync();

            _stack.Remove(id);
            if (_stack.Count > 0)
            {
                var peek = _factory.Get(_stack.Last.Value);
                EventSystem.current.SetSelectedGameObject(peek.LastSelector);
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
            }

            return handle.Awaitable;
        }
    }
}