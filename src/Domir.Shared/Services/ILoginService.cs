using Domir.Shared.Response;
using MagicOnion;

namespace Domir.Shared.Services
{
    public interface ILoginService : IService<ILoginService>
    {
        public UnaryResult<LoginResponse> Login();
    }
}