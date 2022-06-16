using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataModule.EnumDataByName"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, value = {value}")]
    public struct EnumDataByNameResult
    {
        public IntPtr handle { get; }

        public XCLRDataValue value { get; }

        public EnumDataByNameResult(IntPtr handle, XCLRDataValue value)
        {
            this.handle = handle;
            this.value = value;
        }
    }
}