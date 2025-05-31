﻿using System.Collections.Generic;
using UnitGenerator;

namespace Domir.Client.Core.UI
{
    [UnitOf(typeof(int), UnitGenerateOptions.ImplicitOperator | UnitGenerateOptions.Comparable)]
    public readonly partial struct UILayer
    {
        public static readonly UILayer HideAll = -1;
        public static readonly UILayer Default = 0;

        public static HashSet<UILayer> Set(params UILayer[] values) => new(values);

        public static HashSet<UILayer> SetWithDefault(params UILayer[] values)
        {
            var result = new HashSet<UILayer> { Default };
            foreach (var value in values)
            {
                result.Add(value);
            }

            return result;
        }

        public static HashSet<UILayer> SetDefault => new() { Default };
    }
}