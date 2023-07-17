using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class BoolFieldMarshaller : FieldMarshaller
    {
        public BoolFieldMarshaller(string name, string managedType, string unmanagedType) : base(name, managedType, unmanagedType)
        {
        }

        public override ExpressionSyntax ToUnmanaged(string inputName) =>
            ConditionalExpression(base.ToUnmanaged(inputName), LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(1)), LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0)));

        public override ExpressionSyntax ToManaged(string inputName)
        {
            var member = base.ToManaged(inputName);

            var equals = BinaryExpression(SyntaxKind.EqualsExpression, member, LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0)));

            return ConditionalExpression(equals, LiteralExpression(SyntaxKind.FalseLiteralExpression), LiteralExpression(SyntaxKind.TrueLiteralExpression));
        }
    }
}
