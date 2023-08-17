using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class CrossPlatformCharBufferMarshaller : RelayFieldMarshaller
    {
        public override bool IsUnsafe => true;

        public CrossPlatformCharBufferMarshaller(string name, string managedType) : base(name, managedType, "void*")
        {
        }

        internal override NameSyntax MarshallerName => IdentifierName("CrossPlatformCharBufferMarshaller");
    }
}
