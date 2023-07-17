using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class UTF16FieldMarshaller : RelayFieldMarshaller
    {
        public override bool IsUnsafe => true;

        public UTF16FieldMarshaller(string name, string managedType, string unmanagedType) : base(name, managedType, unmanagedType)
        {
        }

        protected override NameSyntax GetMarshallerName => IdentifierName("Utf16StringMarshaller");
    }
}
