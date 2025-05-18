using System;
using Domir.Client.Core.Messages;
using MessagePipe;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Domir.Client.Core.Scope
{
    public sealed class SceneScopeManager : ISceneScopeManager
    {
        private readonly LifetimeScope _root;
        private readonly IPublisher<SceneScopeMessage> _publisher;
        private SceneScope _current;
        private bool _isDisposed;

        public SceneScopeManager(
            LifetimeScope root,
            IPublisher<SceneScopeMessage> publisher)
        {
            _root = root;
            _publisher = publisher;
        }

        public void LoadScope(string scopeName)
        {
            if (_current != null)
            {
                Unload();
            }

            _current = _root.CreateChild<SceneScope>(childScopeName: scopeName);
            SceneManager.MoveGameObjectToScene(_current.gameObject, SceneManager.GetActiveScene());
            _publisher.Publish(SceneScopeMessage.Load(_current));
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;

            Unload();
        }

        private void Unload()
        {
            _publisher.Publish(SceneScopeMessage.Unload);

            _current?.Dispose();
            _current = null;

            GC.Collect();
            Resources.UnloadUnusedAssets();
        }
    }
}