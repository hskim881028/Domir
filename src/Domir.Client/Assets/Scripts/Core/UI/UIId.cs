using UnitGenerator;

namespace Domir.Client.Common.UI.Core
{
    [UnitOf(typeof(int), UnitGenerateOptions.ImplicitOperator | UnitGenerateOptions.Comparable)]
    public readonly partial struct UIId { }
}