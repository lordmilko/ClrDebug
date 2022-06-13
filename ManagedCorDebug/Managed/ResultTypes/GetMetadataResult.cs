using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRMetadataLocator.GetMetadata"/> method.
    /// </summary>
    [DebuggerDisplay("buffer = {buffer}, dataSize = {dataSize}")]
    public struct GetMetadataResult
    {
        /// <summary>
        /// The buffer in which to place the metadata.
        /// </summary>
        public IntPtr buffer { get; }

        /// <summary>
        /// The size of the metadata that is returned.
        /// </summary>
        public int dataSize { get; }

        public GetMetadataResult(IntPtr buffer, int dataSize)
        {
            this.buffer = buffer;
            this.dataSize = dataSize;
        }
    }
}