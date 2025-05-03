﻿using System.Collections.Generic;
using Domir.Client.Common.UI.Core;
using Domir.Client.Common.UI.Core.Navigation;

namespace Domir.Client.Common.UI.Implementation
{
    public sealed class UINavigationNodePool : IUINavigationNodePool
    {
        private readonly Queue<IUINavigationNode> _pool = new();
        private bool _isDisposed;

        public IUINavigationNode Get(UIId id)
        {
            if (_pool.TryDequeue(out var node))
            {
                node.Reset(id);
                return node;
            }

            var newNode = new UINavigationNode(id, UIHandle.Create);
            return newNode;
        }

        public void Return(IUINavigationNode node)
        {
            _pool.Enqueue(node);
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            _isDisposed = true;

            foreach (var node in _pool)
            {
                node.Dispose();
            }

            _pool.Clear();
        }
    }
}