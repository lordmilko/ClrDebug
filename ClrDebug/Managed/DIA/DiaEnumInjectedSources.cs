using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerate the various injected sources contained in the data source.
    /// </summary>
    /// <remarks>
    /// This interface is obtained by calling the IDiaSession method with the name of a specific source file or by calling
    /// the IDiaSession method with the GUID of the IDiaEnumInjectedSources interface.
    /// </remarks>
    public class DiaEnumInjectedSources : IEnumerable<DiaInjectedSource>, IEnumerator<DiaInjectedSource>
    {
        public IDiaEnumInjectedSources Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumInjectedSources"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumInjectedSources(IDiaEnumInjectedSources raw)
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
        /// Retrieves the number of injected sources.
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
        /// Retrieves the number of injected sources.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of injected sources.</param>
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
        /// Retrieves an injected source by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaInjectedSource object to be retrieved. The index is the range 0 to count-1, where count is returned by the IDiaEnumInjectedSources method.</param>
        /// <returns>[out] Returns an IDiaInjectedSource object representing the injected source.</returns>
        public DiaInjectedSource Item(int index)
        {
            DiaInjectedSource injectedSourceResult;
            TryItem(index, out injectedSourceResult).ThrowOnNotOK();

            return injectedSourceResult;
        }

        /// <summary>
        /// Retrieves an injected source by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaInjectedSource object to be retrieved. The index is the range 0 to count-1, where count is returned by the IDiaEnumInjectedSources method.</param>
        /// <param name="injectedSourceResult">[out] Returns an IDiaInjectedSource object representing the injected source.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryItem(int index, out DiaInjectedSource injectedSourceResult)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInjectedSource injectedSource);*/
            IDiaInjectedSource injectedSource;
            HRESULT hr = Raw.Item(index, out injectedSource);

            if (hr == HRESULT.S_OK)
                injectedSourceResult = injectedSource == null ? null : new DiaInjectedSource(injectedSource);
            else
                injectedSourceResult = default(DiaInjectedSource);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaInjectedSource);
        }

        public DiaEnumInjectedSources Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumInjectedSources clone;
            Raw.Clone(out clone);

            return new DiaEnumInjectedSources(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaInjectedSource> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaInjectedSource Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaInjectedSource result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaInjectedSource(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
