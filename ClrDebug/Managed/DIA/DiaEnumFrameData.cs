using System.Collections;
using System.Collections.Generic;
using ClrDebug;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates the various frame data elements contained in the data source.
    /// </summary>
    /// <remarks>
    /// Obtain this interface from the IDiaSession method. See the example for details.
    /// </remarks>
    public class DiaEnumFrameData : IEnumerable<DiaFrameData>, IEnumerator<DiaFrameData>
    {
        public IDiaEnumFrameData Raw { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiaEnumFrameData"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DiaEnumFrameData(IDiaEnumFrameData raw)
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
        /// Retrieves the number of frame data elements.
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
        /// Retrieves the number of frame data elements.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of frame data elements.</param>
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
        /// Retrieves a frame data element by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaFrameData object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumFrameData method.</param>
        /// <returns>[out] Returns an IDiaFrameData object representing the desired frame data element.</returns>
        public DiaFrameData Item(int index)
        {
            DiaFrameData frameResult;
            TryItem(index, out frameResult).ThrowOnNotOK();

            return frameResult;
        }

        /// <summary>
        /// Retrieves a frame data element by means of an index.
        /// </summary>
        /// <param name="index">[in] Index of the IDiaFrameData object to be retrieved. The index is in the range 0 to count-1, where count is returned by the IDiaEnumFrameData method.</param>
        /// <param name="frameResult">[out] Returns an IDiaFrameData object representing the desired frame data element.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        public HRESULT TryItem(int index, out DiaFrameData frameResult)
        {
            /*HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData frame);*/
            IDiaFrameData frame;
            HRESULT hr = Raw.Item(index, out frame);

            if (hr == HRESULT.S_OK)
                frameResult = frame == null ? null : new DiaFrameData(frame);
            else
                frameResult = default(DiaFrameData);

            return hr;
        }

        #endregion
        #region FrameByRVA

        /// <summary>
        /// Returns a frame by relative virtual address (RVA).
        /// </summary>
        /// <param name="relativeVirtualAddress">[in] RVA of the frame of interest.</param>
        /// <returns>[out] Returns an IDiaFrameData object representing the frame that contains the address provided.</returns>
        public DiaFrameData FrameByRVA(int relativeVirtualAddress)
        {
            DiaFrameData frameResult;
            TryFrameByRVA(relativeVirtualAddress, out frameResult).ThrowOnNotOK();

            return frameResult;
        }

        /// <summary>
        /// Returns a frame by relative virtual address (RVA).
        /// </summary>
        /// <param name="relativeVirtualAddress">[in] RVA of the frame of interest.</param>
        /// <param name="frameResult">[out] Returns an IDiaFrameData object representing the frame that contains the address provided.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if no frame data matches the specified address. Otherwise, returns an error code.</returns>
        public HRESULT TryFrameByRVA(int relativeVirtualAddress, out DiaFrameData frameResult)
        {
            /*HRESULT frameByRVA(
            [In] int relativeVirtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData frame);*/
            IDiaFrameData frame;
            HRESULT hr = Raw.frameByRVA(relativeVirtualAddress, out frame);

            if (hr == HRESULT.S_OK)
                frameResult = frame == null ? null : new DiaFrameData(frame);
            else
                frameResult = default(DiaFrameData);

            return hr;
        }

        #endregion
        #region FrameByVA

        /// <summary>
        /// Returns a frame by virtual address (VA).
        /// </summary>
        /// <param name="virtualAddress">[in] VA of the frame of interest.</param>
        /// <returns>[out] Returns an IDiaFrameData object that represents the frame that contains the address provided.</returns>
        public DiaFrameData FrameByVA(long virtualAddress)
        {
            DiaFrameData frameResult;
            TryFrameByVA(virtualAddress, out frameResult).ThrowOnNotOK();

            return frameResult;
        }

        /// <summary>
        /// Returns a frame by virtual address (VA).
        /// </summary>
        /// <param name="virtualAddress">[in] VA of the frame of interest.</param>
        /// <param name="frameResult">[out] Returns an IDiaFrameData object that represents the frame that contains the address provided.</param>
        /// <returns>If successful, returns S_OK. Returns S_FALSE if no frame data matches the specified address. Otherwise, returns an error code.</returns>
        public HRESULT TryFrameByVA(long virtualAddress, out DiaFrameData frameResult)
        {
            /*HRESULT frameByVA(
            [In] long virtualAddress,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDiaFrameData frame);*/
            IDiaFrameData frame;
            HRESULT hr = Raw.frameByVA(virtualAddress, out frame);

            if (hr == HRESULT.S_OK)
                frameResult = frame == null ? null : new DiaFrameData(frame);
            else
                frameResult = default(DiaFrameData);

            return hr;
        }

        #endregion

        public void Reset()
        {
            if (Raw == null)
                return;

            Raw.Reset();
            Current = default(DiaFrameData);
        }

        public DiaEnumFrameData Clone()
        {
            if (Raw == null)
                return this;

            IDiaEnumFrameData clone;
            Raw.Clone(out clone);

            return new DiaEnumFrameData(clone);
        }

        #region IEnumerable

        public IEnumerator<DiaFrameData> GetEnumerator() => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
        #region IEnumerator

        public DiaFrameData Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (Raw == null)
                return false;

            int fetched;
            IDiaFrameData result;
            var hr = Raw.Next(1, out result, out fetched);

            if (fetched == 1)
                Current = result == null ? null : new DiaFrameData(result);

            return fetched == 1;
        }

        public void Dispose()
        {
        }

        #endregion
    }
}
