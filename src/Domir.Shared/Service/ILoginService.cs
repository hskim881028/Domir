using Domir.Shared.Response;
using MagicOnion;

namespace Domir.Shared.Service
{
    public interface ILoginService : IService<ILoginService> 
    {
        public UnaryResult<LoginResponse> Login();
    }
}