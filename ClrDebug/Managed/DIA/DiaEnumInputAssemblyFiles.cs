using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    public class DiaEnumInputAssemblyFiles : IEnumerable<DiaInputAssemblyFile>, IEnumerator<DiaInputAssemblyFile>
    {
        public IDiaEnumInputAssemblyFiles Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumInputAssemblyFiles"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumInputAssemblyFiles(IDiaEnumInputAssemblyFiles raw)
        {
            Raw = raw;
        }

        #region Count

        public int Count
        {
            get
            {
                int pRetVal;
                TryGetCount(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        public HRESULT TryGetCount(out int pRetVal)
        {
            /*HRESULT get_count(
            [Out] out int pRetVal);*/
            return Raw.get_count(out pRetVal);
        }

        #endregion
        #region NewEnum

        public EnumVARIANT NewEnum()
        {
            EnumVARIANT pRetValResult;
            TryNewEnum(out pRetValResult).ThrowOnNotOK();

            return pRetValResult;
        }

        public HRESULT TryNewEnum(out EnumVARIANT pRetValResult)
        {
            /*HRESULT NewEnum(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumVARIANT pRetVal);*/
            IEnumVARIANT pRetVal;
            HRESULT hr = Raw.NewEnum(out pRetVal);

            if (hr == HRESULT.S_OK)
                pRetValResult = pRetVal == null ? null : new EnumVARIANT(pRetVal);
            else
                pRetValResult = default(EnumVARIANT);

            return hr;
        }

        #endregion
        #region Item

        public DiaInputAssemblyFile Item(int index)
        {
            DiaInputAssemblyFile fileResult;
            TryItem(index, out fileResult).ThrowOnNotOK();

            return fileResult;
        }

        public HRESULT TryItem(int index, out DiaInputAssemblyFile fileResult)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaInputAssemblyFile file);*/
            IDiaInputAssemblyFile file;
            HRESULT hr = Raw.Item(index, out file);

            if (hr == HRESULT.S_OK)
                fileResult = file == null ? null : new DiaInputAssemblyFile(file);
            else
                fileResult = default(DiaInputAssemblyFile);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaInputAssemblyFile);
        }

        public DiaEnumInputAssemblyFiles Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumInputAssemblyFiles clone;
            Raw.Clone(out clone);

            return new DiaEnumInputAssemblyFiles(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaInputAssemblyFile> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaInputAssemblyFile Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaInputAssemblyFile result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaInputAssemblyFile(result);
            else
                Current = default(DiaInputAssemblyFile);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
