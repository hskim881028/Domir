using System.Collections.Generic;
using Domir.Client.Common.UI.Core;

namespace Domir.Client.Common.UI.Implementation
{
    public class UINavigationNodePool : IUINavigationNodePool
    {
        private readonly Queue<IUINavigationNode> _pool = new();
        private bool _isDisposed;

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

        public IUINavigationNode Get(UIId id)
        {
            if (_pool.TryDequeue(out var node))
            {
                node.Reset(id);
                return node;
            }

            var newNode = new UINavigationNode(id, new UIHandle());
            return newNode;
        }

        public void Return(IUINavigationNode node)
        {
            _pool.Enqueue(node);
        }
    }
}