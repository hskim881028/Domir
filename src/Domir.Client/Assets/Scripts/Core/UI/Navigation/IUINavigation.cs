using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Core;
using Domir.Client.Core.UI.Contract;

namespace Domir.Client.Core.UI.Navigation
{
    public interface IUINavigation
    {
        public UniTask ApplyUILayer(UILayer layer, bool immediately = false);
        public UniTask<IUIHandle> ShowStackUIAsync(UIId id, UIParam payload = null, bool immediately = false);
        public UniTask<IUIHandle> ShowSystemUIAsync(UIId id, UIParam payload = null, bool immediately = false);
        public UniTask<bool> HideStackUIAsync(UIResult result, bool immediately = false);
        public UniTask<bool> HideSystemUIAsync(UIId id, UIResult result, bool immediately = false);
    }
}