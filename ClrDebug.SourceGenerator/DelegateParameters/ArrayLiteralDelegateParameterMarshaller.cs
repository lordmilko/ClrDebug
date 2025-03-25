using System;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    internal class ArrayLiteralDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        public override TypeSyntax UnmanagedType { get; }

        public override bool NeedUnmanagedTemporary => true;

        public override bool IsUnmanagedByRef => false;

        private string rawType;

        private bool canPin;

        public ArrayLiteralDelegateParameterMarshaller(IParameterSymbol parameter, UnmanagedType subType) : base(parameter)
        {
            switch (subType)
            {
                case System.Runtime.InteropServices.UnmanagedType.U1:
                    UnmanagedType = IdentifierName("void*");
                    rawType = "byte";
                    canPin = true;
                    break;
                case System.Runtime.InteropServices.UnmanagedType.U2:
                    UnmanagedType = IdentifierName("void*");
                    rawType = "char";
                    canPin = true;
                    break;
                case System.Runtime.InteropServices.UnmanagedType.SysInt:
                    UnmanagedType = IdentifierName("void*");
                    rawType = "IntPtr";
                    canPin = true;
                    break;

                default:
                    throw new NotImplementedException($"Don't know how to marshal an array of type '{subType}'");
            }
        }

        public override VariableDeclarationSyntax GetPinnableReference()
        {
            if (!canPin)
                return null;

            var marshaller = GenericName("ArrayMarshaller").AddTypeArgumentListArguments(IdentifierName(rawType), IdentifierName(rawType));

            var innerMarshaller = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, marshaller, IdentifierName("ManagedToUnmanagedIn"));

            var method = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, innerMarshaller, IdentifierName("GetPinnableReference"));

            var invocation = InvocationExpression(method).AddArgumentListArguments(Argument(ManagedName));

            return VariableDeclaration(UnmanagedType).AddVariables(VariableDeclarator(UnmanagedName.ToString()).WithInitializer(EqualsValueClause(PrefixUnaryExpression(SyntaxKind.AddressOfExpression, invocation))));
        }
    }
}
