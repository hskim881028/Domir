using Cysharp.Threading.Tasks;

namespace Common.UI
{
    public interface IUIView<in TMessage> : IUIActivatable
    {
        public string Id { get; }
        public void OnAwake();
        public void SetId(string id);
        public void AttachMessage(TMessage message);
    }
}