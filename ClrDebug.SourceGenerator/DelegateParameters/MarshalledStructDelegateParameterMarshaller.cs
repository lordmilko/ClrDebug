using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    internal class MarshalledStructDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        public override TypeSyntax UnmanagedType { get; }

        public override bool NeedUnmanagedTemporary => true;

        public override bool IsUnmanagedByRef => IsManagedOut || IsManagedRef;

        MemberAccessExpressionSyntax marshaler;

        public MarshalledStructDelegateParameterMarshaller(IParameterSymbol parameter) : base(parameter)
        {
            UnmanagedType = IdentifierName($"{ManagedType}.{ManagedType}_Native");

            marshaler = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, ManagedType, IdentifierName("Marshaller"));
        }

        public override StatementSyntax[] ConvertToManaged
        {
            get
            {
                var expr = InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        marshaler,
                        IdentifierName("ConvertToManaged")
                    )
                ).AddArgumentListArguments(Argument(UnmanagedName));

                return new[]
                {
                    ExpressionStatement(
                        AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, ManagedName, expr)
                    )
                };
            }
        }

        public override StatementSyntax[] ConvertToUnmanaged
        {
            get
            {
                if (IsManagedOut)
                    return null;

                var initializer = InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        marshaler,
                        IdentifierName("ConvertToUnmanaged")
                    )
                ).AddArgumentListArguments(Argument(ManagedName));

                return new[]
                {
                    SimpleVariable(UnmanagedType, UnmanagedName.ToString(), initializer)
                };
            }
        }
    }
}
