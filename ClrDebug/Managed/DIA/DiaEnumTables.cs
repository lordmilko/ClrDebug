using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various tables contained in the data source.
    /// </summary>
    /// <remarks>
    /// Obtain this interface by calling the <see cref="DiaSession.EnumTables"/> property.
    /// </remarks>
    public class DiaEnumTables : IEnumerable<DiaTable>, IEnumerator<DiaTable>
    {
        public IDiaEnumTables Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumTables"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumTables(IDiaEnumTables raw)
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
        /// Retrieves the number of tables.
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
        /// Retrieves the number of tables.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of tables.</param>
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
        /// Retrieves a table by means of an index or name.
        /// </summary>
        /// <param name="index">[in] Index or name of the <see cref="IDiaTable"/> to be retrieved. If an integer variant is used, it must be in the range 0 to count-1, where count is as returned by the <see cref="Count"/> property.</param>
        /// <returns>[out] Returns an <see cref="IDiaTable"/> object representing the desired table.</returns>
        /// <remarks>
        /// If a string variant is specified, then the string names a particular table. The name should be one of the table
        /// names as defined in Constants (Debug Interface Access SDK).
        /// </remarks>
        public DiaTable Item(object index)
        {
            DiaTable tableResult;
            TryItem(index, out tableResult).ThrowOnNotOK();

            return tableResult;
        }

        /// <summary>
        /// Retrieves a table by means of an index or name.
        /// </summary>
        /// <param name="index">[in] Index or name of the <see cref="IDiaTable"/> to be retrieved. If an integer variant is used, it must be in the range 0 to count-1, where count is as returned by the <see cref="Count"/> property.</param>
        /// <param name="tableResult">[out] Returns an <see cref="IDiaTable"/> object representing the desired table.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// If a string variant is specified, then the string names a particular table. The name should be one of the table
        /// names as defined in Constants (Debug Interface Access SDK).
        /// </remarks>
        public HRESULT TryItem(object index, out DiaTable tableResult)
        {
            /*HRESULT Item(
            [In, MarshalAs(UnmanagedType.Struct)] object index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaTable table);*/
            IDiaTable table;
            HRESULT hr = Raw.Item(index, out table);

            if (hr == HRESULT.S_OK)
                tableResult = table == null ? null : new DiaTable(table);
            else
                tableResult = default(DiaTable);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaTable);
        }

        public DiaEnumTables Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumTables clone;
            Raw.Clone(out clone);

            return new DiaEnumTables(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaTable> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaTable Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaTable result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaTable(result);
            else
                Current = default(DiaTable);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
