using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataModule.EnumExtent"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, extent = {extent}")]
    public struct XCLRDataModule_EnumExtentResult
    {
        public IntPtr handle { get; }

        public CLRDATA_MODULE_EXTENT extent { get; }

        public XCLRDataModule_EnumExtentResult(IntPtr handle, CLRDATA_MODULE_EXTENT extent)
        {
            this.handle = handle;
            this.extent = extent;
        }
    }
}