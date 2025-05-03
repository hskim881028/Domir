using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class UIEditor
    {
        private const string GeneratedPath = "Assets/Scripts/Contents/UI/Generated";
        private const string ResourcesPath = "Resources";
        private static readonly string[] UIPaths = { $"UI/{Stack}", $"UI/{Static}", $"UI/{System}" };

        private const string Stack = "Stack";
        private const string Static = "Static";
        private const string System = "System";
        private const string UIMapping = "UIMapping";
        private const string UIIds = "UIIds";
        private static readonly string StackUI = $"{Stack}UI";
        private static readonly string StaticUI = $"{Static}UI";
        private static readonly string SystemUI = $"{System}UI";
        private static readonly string StackUIId = $"{StackUI}Id";
        private static readonly string StaticUIId = $"{StaticUI}Id";
        private static readonly string SystemUIId = $"{SystemUI}Id";


        [MenuItem("Domir/Generate UI")]
        public static void GenerateUI()
        {
            var stackId = 1000;
            var staticId = 100;
            var systemId = 0;

            var stackIdMap = new Dictionary<string, int>();
            var staticIdMap = new Dictionary<string, int>();
            var systemIdMap = new Dictionary<string, int>();

            var stackEntries = new List<string>();
            var staticEntries = new List<string>();
            var systemEntries = new List<string>();

            foreach (var uiPath in UIPaths)
            {
                var fullPath = $"{Application.dataPath}/{ResourcesPath}/{uiPath}";
                if (!Directory.Exists(fullPath))
                {
                    throw new DirectoryNotFoundException(fullPath);
                }

                var prefabFiles = Directory.GetFiles(fullPath, "*.prefab", SearchOption.AllDirectories);
                foreach (var file in prefabFiles)
                {
                    var fileName = Path.GetFileNameWithoutExtension(file);
                    if (!fileName.EndsWith("UI")) continue;

                    string category;
                    int id;
                    string enumName, enumField;

                    if (fileName.EndsWith(StackUI))
                    {
                        category = Stack;
                        enumName = StackUIId;
                        enumField = fileName.Replace(StackUI, string.Empty);
                        id = stackId++;
                    }
                    else if (fileName.EndsWith(StaticUI))
                    {
                        category = Static;
                        enumName = StaticUIId;
                        enumField = fileName.Replace(StaticUI, string.Empty);
                        id = staticId++;
                    }
                    else if (fileName.EndsWith(SystemUI))
                    {
                        category = System;
                        enumName = SystemUIId;
                        enumField = fileName.Replace(SystemUI, string.Empty);
                        id = systemId++;
                    }
                    else continue;

                    var typeName = $"{fileName}Presenter";

                    var relativePath = file.Replace($"{Application.dataPath}/{ResourcesPath}/", string.Empty).Replace(".prefab", string.Empty).Replace("\\", "/");
                    var entry = $"{{ {enumName}.{enumField}, (typeof({typeName}), \"{relativePath}\") }}";

                    switch (category)
                    {
                        case Stack:
                            stackIdMap[enumField] = id;
                            stackEntries.Add(entry);
                            break;
                        case Static:
                            staticIdMap[enumField] = id;
                            staticEntries.Add(entry);
                            break;
                        case System:
                            systemIdMap[enumField] = id;
                            systemEntries.Add(entry);
                            break;
                    }
                }
            }

            if (!Directory.Exists(GeneratedPath))
            {
                Directory.CreateDirectory(GeneratedPath);
            }

            File.WriteAllText($"{GeneratedPath}/{UIIds}.cs", GenerateUIIds(stackIdMap, staticIdMap, systemIdMap));
            File.WriteAllText($"{GeneratedPath}/{UIMapping}.cs", GenerateUIMapping(stackEntries, staticEntries, systemEntries));
            AssetDatabase.Refresh();
            Debug.Log($"✅ Generated <color=#81C784>{UIIds}.cs</color> and <color=#81C784>{UIMapping}.cs</color> successfully.");
        }

        private static string GenerateUIIds(
            Dictionary<string, int> stackUI,
            Dictionary<string, int> staticUI,
            Dictionary<string, int> systemUI)
        {
            var sb = new StringBuilder();
            sb.AppendLine("// <auto-generated>");
            sb.AppendLine("using Domir.Client.Common.UI.Core;");
            sb.AppendLine();
            sb.AppendLine("namespace Domir.Client.Contents.UI.Generated");
            sb.AppendLine("{");
            sb.AppendLine(GenerateBlock(StackUIId, stackUI));
            sb.AppendLine(GenerateBlock(StaticUIId, staticUI));
            sb.AppendLine(GenerateBlock(SystemUIId, systemUI));
            sb.AppendLine("}");
            sb.Append("// </auto-generated>");
            return sb.ToString();
        }

        private static string GenerateBlock(string className, Dictionary<string, int> values)
        {
            if (values.Count == 0) return string.Empty;

            var sb = new StringBuilder();
            sb.AppendLine($"\tpublic static class {className}");
            sb.AppendLine("\t{");
            foreach (var kvp in values.OrderBy(x => x.Value))
                sb.AppendLine($"\t\tpublic static UIId {kvp.Key} = {kvp.Value};");
            sb.AppendLine("\t}");
            return sb.ToString();
        }

        private static string GenerateUIMapping(
            List<string> stackEntries,
            List<string> staticEntries,
            List<string> systemEntries)
        {
            var sb = new StringBuilder();
            sb.AppendLine("// <auto-generated>");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using Domir.Client.Common.UI.Core;");
            sb.AppendLine("using Domir.Client.Contents.UI.Stack;");
            sb.AppendLine("using Domir.Client.Contents.UI.Static;");
            sb.AppendLine("using Domir.Client.Contents.UI.System;");
            sb.AppendLine();
            sb.AppendLine("namespace Domir.Client.Contents.UI.Generated");
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic static class {UIMapping}");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\tpublic static readonly Dictionary<UIId, (Type type, string prefabPath)> UI = new()");
            sb.AppendLine("\t\t{");

            if (stackEntries.Count > 0)
            {
                sb.AppendLine($"\t\t\t// {Stack}");
                foreach (var entry in stackEntries.OrderBy(x => x))
                    sb.AppendLine($"\t\t\t{entry},");
            }

            if (staticEntries.Count > 0)
            {
                sb.AppendLine($"\t\t\t// {Static}");
                foreach (var entry in staticEntries.OrderBy(x => x))
                    sb.AppendLine($"\t\t\t{entry},");
            }

            if (systemEntries.Count > 0)
            {
                sb.AppendLine($"\t\t\t// {System}");
                foreach (var entry in systemEntries.OrderBy(x => x))
                    sb.AppendLine($"\t\t\t{entry},");
            }

            sb.AppendLine("\t\t};");
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            sb.Append("// </auto-generated>");
            return sb.ToString();
        }
    }
}