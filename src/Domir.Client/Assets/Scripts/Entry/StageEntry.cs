using System;
using UnityEngine;
using VContainer.Unity;

namespace Domir.Client.Entry
{
    public class StageEntry : IStartable
    {
        public void Start()
        {
            Debug.Log($"{GetType().Name} Started");
        }
    }
}