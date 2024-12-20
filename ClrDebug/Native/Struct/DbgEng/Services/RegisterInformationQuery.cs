using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An array of these structures defines a query for multiple registers in a single method call to a context.
    /// </summary>
    [DebuggerDisplay("CanonicalId = {CanonicalId}, DataOffset = {DataOffset}, DataSize = {DataSize}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct RegisterInformationQuery
    {
        /// <summary>
        /// The canonical ID of the register.
        /// </summary>
        public int CanonicalId;

        /// <summary>
        /// The offset of the register data to get/set.
        /// </summary>
        public int DataOffset;

        /// <summary>
        /// The size of the buffer for this register value.
        /// </summary>
        public int DataSize;
    }
}
