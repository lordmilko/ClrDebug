using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetCodeInfo"/> method.
    /// </summary>
    [DebuggerDisplay("pStart = {pStart.ToString(),nq}, pcSize = {pcSize}")]
    public struct GetCodeInfoResult
    {
        /// <summary>
        /// A pointer to an array of bytes that compose the native code of the function.
        /// </summary>
        public IntPtr pStart { get; }

        /// <summary>
        /// A pointer to an integer that specifies the size, in bytes, of the native code.
        /// </summary>
        public int pcSize { get; }

        public GetCodeInfoResult(IntPtr pStart, int pcSize)
        {
            this.pStart = pStart;
            this.pcSize = pcSize;
        }
    }
}
