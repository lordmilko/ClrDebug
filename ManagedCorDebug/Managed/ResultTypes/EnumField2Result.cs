using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumField2"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, nameBuf = {nameBuf}, type = {type}, flags = {flags}, tokenScope = {tokenScope}, token = {token}")]
    public struct EnumField2Result
    {
        public IntPtr handle { get; }

        public string nameBuf { get; }

        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public XCLRDataModule tokenScope { get; }

        public mdFieldDef token { get; }

        public EnumField2Result(IntPtr handle, string nameBuf, XCLRDataTypeDefinition type, int flags, XCLRDataModule tokenScope, mdFieldDef token)
        {
            this.handle = handle;
            this.nameBuf = nameBuf;
            this.type = type;
            this.flags = flags;
            this.tokenScope = tokenScope;
            this.token = token;
        }
    }
}