using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CeeGen.AllocateMethodBuffer"/> method.
    /// </summary>
    [DebuggerDisplay("lpBuffer = {lpBuffer.ToString(),nq}, RVA = {RVA}")]
    public struct AllocateMethodBufferResult
    {
        /// <summary>
        /// The returned buffer.
        /// </summary>
        public IntPtr lpBuffer { get; }

        /// <summary>
        /// The relative virtual address of the method.
        /// </summary>
        public int RVA { get; }

        public AllocateMethodBufferResult(IntPtr lpBuffer, int RVA)
        {
            this.lpBuffer = lpBuffer;
            this.RVA = RVA;
        }
    }
}