using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace ClrDebug.SourceGenerator
{
    class InterfaceFieldMarshaller : RelayFieldMarshaller
    {
        public override bool IsUnsafe => true;

        public InterfaceFieldMarshaller(string name, string managedType, string unmanagedType) : base(name, managedType, unmanagedType)
        {
        }

        internal override NameSyntax MarshallerName =>
            GenericName(Identifier("ComInterfaceMarshaller")).AddTypeArgumentListArguments(IdentifierName(ManagedType));
    }
}
