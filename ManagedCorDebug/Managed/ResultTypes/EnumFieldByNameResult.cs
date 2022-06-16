using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeDefinition.EnumFieldByName"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, type = {type}, flags = {flags}, token = {token}")]
    public struct EnumFieldByNameResult
    {
        public IntPtr handle { get; }

        public XCLRDataTypeDefinition type { get; }

        public int flags { get; }

        public mdFieldDef token { get; }

        public EnumFieldByNameResult(IntPtr handle, XCLRDataTypeDefinition type, int flags, mdFieldDef token)
        {
            this.handle = handle;
            this.type = type;
            this.flags = flags;
            this.token = token;
        }
    }
}