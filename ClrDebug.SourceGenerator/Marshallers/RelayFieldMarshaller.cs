using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using System.Linq;

namespace ClrDebug.SourceGenerator
{
    abstract class RelayFieldMarshaller : FieldMarshaller
    {
        protected RelayFieldMarshaller(string name, string managedType, string unmanagedType) : base(name, managedType, unmanagedType)
        {
        }

        public override ExpressionSyntax ToUnmanaged(MemberAccessExpressionSyntax managedField) =>
            InvokeMarshalMethod("ConvertToUnmanaged", managedField);

        public override ExpressionSyntax ToManaged(MemberAccessExpressionSyntax unmanagedField) =>
            InvokeMarshalMethod("ConvertToManaged", unmanagedField);

        public override StatementSyntax Free(MemberAccessExpressionSyntax unmanagedMember) =>
            ExpressionStatement(InvokeMarshalMethod("Free", unmanagedMember));

        protected ExpressionSyntax InvokeMarshalMethod(string methodName, params CSharpSyntaxNode[] arguments)
        {
            var marshaller = GetMarshallerName;

            var method = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, marshaller, IdentifierName(methodName));

            var call = InvocationExpression(method).AddArgumentListArguments(arguments.Select(a => 
            {
                if (a is ArgumentSyntax arg)
                    return arg;

                return Argument((ExpressionSyntax)a);
            }).ToArray());

            return call;
        }

        protected abstract NameSyntax GetMarshallerName { get; }
    }
}
