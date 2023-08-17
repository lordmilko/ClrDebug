using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    struct MarshalAsInfo
    {
        public AttributeData Attribute;
        public UnmanagedType UnmanagedType;
        public object SubType;
    }

    abstract class DelegateParameterMarshaller
    {
        public TypeSyntax ManagedType { get; protected set; }
        public NameSyntax ManagedName { get; }

        public abstract TypeSyntax UnmanagedType { get; }
        public NameSyntax UnmanagedName
        {
            get
            {
                if (NeedUnmanagedTemporary)
                    return IdentifierName($"__{ManagedName.ToString().TrimStart('@')}_native");

                return ManagedName;
            }
        }

        public virtual bool NeedUnmanagedTemporary { get; }

        public abstract bool IsUnmanagedByRef { get; }

        public bool IsManagedRef { get; }

        public bool IsManagedOut { get; protected set; }

        public virtual bool IsPinnable { get; }

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
                if (IsUnmanagedByRef && !IsPinnable)
                {
                    return PrefixUnaryExpression(SyntaxKind.AddressOfExpression, UnmanagedName);
                }

                return UnmanagedName;
            }
        }

        public virtual StatementSyntax[] ConvertToManaged { get; }

        public virtual StatementSyntax[] ConvertToUnmanaged { get; }

        public virtual StatementSyntax[] InnerStatements { get; }

        public virtual VariableDeclarationSyntax GetPinnableReference() => null;

        public virtual StatementSyntax[] GetInsideFixedStatements() => null;

        public virtual StatementSyntax[] Free { get; }

        private IParameterSymbol parameter;

        protected DelegateParameterMarshaller(IParameterSymbol parameter)
        {
            this.parameter = parameter;

            ManagedType = IdentifierName(parameter.Type.ToNiceString());

            var name = parameter.Name;

            if (name == "delegate")
                name = "@delegate";

            ManagedName = IdentifierName(name);

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

        internal static MarshalAsInfo GetMarshalAs(IParameterSymbol parameter)
        {
            var attribs = parameter.GetAttributes();

            var marshalAs = attribs.FirstOrDefault(a => a.AttributeClass.Name == "MarshalAsAttribute");

            if (marshalAs == null)
                throw new NotImplementedException($"Parameter {parameter.ContainingType.Name}.{parameter.Name} is missing a MarshalAsAttribute");

            var arg = (UnmanagedType)marshalAs.ConstructorArguments.First(a => a.Type.Name == "UnmanagedType").Value;

            var subType = marshalAs.NamedArguments.SingleOrDefault(a => a.Key == "ArraySubType").Value.Value;

            return new MarshalAsInfo
            {
                Attribute = marshalAs,
                UnmanagedType = arg,
                SubType = subType
            };
        }
    }
}
