using Microsoft.CodeAnalysis;

namespace ClrDebug.SourceGenerator
{
    static class TypeExtensions
    {
        internal static string ToNiceString(this ITypeSymbol type)
        {
            if (type is IPointerTypeSymbol p)
                return p.PointedAtType.ToNiceString() + "*";

            if (type.SpecialType != SpecialType.None)
                return type.ToString();

            return type.Name;
        }
    }
}
