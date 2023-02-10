using System;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents one contiguous block of native code stored in memory.
    /// </summary>
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
        [MarshalAs(UnmanagedType.SysInt)]
        public long size;
    }
}
