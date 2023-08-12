using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class FieldMarshaller
    {
        public string Name { get; }

        public string ManagedType { get; }

        public string UnmanagedType { get; }

        public virtual bool IsUnsafe => false;

        public FieldMarshaller(string name, string managedType, string unmanagedType)
        {
            Name = name;
            ManagedType = managedType;
            UnmanagedType = unmanagedType;
        }

        public virtual ExpressionSyntax ToUnmanaged(ExpressionSyntax managedField) => managedField;

        public virtual ExpressionSyntax ToManaged(ExpressionSyntax unmanagedField) => unmanagedField;

        public virtual StatementSyntax Free(ExpressionSyntax unmanagedMember)
        {
            return null;
        }
    }
}
