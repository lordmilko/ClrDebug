using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class CLRMetadataLocator : ComObject<ICLRMetadataLocator>
    {
        public CLRMetadataLocator(ICLRMetadataLocator raw) : base(raw)
        {
        }

        #region ICLRMetadataLocator
        #region GetMetadata

        public GetMetadataResult GetMetadata(string imagePath, uint imageTimestamp, uint imageSize, Guid mvid, uint mdRva, uint flags, uint bufferSize)
        {
            HRESULT hr;
            GetMetadataResult result;

            if ((hr = TryGetMetadata(imagePath, imageTimestamp, imageSize, mvid, mdRva, flags, bufferSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMetadata(string imagePath, uint imageTimestamp, uint imageSize, Guid mvid, uint mdRva, uint flags, uint bufferSize, out GetMetadataResult result)
        {
            /*HRESULT GetMetadata(
            [MarshalAs(UnmanagedType.LPWStr), In] string imagePath,
            [In] uint imageTimestamp,
            [In] uint imageSize,
            [In] ref Guid mvid,
            [In] uint mdRva,
            [In] uint flags,
            [In] uint bufferSize,
            out IntPtr buffer,
            out uint dataSize);*/
            IntPtr buffer;
            uint dataSize;
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