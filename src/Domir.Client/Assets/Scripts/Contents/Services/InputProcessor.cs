using System;
using System.Collections.Generic;
using UnityEngine;

namespace Domir.Client.Contents.Services
{
    /// <summary>
    /// 키보드 입력을 처리하는 싱글톤 클래스입니다.
    /// </summary>
    public sealed class InputProcessor : MonoBehaviour
    {
        private static InputProcessor _instance;

        public static InputProcessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    var go = new GameObject("InputProcessor");
                    _instance = go.AddComponent<InputProcessor>();
                    DontDestroyOnLoad(go);
                }
                return _instance;
            }
        }

        private readonly Dictionary<KeyCode, Action> _keyDownEvents = new();

        public void RegisterKeyDownEvent(KeyCode keyCode, Action action)
        {
            if (!_keyDownEvents.TryAdd(keyCode, action))
            {
                _keyDownEvents[keyCode] += action;
            }
        }

        public void UnregisterKeyDownEvent(KeyCode keyCode, Action action)
        {
            if (_keyDownEvents.ContainsKey(keyCode))
            {
                _keyDownEvents[keyCode] -= action;
                if (_keyDownEvents[keyCode] == null)
                {
                    _keyDownEvents.Remove(keyCode);
                }
            }
        }

        private void Update()
        {
            foreach (var kvp in _keyDownEvents)
            {
                if (Input.GetKeyDown(kvp.Key))
                {
                    kvp.Value?.Invoke();
                }
            }
        }
    }
} 