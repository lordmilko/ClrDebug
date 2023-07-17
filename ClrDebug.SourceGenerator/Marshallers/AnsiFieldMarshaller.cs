using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class AnsiFieldMarshaller : RelayFieldMarshaller
    {
        public override bool IsUnsafe => true;

        public AnsiFieldMarshaller(string name, string managedType, string unmanagedType) : base(name, managedType, unmanagedType)
        {
        }

        protected override NameSyntax GetMarshallerName => IdentifierName("AnsiStringMarshaller");
    }
}
