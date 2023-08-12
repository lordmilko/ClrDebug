using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    abstract class DelegateParameterMarshaller
    {
        public TypeSyntax ManagedType { get; }
        public NameSyntax ManagedName { get; }

        public abstract TypeSyntax UnmanagedType { get; }
        public NameSyntax UnmanagedName
        {
            get
            {
                if (NeedUnmanagedTemporary)
                    return IdentifierName($"__{ManagedName}_native");

                return ManagedName;
            }
        }

        public virtual bool NeedUnmanagedTemporary { get; }

        public abstract bool IsUnmanagedByRef { get; }

        public bool IsManagedRef { get; }

        public bool IsManagedOut { get; }

        public TypeSyntax UnmanagedArgumentType
        {
            get
            {
                if (IsUnmanagedByRef)
                    return PointerType(UnmanagedType);

                return UnmanagedType;
            }
        }

        public ExpressionSyntax UnmanagedArgument
        {
            get
            {
                if (IsUnmanagedByRef)
                {
                    return PrefixUnaryExpression(SyntaxKind.AddressOfExpression, UnmanagedName);
                }

                return UnmanagedName;
            }
        }

        public virtual StatementSyntax[] ConvertToManaged { get; }

        public virtual StatementSyntax[] ConvertToUnmanaged { get; }

        public virtual VariableDeclarationSyntax GetPinnableReference() => null;

        public virtual StatementSyntax[] Free { get; }

        private IParameterSymbol parameter;

        protected DelegateParameterMarshaller(IParameterSymbol parameter)
        {
            this.parameter = parameter;

            ManagedType = IdentifierName(parameter.Type.ToNiceString());
            ManagedName = IdentifierName(parameter.Name);

            IsManagedOut = parameter.RefKind == RefKind.Out;
            IsManagedRef = parameter.RefKind == RefKind.Ref;
        }

        protected LocalDeclarationStatementSyntax SimpleVariable(TypeSyntax type, string name, ExpressionSyntax initializer = null)
        {
            return LocalDeclarationStatement(
                VariableDeclaration(type).AddVariables(
                    VariableDeclarator(name).WithInitializer(initializer == null ? null : EqualsValueClause(initializer))
                )
            );
        }

        protected StatementSyntax GetSkipInit()
        {
            return ExpressionStatement(
                InvocationExpression(
                    MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        QualifiedName(IdentifierName("System.Runtime.CompilerServices"), IdentifierName("Unsafe")),
                        IdentifierName("SkipInit")
                    )
                ).AddArgumentListArguments(Argument(ManagedName).WithRefKindKeyword(Token(SyntaxKind.OutKeyword)))
            );
        }

        protected (AttributeData marshalAs, UnmanagedType unmanagedType) GetMarshalAs()
        {
            var attribs = parameter.GetAttributes();

            var marshalAs = attribs.FirstOrDefault(a => a.AttributeClass.Name == "MarshalAsAttribute");

            if (marshalAs == null)
                throw new NotImplementedException();

            var arg = (UnmanagedType)marshalAs.ConstructorArguments.First(a => a.Type.Name == "UnmanagedType").Value;

            return (marshalAs, arg);
        }
    }
}
