using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.EnumField"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, field = {field}, nameBuf = {nameBuf}, token = {token}")]
    public struct XCLRDataValue_EnumFieldResult
    {
        public IntPtr handle { get; }

        public XCLRDataValue field { get; }

        public string nameBuf { get; }

        public mdFieldDef token { get; }

        public XCLRDataValue_EnumFieldResult(IntPtr handle, XCLRDataValue field, string nameBuf, mdFieldDef token)
        {
            this.handle = handle;
            this.field = field;
            this.nameBuf = nameBuf;
            this.token = token;
        }
    }
}