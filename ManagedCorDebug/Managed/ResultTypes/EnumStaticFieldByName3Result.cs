using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumStaticFieldByName3"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, value = {value}, tokenScope = {tokenScope}, token = {token}")]
    public struct EnumStaticFieldByName3Result
    {
        public IntPtr handle { get; }

        public XCLRDataValue value { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumStaticFieldByName3Result(IntPtr handle, XCLRDataValue value, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.handle = handle;
            this.value = value;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}