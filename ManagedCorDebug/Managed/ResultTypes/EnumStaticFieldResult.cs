using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumStaticField"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, value = {value}")]
    public struct EnumStaticFieldResult
    {
        public IntPtr handle { get; }

        public XCLRDataValue value { get; }

        public EnumStaticFieldResult(IntPtr handle, XCLRDataValue value)
        {
            this.handle = handle;
            this.value = value;
        }
    }
}