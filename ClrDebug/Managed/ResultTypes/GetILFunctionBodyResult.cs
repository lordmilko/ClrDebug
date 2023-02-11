using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetILFunctionBody"/> method.
    /// </summary>
    [DebuggerDisplay("ppMethodHeader = {ppMethodHeader.ToString(),nq}, pcbMethodSize = {pcbMethodSize}")]
    public struct GetILFunctionBodyResult
    {
        /// <summary>
        /// A pointer to the method's header.
        /// </summary>
        public IntPtr ppMethodHeader { get; }

        /// <summary>
        /// An integer that specifies the size of the method.
        /// </summary>
        public int pcbMethodSize { get; }

        public GetILFunctionBodyResult(IntPtr ppMethodHeader, int pcbMethodSize)
        {
            this.ppMethodHeader = ppMethodHeader;
            this.pcbMethodSize = pcbMethodSize;
        }
    }
}
