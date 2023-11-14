using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Provides access to the records in a debug data stream.
    /// </summary>
    /// <remarks>
    /// This interface represents a stream of records in a debug data stream. The size and interpretation of each record
    /// is dependent on the data stream the record comes from. This interface effectively provides access to the raw data
    /// bytes in the symbol file. Call the IDiaEnumDebugStreams or IDiaEnumDebugStreams methods to obtain an IDiaEnumDebugStreamData
    /// object.
    /// </remarks>
    public class DiaEnumDebugStreamData : IEnumerable<byte[]>, IEnumerator<byte[]>
    {
        public IDiaEnumDebugStreamData Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumDebugStreamData"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumDebugStreamData(IDiaEnumDebugStreamData raw)
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
        /// Retrieves the number records in the debug data stream.
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
        /// Retrieves the number records in the debug data stream.
        /// </summary>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetCount(out int pRetVal)
        {
            /*HRESULT get_Count(
            [Out] out int pRetVal);*/
            return Raw.get_Count(out pRetVal);
        }

        #endregion
        #region Name

        /// <summary>
        /// Retrieves the name of a debug data stream.
        /// </summary>
        public string Name
        {
            get
            {
                string pRetVal;
                TryGetName(out pRetVal).ThrowOnNotOK();

                return pRetVal;
            }
        }

        /// <summary>
        /// Retrieves the name of a debug data stream.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name of a debug data stream.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryGetName(out string pRetVal)
        {
            /*HRESULT get_name(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);*/
            return Raw.get_name(out pRetVal);
        }

        #endregion
        #region Item

        /// <summary>
        /// Retrieves the specified record.
        /// </summary>
        /// <param name="index">[in] Index of the record to be retrieved. The index is in the range 0 to count-1, where count is returned by IDiaEnumDebugStreamData.</param>
        /// <returns>[out] A buffer that is filled in with the debug stream record data.</returns>
        public byte[] Item(int index)
        {
            byte[] pbData;
            TryItem(index, out pbData).ThrowOnNotOK();

            return pbData;
        }

        /// <summary>
        /// Retrieves the specified record.
        /// </summary>
        /// <param name="index">[in] Index of the record to be retrieved. The index is in the range 0 to count-1, where count is returned by IDiaEnumDebugStreamData.</param>
        /// <param name="pbData">[out] A buffer that is filled in with the debug stream record data.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code. Returns E_INVALIDARG for invalid parameters and if the index parameter is out of bounds.</returns>
        public HRESULT TryItem(int index, out byte[] pbData)
        {
            /*HRESULT Item(
            [In] int index,
            [In] int cbData,
            [Out] out int pcbData,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] pbData);*/
            int cbData = 0;
            int pcbData;
            pbData = null;
            HRESULT hr = Raw.Item(index, cbData, out pcbData, null);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                goto fail;

            cbData = pcbData;
            pbData = new byte[cbData];
            hr = Raw.Item(index, cbData, out pcbData, pbData);
            fail:
            return hr;
        }

        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(byte[]);
        }

        public DiaEnumDebugStreamData Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumDebugStreamData clone;
            Raw.Clone(out clone);

            return new DiaEnumDebugStreamData(clone);
        }

        #region IEnumerable

        public IEnumerator<byte[]> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public byte[] Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            /*HRESULT Next(
            [In] int celt,
            [In] int cbData,
            [Out] out int pcbData,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] pbData,
            [Out] out int pceltFetched);*/
            int cbData = 0;
            int pcbData;
            byte[] pbData;
            int pceltFetched;
            HRESULT hr = Raw.Next(1, cbData, out pcbData, null, out pceltFetched);

            if (hr != HRESULT.S_FALSE && hr != HRESULT.ERROR_INSUFFICIENT_BUFFER && hr != HRESULT.S_OK)
                return false;

            cbData = pcbData;
            pbData = new byte[cbData];
            hr = Raw.Next(1, cbData, out pcbData, pbData, out pceltFetched);

            if (pceltFetched == 1)
                Current = pbData;

            return pceltFetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
