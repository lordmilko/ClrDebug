using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SymUnmanagedReader.GetPortableDebugMetadataByVersion"/> method.
    /// </summary>
    [DebuggerDisplay("metadata = {metadata.ToString(),nq}, size = {size}")]
    public struct GetPortableDebugMetadataByVersionResult
    {
        /// <summary>A pointer to memory where Portable Debug Metadata start. The memory is owned by the SymReader and
        /// valid until <see cref="SymUnmanagedDispose.Destroy"/> is invoked.
        /// 
        /// Null if the PDB is not portable.
        /// </summary>
        public IntPtr metadata { get; }

        /// <summary>
        /// Size of the metadata block.
        /// </summary>
        public int size { get; }

        public GetPortableDebugMetadataByVersionResult(IntPtr metadata, int size)
        {
            this.metadata = metadata;
            this.size = size;
        }
    }
}
