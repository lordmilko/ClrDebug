using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class InterfaceFieldMarshaller : FieldMarshaller
    {
        public override bool IsUnsafe => true;

        public InterfaceFieldMarshaller(string name, string managedType, string unmanagedType) : base(name, managedType, unmanagedType)
        {
        }

        public override ExpressionSyntax ToUnmanaged(string inputName)
        {
            var member = base.ToUnmanaged(inputName);

            return InvokeMarshalMethod(member, "ConvertToUnmanaged");
        }

        public override ExpressionSyntax ToManaged(string inputName)
        {
            var member = base.ToManaged(inputName);

            return InvokeMarshalMethod(member, "ConvertToManaged");
        }

        public override StatementSyntax Free(MemberAccessExpressionSyntax unmanagedMember) =>
            ExpressionStatement(InvokeMarshalMethod(unmanagedMember, "Free"));

        private ExpressionSyntax InvokeMarshalMethod(ExpressionSyntax member, string methodName)
        {
            var comInterfaceMarshaller = GenericName(Identifier("ComInterfaceMarshaller")).AddTypeArgumentListArguments(IdentifierName(ManagedType));

            var method = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, comInterfaceMarshaller, IdentifierName(methodName));

            var call = InvocationExpression(method).AddArgumentListArguments(Argument(member));

            return call;
        }
    }
}
