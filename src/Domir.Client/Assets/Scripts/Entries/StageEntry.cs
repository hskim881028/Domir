using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Entries
{
    public class StageEntry : IStartable
    {
        public void Start()
        {
            Debug.Log($"{GetType().Name} Started");
        }
    }
}