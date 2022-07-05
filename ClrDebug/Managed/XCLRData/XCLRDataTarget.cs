using System;

namespace ClrDebug
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

        public int GetMetaData(string imagePath, int imageTimestamp, int imageSize, Guid mvid, int mdRva, int flags, int bufferSize, IntPtr buffer)
        {
            int dataSize;
            TryGetMetaData(imagePath, imageTimestamp, imageSize, mvid, mdRva, flags, bufferSize, buffer, out dataSize).ThrowOnNotOK();

            return dataSize;
        }

        public HRESULT TryGetMetaData(string imagePath, int imageTimestamp, int imageSize, Guid mvid, int mdRva, int flags, int bufferSize, IntPtr buffer, out int dataSize)
        {
            /*HRESULT GetMetaData(
            [In, MarshalAs(UnmanagedType.LPWStr)] string imagePath,
            [In] int imageTimestamp,
            [In] int imageSize,
            [In] ref Guid mvid,
            [In] int mdRva,
            [In] int flags, //Unused, always 0
            [In] int bufferSize,
            [Out] IntPtr buffer,
            [Out] out int dataSize);*/
            return Raw.GetMetaData(imagePath, imageTimestamp, imageSize, ref mvid, mdRva, flags, bufferSize, buffer, out dataSize);
        }

        #endregion
        #endregion
    }
}
