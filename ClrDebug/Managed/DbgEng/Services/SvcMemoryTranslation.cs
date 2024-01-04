namespace ClrDebug.DbgEng
{
    public class SvcMemoryTranslation : ComObject<ISvcMemoryTranslation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMemoryTranslation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMemoryTranslation(ISvcMemoryTranslation raw) : base(raw)
        {
        }

        #region ISvcMemoryTranslation
        #region TranslateAddress

        public TranslateAddressResult TranslateAddress(ISvcAddressContext addressContext, long offset, long contiguousByteCount)
        {
            TranslateAddressResult result;
            TryTranslateAddress(addressContext, offset, contiguousByteCount, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryTranslateAddress(ISvcAddressContext addressContext, long offset, long contiguousByteCount, out TranslateAddressResult result)
        {
            /*HRESULT TranslateAddress(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long offset,
            [In] long contiguousByteCount,
            [Out] out long translatedOffset,
            [Out] out long translatedContiguousByteCount,
            [Out] out long translationEntry);*/
            long translatedOffset;
            long translatedContiguousByteCount;
            long translationEntry;
            HRESULT hr = Raw.TranslateAddress(addressContext, offset, contiguousByteCount, out translatedOffset, out translatedContiguousByteCount, out translationEntry);

            if (hr == HRESULT.S_OK)
                result = new TranslateAddressResult(translatedOffset, translatedContiguousByteCount, translationEntry);
            else
                result = default(TranslateAddressResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
