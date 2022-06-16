using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataValue.EnumFieldByName"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, field = {field}, token = {token}")]
    public struct XCLRDataValue_EnumFieldByNameResult
    {
        public IntPtr handle { get; }

        public XCLRDataValue field { get; }

        public mdFieldDef token { get; }

        public XCLRDataValue_EnumFieldByNameResult(IntPtr handle, XCLRDataValue field, mdFieldDef token)
        {
            this.handle = handle;
            this.field = field;
            this.token = token;
        }
    }
}