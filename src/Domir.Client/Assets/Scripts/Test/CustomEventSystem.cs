using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Test
{
    public class CustomEventSystem : EventSystem
    {
        private GameObject _lastSelected;

        private Stack<GameObject> _stack = new();

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            // _lastSelected = current.firstSelectedGameObject;
        }

        protected override void Update()
        {
            base.Update();
            //
            // if (current.currentSelectedGameObject == null)
            // {
            //     current.SetSelectedGameObject(_stack.TryPop(out var obj)
            //         ? obj
            //         : current.firstSelectedGameObject);
            // }
            // else
            // {
            //     if (_lastSelected == current.currentSelectedGameObject) return;
            //
            //     _stack.Push(_lastSelected);
            //     _lastSelected = current.currentSelectedGameObject;
            // }
        }
    }
}