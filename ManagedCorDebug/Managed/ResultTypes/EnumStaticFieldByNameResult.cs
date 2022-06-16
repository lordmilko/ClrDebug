using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumStaticFieldByName"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, value = {value}")]
    public struct EnumStaticFieldByNameResult
    {
        public IntPtr handle { get; }

        public XCLRDataValue value { get; }

        public EnumStaticFieldByNameResult(IntPtr handle, XCLRDataValue value)
        {
            this.handle = handle;
            this.value = value;
        }
    }
}