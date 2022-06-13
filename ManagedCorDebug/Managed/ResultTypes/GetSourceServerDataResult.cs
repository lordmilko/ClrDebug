using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedSourceServerModule.SourceServerData"/> property.
    /// </summary>
    [DebuggerDisplay("pDataByteCount = {pDataByteCount}, ppData = {ppData}")]
    public struct GetSourceServerDataResult
    {
        /// <summary>
        /// A pointer to a ULONG32 that receives the size, in bytes, of the source server data.
        /// </summary>
        public int pDataByteCount { get; }

        /// <summary>
        /// A pointer to the returned pDataByteCount value.
        /// </summary>
        public IntPtr ppData { get; }

        public GetSourceServerDataResult(int pDataByteCount, IntPtr ppData)
        {
            this.pDataByteCount = pDataByteCount;
            this.ppData = ppData;
        }
    }
}