using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumStaticFieldByName3"/> method.
    /// </summary>
    [DebuggerDisplay("value = {value}, tokenScope = {tokenScope}, token = {token}")]
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