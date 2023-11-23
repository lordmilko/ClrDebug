using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various symbols contained in the data source.
    /// </summary>
    /// <remarks>
    /// This interface provides symbols grouped by a specific type of symbol, for example, SymTagUDT (user-defined types)
    /// or SymTagBaseClass. To work with symbols grouped by address, use the IDiaEnumSymbolsByAddr interface. Obtain this
    /// interface by calling the following methods:
    /// </remarks>
    public class DiaEnumSymbols : IEnumerable<DiaSymbol>, IEnumerator<DiaSymbol>
    {
        public IDiaEnumSymbols Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumSymbols"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumSymbols(IDiaEnumSymbols raw)
        {
            Raw = raw;
        }

        #region NewEnum

        /// <summary>
        /// Retrieves the <see cref="IEnumVARIANT"/> version of this enumerator.
        /// </summary>
        public EnumVARIANT NewEnum
        {
            get
            {
                EnumVARIANT pRetValResult;
                TryGetNewEnum(out pRetValResult).ThrowOnNotOK();

                return pRetValResult;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="IEnumVARIANT"/> version of this enumerator.
        /// </summary>
        /// <param name="pRetValResult">[out] Returns the IUnknown interface that represents the <see cref="IEnumVARIANT"/> version of this enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetNewEnum(out EnumVARIANT pRetValResult)
        {
            /*HRESULT get__NewEnum(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumVARIANT pRetVal);*/
            IEnumVARIANT pRetVal;
            HRESULT hr = Raw.get__NewEnum(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new EnumVARIANT(pRetVal);
            else
                pRetValResult = default(EnumVARIANT);

            return hr;
        }

        #endregion
        #region Count

        /// <summary>
        /// Retrieves the number of symbols.
        /// </summary>
        public int Count
        {
            get
            {
                int pRetVal;
                TryGetCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the number of symbols.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of symbols.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetCount(out int pRetVal)
        {
            /*HRESULT get_count(
            [Out] out int pRetVal);*/
            return Raw.get_count(out pRetVal);
        }

        #endregion
        #region Item

        /// <summary>
        /// Retrieves a symbol by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaSymbol object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumSymbols method.</param>
        /// <returns>[out] Returns an IDiaSymbol object representing the desired symbol.</returns>
        public DiaSymbol Item(int index)
        {
            DiaSymbol symbolResult;
            TryItem(index, out symbolResult).ThrowOnNotOK();

            return symbolResult;
        }

        /// <summary>
        /// Retrieves a symbol by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaSymbol object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumSymbols method.</param>
        /// <param name="symbolResult">[out] Returns an IDiaSymbol object representing the desired symbol.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryItem(int index, out DiaSymbol symbolResult)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSymbol symbol);*/
            IDiaSymbol symbol;
            HRESULT hr = Raw.Item(index, out symbol);

            if (hr == HRESULT.S_OK)
                symbolResult = symbol == null ? null : new DiaSymbol(symbol);
            else
                symbolResult = default(DiaSymbol);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaSymbol);
        }

        public DiaEnumSymbols Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumSymbols clone;
            Raw.Clone(out clone);

            return new DiaEnumSymbols(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaSymbol> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaSymbol Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaSymbol result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaSymbol(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
