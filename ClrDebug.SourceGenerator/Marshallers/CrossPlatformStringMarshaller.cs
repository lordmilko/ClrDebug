using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class CrossPlatformStringMarshaller : RelayFieldMarshaller
    {
        public override bool IsUnsafe => true;

        public CrossPlatformStringMarshaller(string name, string managedType) : base(name, managedType, "byte*")
        {
        }

        internal override NameSyntax MarshallerName => IdentifierName("CrossPlatformStringMarshaller");
    }
}
