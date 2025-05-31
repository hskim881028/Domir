using Domir.Client.Data.Model;

namespace Domir.Client.Data.Repository
{
    public sealed class UserRepository
    {
        public UserModel Model { get; private set; }

        public void Update(UserModel model)
        {
            Model = model;
        }
    }
}