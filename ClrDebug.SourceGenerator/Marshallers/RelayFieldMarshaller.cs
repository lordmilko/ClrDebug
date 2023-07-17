using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    abstract class RelayFieldMarshaller : FieldMarshaller
    {
        protected RelayFieldMarshaller(string name, string managedType, string unmanagedType) : base(name, managedType, unmanagedType)
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
            var marshaller = GetMarshallerName;

            var method = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, marshaller, IdentifierName(methodName));

            var call = InvocationExpression(method).AddArgumentListArguments(Argument(member));

            return call;
        }

        protected abstract NameSyntax GetMarshallerName { get; }
    }
}
