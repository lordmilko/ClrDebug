using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumField"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, nameBuf = {nameBuf}, type = {type}, flags = {flags}, token = {token}")]
    public struct EnumFieldResult
    {
        public IntPtr handle { get; }

        public string nameBuf { get; }

        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public mdFieldDef token { get; }

        public EnumFieldResult(IntPtr handle, string nameBuf, XCLRDataTypeDefinition type, int flags, mdFieldDef token)
        {
            this.handle = handle;
            this.nameBuf = nameBuf;
            this.type = type;
            this.flags = flags;
            this.token = token;
        }
    }
}