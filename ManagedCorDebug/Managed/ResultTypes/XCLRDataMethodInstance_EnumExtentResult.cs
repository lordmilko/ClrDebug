using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataMethodInstance.EnumExtent"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, extent = {extent}")]
    public struct XCLRDataMethodInstance_EnumExtentResult
    {
        public IntPtr handle { get; }

        public CLRDATA_ADDRESS_RANGE[] extent { get; }

        public XCLRDataMethodInstance_EnumExtentResult(IntPtr handle, CLRDATA_ADDRESS_RANGE[] extent)
        {
            this.handle = handle;
            this.extent = extent;
        }
    }
}