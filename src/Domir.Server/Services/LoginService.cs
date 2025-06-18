using Domir.Server.UseCases.Login;
using Domir.Shared.Response;
using Domir.Shared.Services;
using MagicOnion;
using MagicOnion.Server;

namespace Domir.Server.Services;

public class LoginService(ILoginUseCase loginUseCase) : ServiceBase<ILoginService>, ILoginService
{
    public async UnaryResult<LoginResponse> Login()
    {
        var num = await loginUseCase.Test();
        var response = new LoginResponse
        {
            StatusCode = 0,
            Token = Guid.NewGuid().ToString(),
            UserId = num.ToString(),
            Username = "tester",
            IsNewUser = true,
            LastLoginAt = DateTime.UtcNow,
        };
        return response;
    }
}