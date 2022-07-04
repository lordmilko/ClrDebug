using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumStaticField2"/> method.
    /// </summary>
    [DebuggerDisplay("value = {value.ToString(),nq}, nameBuf = {nameBuf}, tokenScope = {tokenScope.ToString(),nq}, token = {token.ToString(),nq}")]
    public struct EnumStaticField2Result
    {
        public XCLRDataValue value { get; }

        public string nameBuf { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumStaticField2Result(XCLRDataValue value, string nameBuf, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.value = value;
            this.nameBuf = nameBuf;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}
