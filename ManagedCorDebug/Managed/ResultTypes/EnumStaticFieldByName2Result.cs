using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataTypeInstance.EnumStaticFieldByName2"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, value = {value}")]
    public struct EnumStaticFieldByName2Result
    {
        public IntPtr handle { get; }

        public XCLRDataValue value { get; }

        public EnumStaticFieldByName2Result(IntPtr handle, XCLRDataValue value)
        {
            this.handle = handle;
            this.value = value;
        }
    }
}