using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.EnumField2"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field}, nameBuf = {nameBuf}, tokenScope = {tokenScope}, token = {token}")]
    public struct XCLRDataValue_EnumField2Result
    {
        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public XCLRDataValue_EnumField2Result(XCLRDataValue field, string nameBuf, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.field = field;
            this.nameBuf = nameBuf;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}