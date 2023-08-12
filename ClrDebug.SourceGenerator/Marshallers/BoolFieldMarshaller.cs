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

        public override ExpressionSyntax ToUnmanaged(ExpressionSyntax managedField) =>
            ConditionalExpression(managedField, LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(1)), LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0)));

        public override ExpressionSyntax ToManaged(ExpressionSyntax unmanagedField)
        {
            var equals = BinaryExpression(SyntaxKind.EqualsExpression, unmanagedField, LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(0)));

            return ConditionalExpression(equals, LiteralExpression(SyntaxKind.FalseLiteralExpression), LiteralExpression(SyntaxKind.TrueLiteralExpression));
        }
    }
}
