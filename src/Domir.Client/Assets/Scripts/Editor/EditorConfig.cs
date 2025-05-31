using System;
using Domir.Client.Core.UI;
using UnityEngine;

namespace Domir.Client.Editor
{
    public static class EditorConfig
    {
        public static readonly string ResourcesPath = $"{Application.dataPath}/Resources";
        public static readonly string GeneratedPath = $"{Application.dataPath}/Scripts/Contents/UI/Generated";

        private const string NamespaceUI = "namespace Domir.Client.Contents.UI";
        public static readonly string NamespaceGenerated = $"{NamespaceUI}.Generated";
        public static readonly string NamespaceContentsStatic = $"{NamespaceUI}.{UIConfig.Static}";
        public static readonly string NamespaceContentsStack = $"{NamespaceUI}.{UIConfig.Stack}";
        public static readonly string NamespaceContentsSystem = $"{NamespaceUI}.{UIConfig.System}";

        private const string UsingUI = "using Domir.Client.Core.UI";
        public static readonly string UsingSystem = $"using System;";
        public static readonly string UsingGeneric = $"using System.Collections.Generic;";
        public static readonly string UsingCore = $"{UsingUI};";
        public static readonly string UsingView = $"{UsingUI}.View;";
        public static readonly string UsingNavigation = $"{UsingUI}.Navigation;";
        public static readonly string UsingPresenter = $"{UsingUI}.Presenter;";

        private const string UsingUIContents = "using Domir.Client.Contents.UI";
        public static readonly string UsingContentsStatic = $"{UsingUIContents}.{UIConfig.Static};";
        public static readonly string UsingContentsStack = $"{UsingUIContents}.{UIConfig.Stack};";
        public static readonly string UsingContentsSystem = $"{UsingUIContents}.{UIConfig.System};";

        public enum UIType
        {
            Static,
            Stack,
            System,
        }

        public static string ToString(this UIType uiType)
        {
            return uiType switch
            {
                UIType.Static => UIConfig.Static,
                UIType.Stack => UIConfig.Stack,
                UIType.System => UIConfig.SystemUI,
                _ => throw new ArgumentOutOfRangeException(nameof(uiType), uiType, null)
            };
        }

        public static string ToContentsNamespace(this UIType uiType)
        {
            return uiType switch
            {
                UIType.Static => NamespaceContentsStatic,
                UIType.Stack => NamespaceContentsStack,
                UIType.System => NamespaceContentsSystem,
                _ => throw new ArgumentOutOfRangeException(nameof(uiType), uiType, null)
            };
        }

        public static string ToPath(this UIType uiType)
        {
            return uiType switch
            {
                UIType.Static => $"{Application.dataPath}/Scripts/Contents/UI/{UIConfig.Static}",
                UIType.Stack => $"{Application.dataPath}/Scripts/Contents/UI/{UIConfig.Stack}",
                UIType.System => $"{Application.dataPath}/Scripts/Contents/UI/{UIConfig.System}",
                _ => throw new ArgumentOutOfRangeException(nameof(uiType), uiType, null)
            };
        }

        public static string ToPresenter(this UIType uiType, string prefix = "")
        {
            return $"{prefix}{uiType.ToString()}UIPresenter";
        }

        public static string ToView(this UIType uiType, string prefix = "")
        {
            return $"{prefix}{uiType.ToString()}UIView";
        }

        public static string ToMessage(this UIType uiType, string prefix)
        {
            return $"I{prefix}{uiType.ToString()}UIMessage";
        }
    }
}