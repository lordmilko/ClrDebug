using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various debug streams contained in the data source.
    /// </summary>
    /// <remarks>
    /// The content of debug streams is implementation-dependent and the data formats are undocumented. Call the IDiaSession
    /// method to obtain an IDiaEnumDebugStreams object.
    /// </remarks>
    public class DiaEnumDebugStreams : IEnumerable<DiaEnumDebugStreamData>, IEnumerator<DiaEnumDebugStreamData>
    {
        public IDiaEnumDebugStreams Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumDebugStreams"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumDebugStreams(IDiaEnumDebugStreams raw)
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
        /// Retrieves the number of debug streams.
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
        /// Retrieves the number of debug streams.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of debug streams available in this enumerator.</param>
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
        /// Retrieves a debug stream by means of an index or name.
        /// </summary>
        /// <param name="index">[in] Index or name of the debug stream to be retrieved. If an integer variant is used, it must be in the range 0 to count-1, where count is as returned by the IDiaEnumDebugStreams method.</param>
        /// <returns>[out] Returns an IDiaEnumDebugStreamData object representing the specified debug stream.</returns>
        public DiaEnumDebugStreamData Item(object index)
        {
            DiaEnumDebugStreamData streamResult;
            TryItem(index, out streamResult).ThrowOnNotOK();

            return streamResult;
        }

        /// <summary>
        /// Retrieves a debug stream by means of an index or name.
        /// </summary>
        /// <param name="index">[in] Index or name of the debug stream to be retrieved. If an integer variant is used, it must be in the range 0 to count-1, where count is as returned by the IDiaEnumDebugStreams method.</param>
        /// <param name="streamResult">[out] Returns an IDiaEnumDebugStreamData object representing the specified debug stream.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryItem(object index, out DiaEnumDebugStreamData streamResult)
        {
            /*HRESULT Item(
            [In, MarshalAs(UnmanagedType.Struct)] object index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaEnumDebugStreamData stream);*/
            IDiaEnumDebugStreamData stream;
            HRESULT hr = Raw.Item(index, out stream);

            if (hr == HRESULT.S_OK)
                streamResult = stream == null ? null : new DiaEnumDebugStreamData(stream);
            else
                streamResult = default(DiaEnumDebugStreamData);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaEnumDebugStreamData);
        }

        public DiaEnumDebugStreams Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumDebugStreams clone;
            Raw.Clone(out clone);

            return new DiaEnumDebugStreams(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaEnumDebugStreamData> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaEnumDebugStreamData Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaEnumDebugStreamData result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaEnumDebugStreamData(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
