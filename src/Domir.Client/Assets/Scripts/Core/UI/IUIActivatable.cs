using System.Threading;
using Cysharp.Threading.Tasks;
using Domir.Client.Core.UI.Contract;

namespace Domir.Client.Core.UI
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