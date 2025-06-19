using UnitGenerator;

namespace Domir.Client.Data.Model
{
    [UnitOf(typeof(string), UnitGenerateOptions.ImplicitOperator)]
    public readonly partial struct ModelKey { }
}