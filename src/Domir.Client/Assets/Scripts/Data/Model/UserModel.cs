namespace Domir.Client.Data.Model
{
    public sealed class UserModel : IModel
    {
        public ModelKey Key { get; }

        public ulong ClientId { get; }
        public bool IsHost { get; }

        public UserModel(ulong clientId, bool isHost)
        {
            ClientId = clientId;
            IsHost = isHost;
            Key = $"{nameof(UserModel)}_{clientId}";
        }
    }
}