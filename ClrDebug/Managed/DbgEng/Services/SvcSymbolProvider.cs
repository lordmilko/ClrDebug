namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a mechanism by which an abstract "symbol set" is located for a given module. An abstract "symbol set" is described by an ISvcSymbolSet.<para/>
    /// While a "symbol set" may refer to an arbitrary grouping of symbols, the set returned from the LocateSymbolsForImage method represents the symbolic (debug) information for a given image in some address space.<para/>
    /// That symbol set may be backed by a PDB, the "export symbols" of the image, some side description of the symbolic information, or simply be an abstraction materialized out of thin air.
    /// </summary>
    public class SvcSymbolProvider : ComObject<ISvcSymbolProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolProvider(ISvcSymbolProvider raw) : base(raw)
        {
        }

        #region ISvcSymbolProvider
        #region LocateSymbolsForImage

        /// <summary>
        /// For a given image (identified by an ISvcModule), find the set of symbolic information available for the image and return a symbol set.
        /// </summary>
        public SvcSymbolSet LocateSymbolsForImage(ISvcModule image)
        {
            SvcSymbolSet symbolSetResult;
            TryLocateSymbolsForImage(image, out symbolSetResult).ThrowDbgEngNotOK();

            return symbolSetResult;
        }

        /// <summary>
        /// For a given image (identified by an ISvcModule), find the set of symbolic information available for the image and return a symbol set.
        /// </summary>
        public HRESULT TryLocateSymbolsForImage(ISvcModule image, out SvcSymbolSet symbolSetResult)
        {
            /*HRESULT LocateSymbolsForImage(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule image,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSet symbolSet);*/
            ISvcSymbolSet symbolSet;
            HRESULT hr = Raw.LocateSymbolsForImage(image, out symbolSet);

            if (hr == HRESULT.S_OK)
                symbolSetResult = symbolSet == null ? null : new SvcSymbolSet(symbolSet);
            else
                symbolSetResult = default(SvcSymbolSet);

            return hr;
        }

        #endregion
        #endregion
    }
}
