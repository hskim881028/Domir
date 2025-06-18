using System;
using System.IO;
using System.Text;
using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Domir.Client.Editor
{
    public class UIScriptGenerator : EditorWindow
    {
        private EditorConfig.UIType _uiType = EditorConfig.UIType.Stack;

        private string _className = "";

        [MenuItem("Domir/Generate UI Scripts")]
        public static void ShowWindow()
        {
            GetWindow<UIScriptGenerator>("Generate UI Scripts");
        }

        private void OnGUI()
        {
            GUILayout.Label("Generate UI Scripts", EditorStyles.boldLabel);
            _className = EditorGUILayout.TextField("Class Name", _className);
            _uiType = (EditorConfig.UIType)EditorGUILayout.EnumPopup("UI Type", _uiType);
            if (GUILayout.Button("Create"))
            {
                CreateAsync().Forget();
            }
        }

        private async UniTaskVoid CreateAsync()
        {
            var result = await CreateUIScriptsAsync(_className);
            if (result)
            {
                Close();
                AssetDatabase.Refresh();
                Debug.Log($"✅ Successfully generated UI scripts for '{_className}'");
            }
            else
            {
                Debug.LogError($"❌ Failed to generate UI scripts for '{_className}'");
            }
        }

        private async UniTask<bool> CreateUIScriptsAsync(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
            {
                Debug.LogError("Class name cannot be empty.");
                return false;
            }

            var rootPath = _uiType.ToPath();
            if (!Directory.Exists(rootPath))
            {
                Debug.LogError($"Directory not found: {rootPath}");
                return false;
            }

            var message = _uiType.ToMessage(prefix);
            var view = _uiType.ToView(prefix);
            var baseView = _uiType.ToView();
            var presenter = _uiType.ToPresenter(prefix);
            var basePresenter = _uiType.ToPresenter();

            var interfacePath = Path.Combine(rootPath, $"I{message}.cs");
            var viewPath = Path.Combine(rootPath, $"{view}.cs");
            var presenterPath = Path.Combine(rootPath, $"{presenter}.cs");

            if (File.Exists(interfacePath) || File.Exists(viewPath) || File.Exists(presenterPath))
            {
                Debug.LogError("One or more target files already exist. Aborting to prevent overwrite.");
                return false;
            }

            try
            {
                await File.WriteAllTextAsync(interfacePath, GenerateInterface(message));
                await File.WriteAllTextAsync(viewPath, GenerateView(message, view, baseView));
                await File.WriteAllTextAsync(presenterPath, GeneratePresenter(message, view, presenter, basePresenter));
                return true;
            }
            catch (Exception ex)
            {
                Debug.LogError($"Exception while generating scripts: {ex.Message}");
                return false;
            }
        }

        private string GenerateInterface(string message)
        {
            var sb = new StringBuilder();
            sb.AppendLine(EditorConfig.UsingCore);
            sb.AppendLine();
            sb.AppendLine(_uiType.ToContentsNamespace());
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic interface {message} : IUIMessage {{ }}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private string GenerateView(string message, string view, string baseView)
        {
            var sb = new StringBuilder();
            sb.AppendLine(EditorConfig.UsingView);
            sb.AppendLine();
            sb.AppendLine(_uiType.ToContentsNamespace());
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic class {view} : {baseView}<{message}> {{ }}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private string GeneratePresenter(string message, string view, string presenter, string basePresenter)
        {
            var sb = new StringBuilder();

            switch (_uiType)
            {
                case EditorConfig.UIType.Static:
                    sb.AppendLine(EditorConfig.UsingSystem);
                    sb.AppendLine(EditorConfig.UsingGeneric);
                    sb.AppendLine(EditorConfig.UsingCore);
                    break;
                case EditorConfig.UIType.Stack:
                    break;
                case EditorConfig.UIType.System:
                    sb.AppendLine(EditorConfig.UsingSystem);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            sb.AppendLine(EditorConfig.UsingNavigation);
            sb.AppendLine(EditorConfig.UsingPresenter);
            sb.AppendLine();
            sb.AppendLine(_uiType.ToContentsNamespace());
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic class {presenter} : {basePresenter}<{view}, {message}>, {message}");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\tpublic {presenter}({view} view, IUINavigation navigation) : base(view, navigation) {{ }}");
            switch (_uiType)
            {
                case EditorConfig.UIType.Static:
                    sb.AppendLine($"\t\tprotected override HashSet<UILayer> Layer => UILayer.SetDefault;");
                    sb.AppendLine($"\t\tpublic override UIPriority Priority => UIPriority.Default;");
                    break;
                case EditorConfig.UIType.Stack:
                    break;
                case EditorConfig.UIType.System:
                    sb.AppendLine($"\t\tpublic override UIPriority Priority => UIPriority.Default;");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}