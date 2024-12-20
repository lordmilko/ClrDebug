using System;

namespace ClrDebug.DbgEng
{
    public class SvcPageFileReader : ComObject<ISvcPageFileReader>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcPageFileReader"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcPageFileReader(ISvcPageFileReader raw) : base(raw)
        {
        }

        #region ISvcPageFileReader
        #region IsPageAvailable

        /// <summary>
        /// Indicates whether a page can be read by the page file reader.
        /// </summary>
        public bool IsPageAvailable(ISvcAddressContext addressContext, long translationEntry)
        {
            bool pageIsAvailable;
            TryIsPageAvailable(addressContext, translationEntry, out pageIsAvailable).ThrowDbgEngNotOK();

            return pageIsAvailable;
        }

        /// <summary>
        /// Indicates whether a page can be read by the page file reader.
        /// </summary>
        public HRESULT TryIsPageAvailable(ISvcAddressContext addressContext, long translationEntry, out bool pageIsAvailable)
        {
            /*HRESULT IsPageAvailable(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long TranslationEntry,
            [Out, MarshalAs(UnmanagedType.U1)] out bool PageIsAvailable);*/
            return Raw.IsPageAvailable(addressContext, translationEntry, out pageIsAvailable);
        }

        #endregion
        #region ReadPage

        /// <summary>
        /// Reads data from the page file (or another backing store).
        /// </summary>
        public void ReadPage(ISvcAddressContext addressContext, long translationEntry, long byteCount, IntPtr buffer)
        {
            TryReadPage(addressContext, translationEntry, byteCount, buffer).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Reads data from the page file (or another backing store).
        /// </summary>
        public HRESULT TryReadPage(ISvcAddressContext addressContext, long translationEntry, long byteCount, IntPtr buffer)
        {
            /*HRESULT ReadPage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext AddressContext,
            [In] long TranslationEntry,
            [In] long ByteCount,
            [Out] IntPtr Buffer);*/
            return Raw.ReadPage(addressContext, translationEntry, byteCount, buffer);
        }

        #endregion
        #endregion
    }
}
