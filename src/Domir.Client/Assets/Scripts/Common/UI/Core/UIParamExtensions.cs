using System;
using Domir.Client.Common.UI.Core.Contract;
using UnityEngine;

namespace Domir.Client.Common.UI.Core
{
    public static class UIParamExtensions
    {
        public static T As<T>(this UIParam param) where T : UIParam
        {
            if (param is T casted)
            {
                return casted;
            }

            Debug.LogError($"{param.GetType().Name} (Expected: {typeof(T).Name})");
            return null;
        }
    }
}