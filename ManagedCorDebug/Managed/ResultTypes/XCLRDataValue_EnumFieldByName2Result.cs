using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.EnumFieldByName2"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, field = {field}, tokenScope = {tokenScope}, token = {token}")]
    public struct XCLRDataValue_EnumFieldByName2Result
    {
        public IntPtr handle { get; }

        public XCLRDataValue field { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public XCLRDataValue_EnumFieldByName2Result(IntPtr handle, XCLRDataValue field, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.handle = handle;
            this.field = field;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}