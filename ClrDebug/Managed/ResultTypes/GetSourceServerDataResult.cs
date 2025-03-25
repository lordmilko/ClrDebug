using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.SourceServerData"/> property.
    /// </summary>
    [DebuggerDisplay("data = {data.ToString(),nq}, size = {size}")]
    public struct GetSourceServerDataResult
    {
        /// <summary>A pointer to memory where Source Server data start. The memory is owned by the SymReader and
        /// valid until <see cref="SymUnmanagedDispose.Destroy"/> is invoked.
        /// 
        /// Null if the PDB doesn't contain Source Server data.
        /// </summary>
        public IntPtr data { get; }

        /// <summary>
        /// Size of the data in bytes.
        /// </summary>
        public int size { get; }

        public GetSourceServerDataResult(IntPtr data, int size)
        {
            this.data = data;
            this.size = size;
        }
    }
}
