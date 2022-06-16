using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataMethodDefinition.EnumExtent"/> method.
    /// </summary>
    [DebuggerDisplay("handle = {handle}, extent = {extent}")]
    public struct EnumExtentResult
    {
        public IntPtr handle { get; }

        public CLRDATA_METHDEF_EXTENT extent { get; }

        public EnumExtentResult(IntPtr handle, CLRDATA_METHDEF_EXTENT extent)
        {
            this.handle = handle;
            this.extent = extent;
        }
    }
}