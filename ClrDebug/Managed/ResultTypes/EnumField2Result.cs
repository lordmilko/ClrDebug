using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumField2"/> method.
    /// </summary>
    [DebuggerDisplay("nameBuf = {nameBuf}, type = {type.ToString(),nq}, flags = {flags}, tokenScope = {tokenScope.ToString(),nq}, token = {token.ToString(),nq}")]
    public struct EnumField2Result
    {
        public string nameBuf { get; }

        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumField2Result(string nameBuf, XCLRDataTypeDefinition type, int flags, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.nameBuf = nameBuf;
            this.type = type;
            this.flags = flags;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}
