using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    public class XCLRDataTarget : ComObject<IXCLRDataTarget3>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XCLRDataTarget"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public XCLRDataTarget(IXCLRDataTarget3 raw) : base(raw)
        {
        }

        #region IXCLRDataTarget3
        #region GetMetaData

        public XCLRDataTarget_GetMetaDataResult GetMetaData(string imagePath, int imageTimestamp, int imageSize, Guid mvid, int mdRva, int flags, int bufferSize)
        {
            HRESULT hr;
            XCLRDataTarget_GetMetaDataResult result;

            if ((hr = TryGetMetaData(imagePath, imageTimestamp, imageSize, mvid, mdRva, flags, bufferSize, out result)) != HRESULT.S_OK)
                Marshal.ThrowExceptionForHR((int) hr);

            return result;
        }

        public HRESULT TryGetMetaData(string imagePath, int imageTimestamp, int imageSize, Guid mvid, int mdRva, int flags, int bufferSize, out XCLRDataTarget_GetMetaDataResult result)
        {
            /*HRESULT GetMetaData(
            [In, MarshalAs(UnmanagedType.LPWStr)] string imagePath,
            [In] int imageTimestamp,
            [In] int imageSize,
            [In] ref Guid mvid,
            [In] int mdRva,
            [In] int flags,
            [In] int bufferSize,
            [In, Out] ref IntPtr buffer,
            [Out] out int dataSize);*/
            IntPtr buffer = default(IntPtr);
            int dataSize;
            HRESULT hr = Raw.GetMetaData(imagePath, imageTimestamp, imageSize, ref mvid, mdRva, flags, bufferSize, ref buffer, out dataSize);

            if (hr == HRESULT.S_OK)
                result = new XCLRDataTarget_GetMetaDataResult(buffer, dataSize);
            else
                result = default(XCLRDataTarget_GetMetaDataResult);

            return hr;
        }

        #endregion
        #endregion
    }
}