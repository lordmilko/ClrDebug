using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CeeGen.AllocateMethodBuffer"/> method.
    /// </summary>
    public struct AllocateMethodBufferResult
    {
        /// <summary>
        /// [out] The returned buffer.
        /// </summary>
        public IntPtr lpBuffer { get; }

        /// <summary>
        /// [out] The relative virtual address of the method.
        /// </summary>
        public int rVA { get; }

        public AllocateMethodBufferResult(IntPtr lpBuffer, int rVA)
        {
            this.lpBuffer = lpBuffer;
            this.rVA = rVA;
        }
    }
}