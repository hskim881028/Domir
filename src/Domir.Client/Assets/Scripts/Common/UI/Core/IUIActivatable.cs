using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Common.UI.Core.Contract;

namespace Domir.Client.Common.UI.Core
{
    public interface IUIActivatable
    {
        public UniTask InitializeAsync(CancellationToken token);
        public UniTask ShowAsync(CancellationToken token, UIParam param, bool immediately = false);
        public UniTask HideAsync(CancellationToken token, bool immediately = false);
        public void Activate(float opacity = 1);
        public void Deactivate();
    }
}