using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.EnumField2"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, field = {field}, nameBuf = {nameBuf}, tokenScope = {tokenScope}, token = {token}")]
    public struct XCLRDataValue_EnumField2Result
    {
        public IntPtr handle { get; }

        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public XCLRDataValue_EnumField2Result(IntPtr handle, XCLRDataValue field, string nameBuf, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.handle = handle;
            this.field = field;
            this.nameBuf = nameBuf;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}