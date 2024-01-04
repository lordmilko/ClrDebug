using System;
using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcWindowsKdInfrastructure.KdDebuggerDataBlock"/> property.
    /// </summary>
    [DebuggerDisplay("kdDebuggerDataBlock = {kdDebuggerDataBlock.ToString(),nq}, dataBlockSize = {dataBlockSize}")]
    public struct GetKdDebuggerDataBlockResult
    {
        public IntPtr kdDebuggerDataBlock { get; }

        public long dataBlockSize { get; }

        public GetKdDebuggerDataBlockResult(IntPtr kdDebuggerDataBlock, long dataBlockSize)
        {
            this.kdDebuggerDataBlock = kdDebuggerDataBlock;
            this.dataBlockSize = dataBlockSize;
        }
    }
}
