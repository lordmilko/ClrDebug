using System;

namespace ClrDebug.DbgEng
{
    public class SvcImageDataLocationParser : ComObject<ISvcImageDataLocationParser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcImageDataLocationParser"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcImageDataLocationParser(ISvcImageDataLocationParser raw) : base(raw)
        {
        }

        #region ISvcImageDataLocationParser
        #region LocateDataBlob

        public LocateDataBlobResult LocateDataBlob(Guid dataBlob)
        {
            LocateDataBlobResult result;
            TryLocateDataBlob(dataBlob, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryLocateDataBlob(Guid dataBlob, out LocateDataBlobResult result)
        {
            /*HRESULT LocateDataBlob(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid dataBlob,
            [Out] out long pFileOffset,
            [Out] out long pMemoryOffset,
            [Out] out long pBlobSize);*/
            long pFileOffset;
            long pMemoryOffset;
            long pBlobSize;
            HRESULT hr = Raw.LocateDataBlob(dataBlob, out pFileOffset, out pMemoryOffset, out pBlobSize);

            if (hr == HRESULT.S_OK)
                result = new LocateDataBlobResult(pFileOffset, pMemoryOffset, pBlobSize);
            else
                result = default(LocateDataBlobResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
