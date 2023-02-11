using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents one contiguous block of native code stored in memory.
    /// </summary>
    [DebuggerDisplay("startAddress = {startAddress.ToString(),nq}, size = {size}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_PRF_CODE_INFO
    {
        /// <summary>
        /// The starting address of the contiguous block of code.
        /// </summary>
        public IntPtr startAddress;

        /// <summary>
        /// The size of the block.
        /// </summary>
        public IntPtr size;
    }
}
