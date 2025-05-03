using System;
using System.Collections.Generic;
using System.Linq;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Presenter;
using Domir.Client.Common.UI.Scope;
using Domir.Client.Common.UI.View;
using Domir.Client.Contents.UI.Generated;
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

        public IReadOnlyList<UIId> GetStaticUI()
        {
            var staticUIIds = typeof(StaticUIId)
                .GetFields()
                .Where(f => f.IsStatic && f.FieldType == typeof(UIId))
                .Select(f => (UIId)f.GetValue(null))
                .ToHashSet();

            var ids = _presenters
                .Where(kv => staticUIIds.Contains(kv.Key))
                .Select(kv => kv.Key)
                .ToList();

            return ids;
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
                $"{type.Name.AsUI()}");
            var component = child.gameObject.AddComponent<UIChild>();
            component.Presenter = (T)child.Container.Resolve(type);
            _ui.Add(id, component);
            return (T)component.Presenter;
        }

        public void Remove(UIId id)
        {
            _ui.Remove(id);
        }

        private IUIScope GetCanvas<T>() where T : IUIPresenter
        {
            var uiType = typeof(T);
            if (_canvas.TryGetValue(uiType, out var canvas)) return canvas;

            var child = _rooLifetimeScope.CreateChild(_ => { }, uiType.Name.AsCanvas());
            var component = child.gameObject.AddComponent<UICanvas>();
            component.SetSortOrder(uiType);
            _canvas.Add(uiType, component);
            return _canvas[uiType];
        }
    }
}