using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumStaticFieldByName3"/> method.
    /// </summary>
    [DebuggerDisplay("value = {value.ToString(),nq}, tokenScope = {tokenScope.ToString(),nq}, token = {token.ToString(),nq}")]
    public struct EnumStaticFieldByName3Result
    {
        public XCLRDataValue value { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumStaticFieldByName3Result(XCLRDataValue value, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.value = value;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}