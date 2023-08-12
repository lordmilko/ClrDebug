using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClrDebug.SourceGenerator
{
    class GuidDelegateParameterMarshaller : DelegateParameterMarshaller
    {
        public override TypeSyntax UnmanagedType => ManagedType;

        public override bool IsUnmanagedByRef => true;

        public GuidDelegateParameterMarshaller(IParameterSymbol parameter) : base(parameter)
        {
        }
    }
}
