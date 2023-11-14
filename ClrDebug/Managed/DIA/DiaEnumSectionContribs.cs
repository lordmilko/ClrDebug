using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various section contributions contained in the data source.
    /// </summary>
    public class DiaEnumSectionContribs : IEnumerable<DiaSectionContrib>, IEnumerator<DiaSectionContrib>
    {
        public IDiaEnumSectionContribs Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumSectionContribs"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumSectionContribs(IDiaEnumSectionContribs raw)
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
                pRetValResult = new EnumVARIANT(pRetVal);
            else
                pRetValResult = default(EnumVARIANT);

            return hr;
        }

        #endregion
        #region Count

        /// <summary>
        /// Retrieves the number of section contributions.
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
        /// Retrieves the number of section contributions.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of section contributions.</param>
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
        /// Retrieves section contributions by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaSectionContrib object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumSectionContribs method.</param>
        /// <returns>[out] Returns an IDiaSectionContrib object representing the desired section contribution.</returns>
        public DiaSectionContrib Item(int index)
        {
            DiaSectionContrib sectionResult;
            TryItem(index, out sectionResult).ThrowOnNotOK();

            return sectionResult;
        }

        /// <summary>
        /// Retrieves section contributions by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaSectionContrib object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumSectionContribs method.</param>
        /// <param name="sectionResult">[out] Returns an IDiaSectionContrib object representing the desired section contribution.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryItem(int index, out DiaSectionContrib sectionResult)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSectionContrib section);*/
            IDiaSectionContrib section;
            HRESULT hr = Raw.Item(index, out section);

            if (hr == HRESULT.S_OK)
                sectionResult = new DiaSectionContrib(section);
            else
                sectionResult = default(DiaSectionContrib);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaSectionContrib);
        }

        public DiaEnumSectionContribs Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumSectionContribs clone;
            Raw.Clone(out clone);

            return new DiaEnumSectionContribs(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaSectionContrib> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaSectionContrib Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaSectionContrib result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = new DiaSectionContrib(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
