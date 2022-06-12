using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
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
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public GetMetadataResult GetMetadata(string imagePath, int imageTimestamp, int imageSize, Guid mvid, int mdRva, int flags, int bufferSize)
        {
            HRESULT hr;
            GetMetadataResult result;

            if ((hr = TryGetMetadata(imagePath, imageTimestamp, imageSize, mvid, mdRva, flags, bufferSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
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
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <remarks>
        /// This method is implemented by the writer of the debugging application.
        /// </remarks>
        public HRESULT TryGetMetadata(string imagePath, int imageTimestamp, int imageSize, Guid mvid, int mdRva, int flags, int bufferSize, out GetMetadataResult result)
        {
            /*HRESULT GetMetadata(
            [MarshalAs(UnmanagedType.LPWStr), In] string imagePath,
            [In] int imageTimestamp,
            [In] int imageSize,
            [In] ref Guid mvid,
            [In] int mdRva,
            [In] int flags,
            [In] int bufferSize,
            out IntPtr buffer,
            out int dataSize);*/
            IntPtr buffer;
            int dataSize;
            HRESULT hr = Raw.GetMetadata(imagePath, imageTimestamp, imageSize, ref mvid, mdRva, flags, bufferSize, out buffer, out dataSize);

            if (hr == HRESULT.S_OK)
                result = new GetMetadataResult(buffer, dataSize);
            else
                result = default(GetMetadataResult);

            return hr;
        }

        #endregion
        #endregion
    }
}