namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_VIRTUAL_TO_PHYSICAL_TRANSLATION. Defines a translation from one address space to another (e.g.: the translation of virtual addresses to physical addresses by a target or by interpretation of the page tables of a target).
    /// </summary>
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

        /// <summary>
        /// Translates an address from one address space to another. A service which provides virtual to physical memory mappings would implement this interface to do so.<para/>
        /// The following special error codes may be returned from this method HR_TRANSLATION_NOT_PRESENT The address specified by the 'Offset' argument is not present in the target address space.<para/>
        /// If there is a PTE for the address, its value is returned in TranslationEntry. Such may be queried against the page table reader service which can attempt to read the page data from a compressed memory store or from the page file.<para/>
        /// If there is a "translation entry" (e.g.: PTE) for the given address, it is returned in the 'TranslationEntry' output argument.<para/>
        /// If not, such is set to zero at the exit of the method.
        /// </summary>
        public TranslateAddressResult TranslateAddress(ISvcAddressContext addressContext, long offset, long contiguousByteCount)
        {
            TranslateAddressResult result;
            TryTranslateAddress(addressContext, offset, contiguousByteCount, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// Translates an address from one address space to another. A service which provides virtual to physical memory mappings would implement this interface to do so.<para/>
        /// The following special error codes may be returned from this method HR_TRANSLATION_NOT_PRESENT The address specified by the 'Offset' argument is not present in the target address space.<para/>
        /// If there is a PTE for the address, its value is returned in TranslationEntry. Such may be queried against the page table reader service which can attempt to read the page data from a compressed memory store or from the page file.<para/>
        /// If there is a "translation entry" (e.g.: PTE) for the given address, it is returned in the 'TranslationEntry' output argument.<para/>
        /// If not, such is set to zero at the exit of the method.
        /// </summary>
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
