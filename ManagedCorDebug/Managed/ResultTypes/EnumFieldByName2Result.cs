using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumFieldByName2"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, type = {type}, flags = {flags}, tokenScope = {tokenScope}, token = {token}")]
    public struct EnumFieldByName2Result
    {
        public IntPtr handle { get; }

        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumFieldByName2Result(IntPtr handle, XCLRDataTypeDefinition type, int flags, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.handle = handle;
            this.type = type;
            this.flags = flags;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}