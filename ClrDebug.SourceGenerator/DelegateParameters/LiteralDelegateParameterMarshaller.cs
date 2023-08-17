using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class LiteralDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        public override TypeSyntax UnmanagedType => ManagedType;

        public override bool IsUnmanagedByRef => IsManagedOut || IsManagedRef;

        public override bool NeedUnmanagedTemporary => IsUnmanagedByRef;

        public override bool IsPinnable => IsUnmanagedByRef;

        public LiteralDelegateParameterMarshaller(IParameterSymbol parameter) : base(parameter)
        {
        }

        public override VariableDeclarationSyntax GetPinnableReference()
        {
            if (IsPinnable)
            {
                return VariableDeclaration(PointerType(ManagedType)).AddVariables(VariableDeclarator(UnmanagedName.ToString()).WithInitializer(
                    EqualsValueClause(PrefixUnaryExpression(SyntaxKind.AddressOfExpression, ManagedName))));
            }

            return null;
        }
    }
}
