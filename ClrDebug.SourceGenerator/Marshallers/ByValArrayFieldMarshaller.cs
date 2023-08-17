using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class ByValArrayFieldMarshaller : RelayFieldMarshaller, IComplexMarshaller
    {
        public override bool IsUnsafe => true;

        public string ElementType { get; }

        public ExpressionSyntax SizeConst { get; }

        public ByValArrayFieldMarshaller(string name, string managedType, string unmanagedType, string elementType, ExpressionSyntax sizeConst) : base(name, managedType, unmanagedType)
        {
            ElementType = elementType;
            SizeConst = sizeConst;
        }

        public override ExpressionSyntax ToUnmanaged(ExpressionSyntax managedField) =>
            InvokeMarshalMethod("AllocateContainerForUnmanagedElements", managedField, Argument(IdentifierName("_")).WithRefKindKeyword(Token(SyntaxKind.OutKeyword)));

        public override ExpressionSyntax ToManaged(ExpressionSyntax unmanagedField) =>
            InvokeMarshalMethod("AllocateContainerForManagedElements", unmanagedField, SizeConst);

        internal override NameSyntax MarshallerName =>
            GenericName(Identifier("ArrayMarshaller")).AddTypeArgumentListArguments(IdentifierName(ElementType), IdentifierName(ElementType));

        public StatementSyntax[] GetAdditionalToUnmanagedStatements(MemberAccessExpressionSyntax managedField, MemberAccessExpressionSyntax unmanagedField)
        {
            var managedValuesSource = InvokeMarshalMethod("GetManagedValuesSource", managedField);
            var managedValuesDestination = InvokeMarshalMethod("GetUnmanagedValuesDestination", unmanagedField, SizeConst);

            var copyTo = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, managedValuesSource, IdentifierName("CopyTo"));

            var invocation = InvocationExpression(copyTo).AddArgumentListArguments(Argument(managedValuesDestination));

            return new StatementSyntax[] { ExpressionStatement(invocation) };
        }

        public StatementSyntax[] GetAdditionalToManagedStatements(MemberAccessExpressionSyntax unmanagedField, MemberAccessExpressionSyntax managedField)
        {
            var unmanagedValuesSource = InvokeMarshalMethod("GetUnmanagedValuesSource", unmanagedField, SizeConst);
            var managedValuesDestination = InvokeMarshalMethod("GetManagedValuesDestination", managedField);

            var copyTo = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, unmanagedValuesSource, IdentifierName("CopyTo"));

            var invocation = InvocationExpression(copyTo).AddArgumentListArguments(Argument(managedValuesDestination));

            return new StatementSyntax[] { ExpressionStatement(invocation) };
        }
    }
}
