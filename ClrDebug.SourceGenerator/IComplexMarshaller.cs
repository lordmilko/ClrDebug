using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClrDebug.SourceGenerator
{
    internal interface IComplexMarshaller
    {
        StatementSyntax[] GetAdditionalToUnmanagedStatements(MemberAccessExpressionSyntax managedField, MemberAccessExpressionSyntax unmanagedField);

        StatementSyntax[] GetAdditionalToManagedStatements(MemberAccessExpressionSyntax unmanagedField, MemberAccessExpressionSyntax managedField);
    }
}
