using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugDataTarget.ReadVirtual"/> method.
    /// </summary>
    [DebuggerDisplay("pBuffer = {pBuffer}, pBytesRead = {pBytesRead}")]
    public struct CorDebugDataTarget_ReadVirtualResult
    {
        /// <summary>
        /// The buffer where the memory will be stored.
        /// </summary>
        public IntPtr pBuffer { get; }

        /// <summary>
        /// The number of bytes actually read from the target address. This can be fewer than bytesRequested.
        /// </summary>
        public int pBytesRead { get; }

        public CorDebugDataTarget_ReadVirtualResult(IntPtr pBuffer, int pBytesRead)
        {
            this.pBuffer = pBuffer;
            this.pBytesRead = pBytesRead;
        }
    }
}