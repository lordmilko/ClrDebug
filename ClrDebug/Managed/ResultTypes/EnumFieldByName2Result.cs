using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumFieldByName2"/> method.
    /// </summary>
    [DebuggerDisplay("type = {type?.ToString(),nq}, flags = {flags.ToString(),nq}, tokenScope = {tokenScope?.ToString(),nq}, token = {token.ToString(),nq}")]
    public struct EnumFieldByName2Result
    {
        public XCLRDataTypeDefinition type { get; }

        public CLRDataFieldFlag flags { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumFieldByName2Result(XCLRDataTypeDefinition type, CLRDataFieldFlag flags, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.type = type;
            this.flags = flags;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}
