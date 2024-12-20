namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a mechanism by which an abstract "symbol set" is located for JIT (or otherwise dynamic) code. Such location is given by an address within an address context.<para/>
    /// A symbol set which supports JIT should have the ISvcSymbolProvider interface queryable for ISvcJITSymbolProvider.<para/>
    /// In addition, the symbol set may be called for symbols that it **DOES NOT DEAL WITH**. If there are multiple JIT providers aggregated together, this may frequently occur.<para/>
    /// In such cases, the locator methods *MUST* return the special E_UNHANDLED_REQUEST_TYPE error indicating this. All *JIT SYMBOLS* are still given as an RVA from the base address of the module.<para/>
    /// Such RVA may, in effect, lead to an address OUTSIDE the bounds of the module pointing to a dynamically allocated JIT segment.<para/>
    /// If the JIT code is located below the address of the module, the offset will be sufficient to cause a 64-bit overflow, producing a 64-bit VA when added to the base address of the module.
    /// </summary>
    public class SvcJITSymbolProvider : ComObject<ISvcJITSymbolProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcJITSymbolProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcJITSymbolProvider(ISvcJITSymbolProvider raw) : base(raw)
        {
        }

        #region ISvcJITSymbolProvider
        #region LocateSymbolsForJITSegment

        /// <summary>
        /// LocateSymbolsForJITSegment For a given address within an address context (often a process), find a symbol set representing the JIT and (potentially) the module to which it belongs.<para/>
        /// If the JIT code is associated with a given loaded module (e.g.: an CLR assembly with IL code), the module will be returned and all RVA style offsets within the symbol set are relative to the base address of the given module.<para/>
        /// If the JIT code is *NOT* associated with a given loaded module (e.g.: JIT'ted script from a loaded script file), the resulting image will be NULL *AND* all RVA style offsets within the symbol set are absolute (they are zero based -- an absolute virtual address within the address space).
        /// </summary>
        public LocateSymbolsForJITSegmentResult LocateSymbolsForJITSegment(ISvcAddressContext addressContext, long address)
        {
            LocateSymbolsForJITSegmentResult result;
            TryLocateSymbolsForJITSegment(addressContext, address, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// LocateSymbolsForJITSegment For a given address within an address context (often a process), find a symbol set representing the JIT and (potentially) the module to which it belongs.<para/>
        /// If the JIT code is associated with a given loaded module (e.g.: an CLR assembly with IL code), the module will be returned and all RVA style offsets within the symbol set are relative to the base address of the given module.<para/>
        /// If the JIT code is *NOT* associated with a given loaded module (e.g.: JIT'ted script from a loaded script file), the resulting image will be NULL *AND* all RVA style offsets within the symbol set are absolute (they are zero based -- an absolute virtual address within the address space).
        /// </summary>
        public HRESULT TryLocateSymbolsForJITSegment(ISvcAddressContext addressContext, long address, out LocateSymbolsForJITSegmentResult result)
        {
            /*HRESULT LocateSymbolsForJITSegment(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long address,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcModule image);*/
            ISvcSymbolSet symbolSet;
            ISvcModule image;
            HRESULT hr = Raw.LocateSymbolsForJITSegment(addressContext, address, out symbolSet, out image);

            if (hr == HRESULT.S_OK)
                result = new LocateSymbolsForJITSegmentResult(symbolSet == null ? null : new SvcSymbolSet(symbolSet), SvcModule.New(image));
            else
                result = default(LocateSymbolsForJITSegmentResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
