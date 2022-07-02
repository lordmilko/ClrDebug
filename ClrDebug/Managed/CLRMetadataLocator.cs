using System;

namespace ClrDebug
{
    /// <summary>
    /// Used by the data access services layer to locate metadata of assemblies in a target process.
    /// </summary>
    /// <remarks>
    /// The API client (that is, the debugger) must implement this interface as appropriate for the particular target process.
    /// For example, the implementation for a live process would be different from that of a memory dump.
    /// </remarks>
    public class CLRMetadataLocator : ComObject<ICLRMetadataLocator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CLRMetadataLocator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CLRMetadataLocator(ICLRMetadataLocator raw) : base(raw)
        {
        }

        #region ICLRMetadataLocator
        #region GetMetadata

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to retrieve the metadata of an image.
        /// </summary>
        /// <param name="imagePath">[in] A string that specifies the path of the image file.</param>
        /// <param name="imageTimestamp">[in] The time stamp of the image file.</param>
        /// <param name="imageSize">[in] The size of the image file.</param>
        /// <param name="mvid">[in] The globally unique identifier of the image.</param>
        /// <param name="mdRva">[in] The relative virtual address (RVA) of the metadata. The address is relative to the image base address.</param>
        /// <param name="flags">[in] Reserved for future use.</param>
        /// <param name="bufferSize">[in] The size of the buffer in which to place the metadata.</param>
        /// <param name="buffer">[out] The buffer in which to place the metadata.</param>
        /// <returns>[out] The size of the metadata that is returned.</returns>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public int GetMetadata(string imagePath, int imageTimestamp, int imageSize, Guid mvid, int mdRva, int flags, int bufferSize, IntPtr buffer)
        {
            int dataSize;
            TryGetMetadata(imagePath, imageTimestamp, imageSize, mvid, mdRva, flags, bufferSize, buffer, out dataSize).ThrowOnNotOK();

            return dataSize;
        }

        /// <summary>
        /// Called by the common language runtime (CLR) data access services to retrieve the metadata of an image.
        /// </summary>
        /// <param name="imagePath">[in] A string that specifies the path of the image file.</param>
        /// <param name="imageTimestamp">[in] The time stamp of the image file.</param>
        /// <param name="imageSize">[in] The size of the image file.</param>
        /// <param name="mvid">[in] The globally unique identifier of the image.</param>
        /// <param name="mdRva">[in] The relative virtual address (RVA) of the metadata. The address is relative to the image base address.</param>
        /// <param name="flags">[in] Reserved for future use.</param>
        /// <param name="bufferSize">[in] The size of the buffer in which to place the metadata.</param>
        /// <param name="buffer">[out] The buffer in which to place the metadata.</param>
        /// <param name="dataSize">[out] The size of the metadata that is returned.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public HRESULT TryGetMetadata(string imagePath, int imageTimestamp, int imageSize, Guid mvid, int mdRva, int flags, int bufferSize, IntPtr buffer, out int dataSize)
        {
            /*HRESULT GetMetadata(
            [MarshalAs(UnmanagedType.LPWStr), In] string imagePath,
            [In] int imageTimestamp,
            [In] int imageSize,
            [In] ref Guid mvid,
            [In] int mdRva,
            [In] int flags,
            [In] int bufferSize,
            [Out] IntPtr buffer,
            [Out] out int dataSize);*/
            return Raw.GetMetadata(imagePath, imageTimestamp, imageSize, ref mvid, mdRva, flags, bufferSize, buffer, out dataSize);
        }

        #endregion
        #endregion
    }
}