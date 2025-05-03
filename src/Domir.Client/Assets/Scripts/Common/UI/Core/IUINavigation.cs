using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Core.Contract;

namespace Domir.Client.Common.UI.Core
{
    public interface IUINavigation
    {
        public bool IsOpened { get; }
        public UniTask<UIShowResult> ShowAsync(UIId id, UIParam payload = null, bool immediately = false);
        public UniTask<bool> HideAsync(UIId id, UIHideResult hideResult, bool immediately = false);
        public void Remove(UIId id);
    }
}