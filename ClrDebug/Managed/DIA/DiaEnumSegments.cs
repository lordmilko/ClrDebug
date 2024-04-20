using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various segments contained in the data source.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the QueryInterface method on an <see cref="IDiaTable"/> object. See the example
    /// for details.
    /// </remarks>
    public class DiaEnumSegments : IEnumerable<DiaSegment>, IEnumerator<DiaSegment>
    {
        public IDiaEnumSegments Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumSegments"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumSegments(IDiaEnumSegments raw)
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
        /// Retrieves the number of segments.
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
        /// Retrieves the number of segments.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetCount(out int pRetVal)
        {
            /*HRESULT get_Count(
            [Out] out int pRetVal);*/
            return Raw.get_Count(out pRetVal);
        }

        #endregion
        #region Item

        /// <summary>
        /// Retrieves a segment by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the <see cref="IDiaSegment"/> object to be retrieved. The index is in the range 0 to count-1, where count is returned by the <see cref="Count"/> property.</param>
        /// <returns>[out] Returns an <see cref="IDiaSegment"/> object representing the desired segment.</returns>
        public DiaSegment Item(int index)
        {
            DiaSegment segmentResult;
            TryItem(index, out segmentResult).ThrowOnNotOK();

            return segmentResult;
        }

        /// <summary>
        /// Retrieves a segment by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the <see cref="IDiaSegment"/> object to be retrieved. The index is in the range 0 to count-1, where count is returned by the <see cref="Count"/> property.</param>
        /// <param name="segmentResult">[out] Returns an <see cref="IDiaSegment"/> object representing the desired segment.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryItem(int index, out DiaSegment segmentResult)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSegment segment);*/
            IDiaSegment segment;
            HRESULT hr = Raw.Item(index, out segment);

            if (hr == HRESULT.S_OK)
                segmentResult = segment == null ? null : new DiaSegment(segment);
            else
                segmentResult = default(DiaSegment);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaSegment);
        }

        public DiaEnumSegments Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumSegments clone;
            Raw.Clone(out clone);

            return new DiaEnumSegments(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaSegment> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaSegment Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaSegment result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaSegment(result);
            else
                Current = default(DiaSegment);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
