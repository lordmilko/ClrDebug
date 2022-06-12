using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CLRMetadataLocator.GetMetadata"/> method.
    /// </summary>
    public struct GetMetadataResult
    {
        /// <summary>
        /// [out] The buffer in which to place the metadata.
        /// </summary>
        public IntPtr buffer { get; }

        /// <summary>
        /// [out] The size of the metadata that is returned.
        /// </summary>
        public int dataSize { get; }

        public GetMetadataResult(IntPtr buffer, int dataSize)
        {
            this.buffer = buffer;
            this.dataSize = dataSize;
        }
    }
}