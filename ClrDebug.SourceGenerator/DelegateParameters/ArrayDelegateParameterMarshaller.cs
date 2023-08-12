using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    internal class ArrayDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        public override TypeSyntax UnmanagedType { get; }

        public override bool NeedUnmanagedTemporary => true;

        public override bool IsUnmanagedByRef => false;

        public ArrayDelegateParameterMarshaller(IParameterSymbol parameter) : base(parameter)
        {
            var (marshalAs, _) = GetMarshalAs();

            var subType = (System.Runtime.InteropServices.UnmanagedType) marshalAs.NamedArguments.Single(a => a.Key == "ArraySubType").Value.Value;

            switch (subType)
            {
                case System.Runtime.InteropServices.UnmanagedType.U2:
                    UnmanagedType = IdentifierName("void*");
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public override VariableDeclarationSyntax GetPinnableReference()
        {
            var marshaller = GenericName("ArrayMarshaller").AddTypeArgumentListArguments(IdentifierName("char"), IdentifierName("char"));

            var innerMarshaller = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, marshaller, IdentifierName("ManagedToUnmanagedIn"));

            var method = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, innerMarshaller, IdentifierName("GetPinnableReference"));

            var invocation = InvocationExpression(method).AddArgumentListArguments(Argument(ManagedName));

            return VariableDeclaration(UnmanagedType).AddVariables(VariableDeclarator(UnmanagedName.ToString()).WithInitializer(EqualsValueClause(PrefixUnaryExpression(SyntaxKind.AddressOfExpression, invocation))));
        }
    }
}
