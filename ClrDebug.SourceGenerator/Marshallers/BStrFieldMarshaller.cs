using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class BStrFieldMarshaller : RelayFieldMarshaller
    {
        public override bool IsUnsafe => true;

        public BStrFieldMarshaller(string name, string managedType, string unmanagedType) : base(name, managedType, unmanagedType)
        {
        }

        protected override NameSyntax GetMarshallerName => IdentifierName("BStrStringMarshaller");
    }
}
