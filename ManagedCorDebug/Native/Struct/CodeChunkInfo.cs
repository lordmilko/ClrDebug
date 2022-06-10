using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Represents a single chunk of code in memory.
    /// </summary>
    /// <remarks>
    /// The single chunk of code is a region of native code that is part of a code object such as a function.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct CodeChunkInfo
    {
        /// <summary>
        /// A <see cref="CORDB_ADDRESS"/> value that specifies the starting address of the chunk.
        /// </summary>
        public ulong startAddr;

        /// <summary>
        /// The size, in bytes, of the chunk.
        /// </summary>
        public uint length;
    }
}