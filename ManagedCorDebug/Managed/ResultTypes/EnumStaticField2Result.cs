using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumStaticField2"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, value = {value}, nameBuf = {nameBuf}, tokenScope = {tokenScope}, token = {token}")]
    public struct EnumStaticField2Result
    {
        public IntPtr handle { get; }

        public XCLRDataValue value { get; }

        public string nameBuf { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumStaticField2Result(IntPtr handle, XCLRDataValue value, string nameBuf, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.handle = handle;
            this.value = value;
            this.nameBuf = nameBuf;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}