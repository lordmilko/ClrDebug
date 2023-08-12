using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class LiteralDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        public override TypeSyntax UnmanagedType => ManagedType;

        public override bool IsUnmanagedByRef => IsManagedOut || IsManagedRef;

        public override bool NeedUnmanagedTemporary => IsManagedOut;

        public LiteralDelegateParameterMarshaller(IParameterSymbol parameter) : base(parameter)
        {
        }

        public override StatementSyntax[] ConvertToManaged
        {
            get
            {
                if (IsManagedOut)
                {
                    return new[]
                    {
                        //Assign the previously declared IntPtr variable to our real out parameter
                        ExpressionStatement(
                            AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, ManagedName, UnmanagedName)
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
                if (IsManagedOut)
                {
                    return new[]
                    {
                        SimpleVariable(UnmanagedType, UnmanagedName.ToString())
                    };
                }

                return null;
            }
        }
    }
}
