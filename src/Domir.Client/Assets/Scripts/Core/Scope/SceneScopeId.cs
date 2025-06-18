using UnitGenerator;

namespace Domir.Client.Core.Scope
{
    [UnitOf(typeof(int), UnitGenerateOptions.ImplicitOperator | UnitGenerateOptions.Comparable | UnitGenerateOptions.ArithmeticOperator)]
    public readonly partial struct SceneScopeId
    {
        public static SceneScopeId Lobby = 0;
        public static SceneScopeId World = 1;

        public string ToName()
        {
            if (this == Lobby) return "Lobby";

            if (this == World) return "World";

            return "Scope";
        }
    }
}