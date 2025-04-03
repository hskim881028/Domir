using Domir.Server.UseCase;
using Domir.Shared.Response;
using Domir.Shared.Service;
using MagicOnion;
using MagicOnion.Server;

namespace Domir.Server.Service;

public class LoginService(ILoginUseCase loginUseCase) : ServiceBase<ILoginService>, ILoginService
{
    public async UnaryResult<LoginResponse> Login()
    {
        var num = await loginUseCase.Test();
        var response = new LoginResponse
        {
            ResponseCode = 777,
            TEST = num,
            TESTTTTTTT = "ekwljrwlkejrewoi"
        };
        return response;
    }
}