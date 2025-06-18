using Domir.Client.Data.Model;

namespace Domir.Client.Data.Repository
{
    public sealed class UserRepository : Repository<UserModel>
    {
        public bool TryGet(ulong clientId, out UserModel userModel)
        {
            foreach (var (_, model) in _models)
            {
                if (model.ClientId != clientId) continue;

                userModel = model;
                return true;
            }

            userModel = null;
            return false;
        }
    }
}