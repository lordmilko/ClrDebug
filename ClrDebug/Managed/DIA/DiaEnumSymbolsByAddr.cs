using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates by address the various symbols contained in the data source.
    /// </summary>
    /// <remarks>
    /// This interface provides symbols grouped by address. To work with symbols grouped by type, for example SymTagUDT
    /// (user-defined type) or SymTagBaseClass, use the <see cref="IDiaEnumSymbols"/> interface. Obtain this interface
    /// by calling the <see cref="DiaSession.SymbolsByAddr"/> property.
    /// </remarks>
    public class DiaEnumSymbolsByAddr : ComObject<IDiaEnumSymbolsByAddr>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumSymbolsByAddr"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumSymbolsByAddr(IDiaEnumSymbolsByAddr raw) : base(raw)
        {
        }

        #region IDiaEnumSymbolsByAddr
        #region SymbolByAddr

        /// <summary>
        /// Positions the enumerator by performing a lookup by image section number and offset.
        /// </summary>
        /// <param name="isect">[in] Image section number.</param>
        /// <param name="offset">[in] Offset in section.</param>
        /// <returns>[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</returns>
        public DiaSymbol SymbolByAddr(int isect, int offset)
        {
            DiaSymbol ppSymbolResult;
            TrySymbolByAddr(isect, offset, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Positions the enumerator by performing a lookup by image section number and offset.
        /// </summary>
        /// <param name="isect">[in] Image section number.</param>
        /// <param name="offset">[in] Offset in section.</param>
        /// <param name="ppSymbolResult">[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the symbol could not be found. Otherwise, returns an error code.</returns>
        public HRESULT TrySymbolByAddr(int isect, int offset, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT symbolByAddr(
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.symbolByAddr(isect, offset, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region SymbolByRVA

        /// <summary>
        /// Positions the enumerator by performing a lookup by relative virtual address (RVA).
        /// </summary>
        /// <param name="relativeVirtualAddress">[in] Address relative to start of image.</param>
        /// <returns>[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</returns>
        public DiaSymbol SymbolByRVA(int relativeVirtualAddress)
        {
            DiaSymbol ppSymbolResult;
            TrySymbolByRVA(relativeVirtualAddress, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Positions the enumerator by performing a lookup by relative virtual address (RVA).
        /// </summary>
        /// <param name="relativeVirtualAddress">[in] Address relative to start of image.</param>
        /// <param name="ppSymbolResult">[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the symbol could not be found. Otherwise, returns an error code.</returns>
        public HRESULT TrySymbolByRVA(int relativeVirtualAddress, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT symbolByRVA(
            [In] int relativeVirtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.symbolByRVA(relativeVirtualAddress, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region SymbolByVA

        /// <summary>
        /// Positions the enumerator by performing a lookup by virtual address (VA).
        /// </summary>
        /// <param name="virtualAddress">[in] Virtual address.</param>
        /// <returns>[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</returns>
        public DiaSymbol SymbolByVA(long virtualAddress)
        {
            DiaSymbol ppSymbolResult;
            TrySymbolByVA(virtualAddress, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        /// <summary>
        /// Positions the enumerator by performing a lookup by virtual address (VA).
        /// </summary>
        /// <param name="virtualAddress">[in] Virtual address.</param>
        /// <param name="ppSymbolResult">[out] Returns an <see cref="IDiaSymbol"/> object representing the symbol found.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if the symbol could not be found. Otherwise, returns an error code.</returns>
        public HRESULT TrySymbolByVA(long virtualAddress, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT symbolByVA(
            [In] long virtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw.symbolByVA(virtualAddress, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region Next

        /// <summary>
        /// Retrieves the next symbols in order by address.
        /// </summary>
        /// <param name="celt">[in] The number of symbols in the enumerator to be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method updates the enumerator position by the number of elements fetched.
        /// </remarks>
        public NextResult Next(int celt)
        {
            NextResult result;
            TryNext(celt, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves the next symbols in order by address.
        /// </summary>
        /// <param name="celt">[in] The number of symbols in the enumerator to be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no more symbols. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// This method updates the enumerator position by the number of elements fetched.
        /// </remarks>
        public HRESULT TryNext(int celt, out NextResult result)
        {
            /*HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);*/
            IDiaSymbol rgelt;
            int pceltFetched;
            HRESULT hr = Raw.Next(celt, out rgelt, out pceltFetched);

            if (hr == HRESULT.S_OK)
                result = new NextResult(rgelt == null ? null : new DiaSymbol(rgelt), pceltFetched);
            else
                result = default(NextResult);

            return hr;
        }

        #endregion
        #region Prev

        /// <summary>
        /// Retrieves the previous symbols in order by address.
        /// </summary>
        /// <param name="celt">[in] The number of symbols in the enumerator to be retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// This method updates the enumerator position by the number of elements fetched.
        /// </remarks>
        public PrevResult Prev(int celt)
        {
            PrevResult result;
            TryPrev(celt, out result).ThrowOnNotOK();

            return result;
        }

        /// <summary>
        /// Retrieves the previous symbols in order by address.
        /// </summary>
        /// <param name="celt">[in] The number of symbols in the enumerator to be retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if there are no previous symbols. Otherwise, returns an error code.</returns>
        /// <remarks>
        /// This method updates the enumerator position by the number of elements fetched.
        /// </remarks>
        public HRESULT TryPrev(int celt, out PrevResult result)
        {
            /*HRESULT Prev(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);*/
            IDiaSymbol rgelt;
            int pceltFetched;
            HRESULT hr = Raw.Prev(celt, out rgelt, out pceltFetched);

            if (hr == HRESULT.S_OK)
                result = new PrevResult(rgelt == null ? null : new DiaSymbol(rgelt), pceltFetched);
            else
                result = default(PrevResult);

            return hr;
        }

        #endregion
        #region Clone

        /// <summary>
        /// Makes a copy of an object.
        /// </summary>
        /// <returns>[out] Returns an <see cref="IDiaEnumSymbolsByAddr"/> object that contains a duplicate of the enumerator. The symbols are not duplicated, only the enumerator.</returns>
        public DiaEnumSymbolsByAddr Clone()
        {
            DiaEnumSymbolsByAddr ppenumResult;
            TryClone(out ppenumResult).ThrowOnNotOK();

            return ppenumResult;
        }

        /// <summary>
        /// Makes a copy of an object.
        /// </summary>
        /// <param name="ppenumResult">[out] Returns an <see cref="IDiaEnumSymbolsByAddr"/> object that contains a duplicate of the enumerator. The symbols are not duplicated, only the enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryClone(out DiaEnumSymbolsByAddr ppenumResult)
        {
            /*HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumSymbolsByAddr ppenum);*/
            IDiaEnumSymbolsByAddr ppenum;
            HRESULT hr = Raw.Clone(out ppenum);

            if (hr == HRESULT.S_OK)
                ppenumResult = ppenum == null ? null : new DiaEnumSymbolsByAddr(ppenum);
            else
                ppenumResult = default(DiaEnumSymbolsByAddr);

            return hr;
        }

        #endregion
        #endregion
        #region IDiaEnumSymbolsByAddr2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDiaEnumSymbolsByAddr2 Raw2 => (IDiaEnumSymbolsByAddr2) Raw;

        #region SymbolByAddrEx

        public DiaSymbol SymbolByAddrEx(bool fPromoteBlockSym, int isect, int offset)
        {
            DiaSymbol ppSymbolResult;
            TrySymbolByAddrEx(fPromoteBlockSym, isect, offset, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        public HRESULT TrySymbolByAddrEx(bool fPromoteBlockSym, int isect, int offset, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT symbolByAddrEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] int isect,
            [In] int offset,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw2.symbolByAddrEx(fPromoteBlockSym, isect, offset, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region SymbolByRVAEx

        public DiaSymbol SymbolByRVAEx(bool fPromoteBlockSym, int relativeVirtualAddress)
        {
            DiaSymbol ppSymbolResult;
            TrySymbolByRVAEx(fPromoteBlockSym, relativeVirtualAddress, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        public HRESULT TrySymbolByRVAEx(bool fPromoteBlockSym, int relativeVirtualAddress, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT symbolByRVAEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] int relativeVirtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw2.symbolByRVAEx(fPromoteBlockSym, relativeVirtualAddress, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region SymbolByVAEx

        public DiaSymbol SymbolByVAEx(bool fPromoteBlockSym, long virtualAddress)
        {
            DiaSymbol ppSymbolResult;
            TrySymbolByVAEx(fPromoteBlockSym, virtualAddress, out ppSymbolResult).ThrowOnNotOK();

            return ppSymbolResult;
        }

        public HRESULT TrySymbolByVAEx(bool fPromoteBlockSym, long virtualAddress, out DiaSymbol ppSymbolResult)
        {
            /*HRESULT symbolByVAEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] long virtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol ppSymbol);*/
            IDiaSymbol ppSymbol;
            HRESULT hr = Raw2.symbolByVAEx(fPromoteBlockSym, virtualAddress, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = ppSymbol == null ? null : new DiaSymbol(ppSymbol);
            else
                ppSymbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion
        #region NextEx

        public NextExResult NextEx(bool fPromoteBlockSym, int celt)
        {
            NextExResult result;
            TryNextEx(fPromoteBlockSym, celt, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryNextEx(bool fPromoteBlockSym, int celt, out NextExResult result)
        {
            /*HRESULT NextEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);*/
            IDiaSymbol rgelt;
            int pceltFetched;
            HRESULT hr = Raw2.NextEx(fPromoteBlockSym, celt, out rgelt, out pceltFetched);

            if (hr == HRESULT.S_OK)
                result = new NextExResult(rgelt == null ? null : new DiaSymbol(rgelt), pceltFetched);
            else
                result = default(NextExResult);

            return hr;
        }

        #endregion
        #region PrevEx

        public PrevExResult PrevEx(bool fPromoteBlockSym, int celt)
        {
            PrevExResult result;
            TryPrevEx(fPromoteBlockSym, celt, out result).ThrowOnNotOK();

            return result;
        }

        public HRESULT TryPrevEx(bool fPromoteBlockSym, int celt, out PrevExResult result)
        {
            /*HRESULT PrevEx(
            [In, MarshalAs(UnmanagedType.Bool)] bool fPromoteBlockSym,
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol rgelt,
            [Out] out int pceltFetched);*/
            IDiaSymbol rgelt;
            int pceltFetched;
            HRESULT hr = Raw2.PrevEx(fPromoteBlockSym, celt, out rgelt, out pceltFetched);

            if (hr == HRESULT.S_OK)
                result = new PrevExResult(rgelt == null ? null : new DiaSymbol(rgelt), pceltFetched);
            else
                result = default(PrevExResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
