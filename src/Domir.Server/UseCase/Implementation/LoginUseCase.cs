namespace Domir.Server.UseCase.Implementation;

public class LoginUseCase : ILoginUseCase
{
    public Task<int> Test()
    {
        return Task.FromResult(505050);
    }
}