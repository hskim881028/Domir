using System;
using System.Collections.Generic;
using System.Linq;
using VContainer;

namespace Common.UI.Implementation
{
    public class UIPresenterFactory : IUIPresenterFactory
    {
        private readonly Dictionary<string, IUIPresenter> _presenters;
        private readonly IObjectResolver _resolver;
        private IReadOnlyDictionary<string, Type> _presenterTypes;

        public UIPresenterFactory(
            IEnumerable<IUIPresenter> initialPresenters,
            IObjectResolver resolver)
        {
            _resolver = resolver;
            _presenters = initialPresenters.ToDictionary(p => p.Id);
        }

        public void Initialize(IReadOnlyDictionary<string, Type> presenterTypes)
        {
            _presenterTypes = presenterTypes;
        }

        public IUIPresenter Get(string id)
        {
            if (_presenters.TryGetValue(id, out var presenter))
                return presenter;

            if (!_presenterTypes.TryGetValue(id, out var type))
                throw new Exception($"Unknown presenter ID: {id}");

            presenter = (IUIPresenter)_resolver.Resolve(type);
            _presenters[id] = presenter;

            return presenter;
        }
    }
}