using System;
using System.Collections.Generic;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Component;
using Domir.Client.Common.UI.Core.Presenter;
using Domir.Client.Common.UI.Implementation.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Domir.Client.Contents.UI
{
    public sealed class UIManager : IUIManager
    {
        private readonly LifetimeScope _rooLifetimeScope;
        private readonly Dictionary<UIId, (Type type, string prefabPath)> _presenters;

        private readonly Dictionary<Type, IUICanvas> _canvas = new();
        private readonly Dictionary<UIId, IUI> _ui = new();

        public UIManager(LifetimeScope rooLifetimeScope, Dictionary<UIId, (Type type, string prefabPath)> presenters)
        {
            _rooLifetimeScope = rooLifetimeScope;
            _presenters = presenters;
        }

        public IReadOnlyList<UIId> Preload()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(UIId id) where T : IUIPresenter
        {
            if (_ui.TryGetValue(id, out var ui))
            {
                return (T)ui.Presenter;
            }

            var canvas = GetCanvas<T>();

            var (type, prefabPath) = _presenters[id];
            var child = canvas.LifetimeScope.CreateChild(builder =>
                {
                    var prefab = Resources.Load<UIViewBase>(prefabPath);
                    builder.RegisterComponentInNewPrefab(prefab, Lifetime.Scoped).AsSelf();
                    builder.Register(type, Lifetime.Scoped);
                },
                $"{type.Name}");
            var component = child.gameObject.AddComponent<UIChild>();
            component.Presenter = (T)child.Container.Resolve(type);
            _ui.Add(id, component);
            return (T)component.Presenter;
        }

        public void Remove(UIId id)
        {
            throw new NotImplementedException();
        }

        private IUICanvas GetCanvas<T>() where T : IUIPresenter
        {
            var uiType = typeof(T);
            if (_canvas.TryGetValue(uiType, out var canvas)) return canvas;

            var child = _rooLifetimeScope.CreateChild(_ => { }, $"Canvas({uiType})");
            var component = child.gameObject.AddComponent<UICanvas>();
            _canvas.Add(uiType, component);
            return _canvas[uiType];
        }
    }
}