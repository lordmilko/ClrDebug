using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ManagedCorDebug
{
    public class CorDebugMetaDataLocator : ComObject<ICorDebugMetaDataLocator>
    {
        public CorDebugMetaDataLocator(ICorDebugMetaDataLocator raw) : base(raw)
        {
        }

        #region ICorDebugMetaDataLocator
        #region GetMetaData

        public string GetMetaData(string wszImagePath, uint dwImageTimeStamp, uint dwImageSize)
        {
            HRESULT hr;
            string wszPathBufferResult;

            if ((hr = TryGetMetaData(wszImagePath, dwImageTimeStamp, dwImageSize, out wszPathBufferResult)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return wszPathBufferResult;
        }

        public HRESULT TryGetMetaData(string wszImagePath, uint dwImageTimeStamp, uint dwImageSize, out string wszPathBufferResult)
        {
            /*HRESULT GetMetaData(
            [MarshalAs(UnmanagedType.LPWStr), In] string wszImagePath,
            [In] uint dwImageTimeStamp,
            [In] uint dwImageSize,
            [In] uint cchPathBuffer,
            out uint pcchPathBuffer,
            [MarshalAs(UnmanagedType.LPWStr), Out] StringBuilder wszPathBuffer);*/
            uint cchPathBuffer = 0;
            uint pcchPathBuffer;
            StringBuilder wszPathBuffer = null;
            HRESULT hr = Raw.GetMetaData(wszImagePath, dwImageTimeStamp, dwImageSize, cchPathBuffer, out pcchPathBuffer, wszPathBuffer);

            if (hr != HRESULT.S_FALSE)
                goto fail;

            cchPathBuffer = pcchPathBuffer;
            wszPathBuffer = new StringBuilder((int) pcchPathBuffer);
            hr = Raw.GetMetaData(wszImagePath, dwImageTimeStamp, dwImageSize, cchPathBuffer, out pcchPathBuffer, wszPathBuffer);

            if (hr == HRESULT.S_OK)
            {
                wszPathBufferResult = wszPathBuffer.ToString();

                return hr;
            }

            fail:
            wszPathBufferResult = default(string);

            return hr;
        }

        #endregion
        #endregion
    }
}