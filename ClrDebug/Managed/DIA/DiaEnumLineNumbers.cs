using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various line numbers contained in the data source.
    /// </summary>
    /// <remarks>
    /// This interface is obtained by calling one of the following methods in the <see cref="IDiaSession"/> interface:
    /// </remarks>
    public class DiaEnumLineNumbers : IEnumerable<DiaLineNumber>, IEnumerator<DiaLineNumber>
    {
        public IDiaEnumLineNumbers Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumLineNumbers"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumLineNumbers(IDiaEnumLineNumbers raw)
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
        /// Retrieves the number of line numbers.
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
        /// Retrieves the number of line numbers.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of line numbers.</param>
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
        /// Retrieves a line number by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the <see cref="IDiaLineNumber"/> object to be retrieved. The index is in the range 0 to count-1, where count is returned by the <see cref="Count"/> property.</param>
        /// <returns>[out] Returns an <see cref="IDiaLineNumber"/> object representing the desired line number.</returns>
        public DiaLineNumber Item(int index)
        {
            DiaLineNumber lineNumberResult;
            TryItem(index, out lineNumberResult).ThrowOnNotOK();

            return lineNumberResult;
        }

        /// <summary>
        /// Retrieves a line number by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the <see cref="IDiaLineNumber"/> object to be retrieved. The index is in the range 0 to count-1, where count is returned by the <see cref="Count"/> property.</param>
        /// <param name="lineNumberResult">[out] Returns an <see cref="IDiaLineNumber"/> object representing the desired line number.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryItem(int index, out DiaLineNumber lineNumberResult)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaLineNumber lineNumber);*/
            IDiaLineNumber lineNumber;
            HRESULT hr = Raw.Item(index, out lineNumber);

            if (hr == HRESULT.S_OK)
                lineNumberResult = lineNumber == null ? null : new DiaLineNumber(lineNumber);
            else
                lineNumberResult = default(DiaLineNumber);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaLineNumber);
        }

        public DiaEnumLineNumbers Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumLineNumbers clone;
            Raw.Clone(out clone);

            return new DiaEnumLineNumbers(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaLineNumber> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaLineNumber Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaLineNumber result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaLineNumber(result);
            else
                Current = default(DiaLineNumber);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
