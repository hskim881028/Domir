using Domir.Client.Data.Model;
using ObservableCollections;

namespace Domir.Client.Data.Repository
{
    public class Repository<T> where T : IModel
    {
        protected readonly ObservableDictionary<string, T> _models = new();

        public ObservableDictionary<string, T> Models => _models;

        public void Update(T item)
        {
            _models[item.Key] = item;
        }

        public T Get(string key)
        {
            return _models[key];
        }

        public void Remove(string key)
        {
            _models.Remove(key);
        }
    }
}