using MagicOnion;

namespace Domir.Shared
{
    public interface IMyFirstService : IService<IMyFirstService>
    {
        public UnaryResult<int> SumAsync(int x, int y);
        public UnaryResult<int> TastAsync(int x);
    }
}