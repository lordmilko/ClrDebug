using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    internal class RelayDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        private FieldMarshaller marshaller;

        public override TypeSyntax UnmanagedType { get; }

        public override bool NeedUnmanagedTemporary => true;

        public override bool IsUnmanagedByRef => IsManagedOut || IsManagedRef;

        private bool canPin;

        public RelayDelegateParameterMarshaller(IParameterSymbol parameter) : base(parameter)
        {
            var (_, arg) = GetMarshalAs();

            switch (arg)
            {
                case System.Runtime.InteropServices.UnmanagedType.LPWStr:
                    marshaller = new UTF16FieldMarshaller(string.Empty, parameter.Type.ToNiceString(), "ushort*");

                    if (!IsManagedOut && !IsManagedRef && parameter.Type.SpecialType == SpecialType.System_String)
                    {
                        canPin = true;
                        UnmanagedType = IdentifierName("void*");
                    }
                    else
                        UnmanagedType = IdentifierName("ushort*");

                    break;

                case System.Runtime.InteropServices.UnmanagedType.Bool:
                    UnmanagedType = IdentifierName("int");
                    marshaller = new BoolFieldMarshaller(string.Empty, parameter.Type.ToNiceString(), "int");
                    break;

                case System.Runtime.InteropServices.UnmanagedType.Interface:
                    UnmanagedType = IdentifierName("void*");
                    marshaller = new InterfaceFieldMarshaller(string.Empty, parameter.Type.ToNiceString(), "void*");
                    break;

                default:
                    throw new NotImplementedException($"Don't know how to handle unmanaged type {arg}");
            }
        }

        public override StatementSyntax[] ConvertToManaged
        {
            get
            {
                if (canPin)
                    return null;

                if (IsManagedOut)
                {
                    return new[]
                    {
                        //Assign the previously declared IntPtr variable to our real out parameter
                        ExpressionStatement(
                            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, ManagedName, marshaller.ToManaged(UnmanagedName))
                        )
                    };
                }

                return null;
            }
        }

        public override StatementSyntax[] ConvertToUnmanaged
        {
            get
            {
                if (canPin)
                    return null;

                ExpressionSyntax marshal;

                if (!IsManagedOut)
                    marshal = marshaller.ToUnmanaged(ManagedName);
                else
                    marshal = LiteralExpression(SyntaxKind.DefaultLiteralExpression);

                var statements = new List<StatementSyntax>
                {
                    SimpleVariable(UnmanagedType, UnmanagedName.ToString(), marshal)
                };

                if (IsManagedOut)
                    statements.Insert(0, GetSkipInit());

                return statements.ToArray();
            }
        }

        public override StatementSyntax[] Free
        {
            get
            {
                if (canPin)
                    return null;

                var expr = marshaller.Free(UnmanagedName);

                if (expr != null)
                    return new[] { expr };

                return null;
            }
        }

        public override VariableDeclarationSyntax GetPinnableReference()
        {
            if (!canPin)
                return null;

            if (ManagedType.ToString() != "string")
                throw new NotImplementedException();

            var method = MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName("Utf16StringMarshaller"), IdentifierName("GetPinnableReference"));

            var invocation = InvocationExpression(method).AddArgumentListArguments(Argument(ManagedName));

            return VariableDeclaration(UnmanagedType).AddVariables(VariableDeclarator(UnmanagedName.ToString()).WithInitializer(EqualsValueClause(PrefixUnaryExpression(SyntaxKind.AddressOfExpression, invocation))));
        }
    }
}
