using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various source files contained in the data source.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the QueryInterface method on an IDiaTable object. See the example for details.
    /// </remarks>
    public class DiaEnumSourceFiles : IEnumerable<DiaSourceFile>, IEnumerator<DiaSourceFile>
    {
        public IDiaEnumSourceFiles Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumSourceFiles"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumSourceFiles(IDiaEnumSourceFiles raw)
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
        /// Retrieves the number of source files.
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
        /// Retrieves the number of source files.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of source files.</param>
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
        /// Retrieves a source file by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaSourceFile object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumSourceFiles method.</param>
        /// <returns>[out] Returns an IDiaSourceFile object representing the desired source file.</returns>
        public DiaSourceFile Item(int index)
        {
            DiaSourceFile sourceFileResult;
            TryItem(index, out sourceFileResult).ThrowOnNotOK();

            return sourceFileResult;
        }

        /// <summary>
        /// Retrieves a source file by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaSourceFile object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumSourceFiles method.</param>
        /// <param name="sourceFileResult">[out] Returns an IDiaSourceFile object representing the desired source file.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryItem(int index, out DiaSourceFile sourceFileResult)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaSourceFile sourceFile);*/
            IDiaSourceFile sourceFile;
            HRESULT hr = Raw.Item(index, out sourceFile);

            if (hr == HRESULT.S_OK)
                sourceFileResult = sourceFile == null ? null : new DiaSourceFile(sourceFile);
            else
                sourceFileResult = default(DiaSourceFile);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaSourceFile);
        }

        public DiaEnumSourceFiles Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumSourceFiles clone;
            Raw.Clone(out clone);

            return new DiaEnumSourceFiles(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaSourceFile> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaSourceFile Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaSourceFile result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaSourceFile(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
