using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents a block of function arguments stored contiguously in left-to-right order in memory.
    /// </summary>
    [DebuggerDisplay("startAddress = {startAddress.ToString(),nq}, length = {length}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_PRF_FUNCTION_ARGUMENT_RANGE
    {
        /// <summary>
        /// The starting address of the block.
        /// </summary>
        public IntPtr startAddress;

        /// <summary>
        /// The length of the contiguous block.
        /// </summary>
        public int length;
    }
}
