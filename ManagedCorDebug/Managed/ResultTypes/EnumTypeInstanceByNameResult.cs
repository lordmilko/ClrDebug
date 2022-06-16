using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataModule.EnumTypeInstanceByName"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, type = {type}")]
    public struct EnumTypeInstanceByNameResult
    {
        public IntPtr handle { get; }

        public XCLRDataTypeInstance type { get; }

        public EnumTypeInstanceByNameResult(IntPtr handle, XCLRDataTypeInstance type)
        {
            this.handle = handle;
            this.type = type;
        }
    }
}