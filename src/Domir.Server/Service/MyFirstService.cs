using Domir.Shared;
using MagicOnion;
using MagicOnion.Server;

namespace Domir.Server.Service;

public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
{
    // `UnaryResult<T>` allows the method to be treated as `async` method.
    public async UnaryResult<int> SumAsync(int x, int y)
    {
        Console.WriteLine($"Received:{x}, {y}");
        return x + y;
    }

    public async UnaryResult<int> TastAsync(int x)
    {
        Console.WriteLine($"Received:{x}");
        return x;
    }
}