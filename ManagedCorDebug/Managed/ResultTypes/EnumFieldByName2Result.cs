using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumFieldByName2"/> method.
    /// </summary>
    [DebuggerDisplay("type = {type}, flags = {flags}, tokenScope = {tokenScope}, token = {token}")]
    public struct EnumFieldByName2Result
    {
        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumFieldByName2Result(XCLRDataTypeDefinition type, int flags, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.type = type;
            this.flags = flags;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}