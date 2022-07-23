using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a debug offset region.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_OFFSET_REGION
    {
        /// <summary>
        /// The base value of the offset region.
        /// </summary>
        public long Base;

        /// <summary>
        /// The size of the region.
        /// </summary>
        public long Size;
    }
}
