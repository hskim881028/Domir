using Cysharp.Threading.Tasks;

namespace Common.UI
{
    public interface IUIActivatable
    {
        public UniTask InitializeAsync();
        public UniTask ShowAsync();
        public UniTask HideAsync();
    }
}