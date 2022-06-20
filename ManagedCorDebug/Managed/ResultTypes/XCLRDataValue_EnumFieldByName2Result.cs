using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.EnumFieldByName2"/> method.
    /// </summary>
    [DebuggerDisplay("field = {field.ToString(),nq}, tokenScope = {tokenScope.ToString(),nq}, token = {token.ToString(),nq}")]
    public struct XCLRDataValue_EnumFieldByName2Result
    {
        public XCLRDataValue field { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public XCLRDataValue_EnumFieldByName2Result(XCLRDataValue field, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.field = field;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}