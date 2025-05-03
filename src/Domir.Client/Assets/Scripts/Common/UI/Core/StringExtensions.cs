using Domir.Client.Common.UI.Core.Presenter;

namespace Domir.Client.Common.UI.Core
{
    public static class StringExtensions
    {
        public static string AsUI(this string str)
        {
            return str
                .Replace("Presenter", string.Empty)
                .Replace(UIConfig.StaticUI, string.Empty)
                .Replace(UIConfig.StackUI, string.Empty)
                .Replace(UIConfig.SystemUI, string.Empty);
        }

        public static string AsCanvas(this string str)
        {
            var result = str
                .Replace(nameof(IStaticUIPresenter), UIConfig.Static)
                .Replace(nameof(IStackUIPresenter), UIConfig.Stack)
                .Replace(nameof(ISystemUIPresenter), UIConfig.System);
            return $"Canvas({result})";
        }
    }
}