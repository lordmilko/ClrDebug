using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    internal class FunctionPointerDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        public override TypeSyntax UnmanagedType { get; }

        public override bool NeedUnmanagedTemporary => true;

        public override bool IsUnmanagedByRef => false;

        public FunctionPointerDelegateParameterMarshaller(IParameterSymbol parameter) : base(parameter)
        {
            UnmanagedType = IdentifierName("IntPtr");
        }

        public override StatementSyntax[] ConvertToUnmanaged
        {
            get
            {
                var initializer = ConditionalExpression(
                    BinaryExpression(SyntaxKind.NotEqualsExpression, ManagedName, LiteralExpression(SyntaxKind.NullLiteralExpression)),
                    InvocationExpression(
                        MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("Marshal"), IdentifierName("GetFunctionPointerForDelegate"))
                    ).AddArgumentListArguments(Argument(ManagedName)),
                    LiteralExpression(SyntaxKind.DefaultLiteralExpression)
                );

                return new[]
                {
                    SimpleVariable(UnmanagedType, UnmanagedName.ToString(), initializer)
                };
            }
        }

        public override StatementSyntax[] ConvertToManaged
        {
            get
            {
                return new[]
                {
                    ExpressionStatement(
                        InvocationExpression(
                            MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("GC"), IdentifierName("KeepAlive"))
                        ).AddArgumentListArguments(Argument(ManagedName))
                    )
                };
            }
        }
    }
}
