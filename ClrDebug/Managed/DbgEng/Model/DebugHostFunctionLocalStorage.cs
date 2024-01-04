using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class DebugHostFunctionLocalStorage : ComObject<IDebugHostFunctionLocalStorage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostFunctionLocalStorage"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostFunctionLocalStorage(IDebugHostFunctionLocalStorage raw) : base(raw)
        {
        }

        #region IDebugHostFunctionLocalStorage
        #region ValidRange

        public GetValidRangeResult ValidRange
        {
            get
            {
                GetValidRangeResult result;
                TryGetValidRange(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetValidRange(out GetValidRangeResult result)
        {
            /*HRESULT GetValidRange(
            [Out] out long start,
            [Out] out long end,
            [Out, MarshalAs(UnmanagedType.U1)] out bool guaranteed);*/
            long start;
            long end;
            bool guaranteed;
            HRESULT hr = Raw.GetValidRange(out start, out end, out guaranteed);

            if (hr == HRESULT.S_OK)
                result = new GetValidRangeResult(start, end, guaranteed);
            else
                result = default(GetValidRangeResult);

            return hr;
        }

        #endregion
        #region StorageKind

        public StorageKind StorageKind
        {
            get
            {
                StorageKind kind;
                TryGetStorageKind(out kind).ThrowDbgEngNotOK();

                return kind;
            }
        }

        public HRESULT TryGetStorageKind(out StorageKind kind)
        {
            /*HRESULT GetStorageKind(
            [Out] out StorageKind kind);*/
            return Raw.GetStorageKind(out kind);
        }

        #endregion
        #region Register

        public int Register
        {
            get
            {
                int registerId;
                TryGetRegister(out registerId).ThrowDbgEngNotOK();

                return registerId;
            }
        }

        public HRESULT TryGetRegister(out int registerId)
        {
            /*HRESULT GetRegister(
            [Out] out int registerId);*/
            return Raw.GetRegister(out registerId);
        }

        #endregion
        #region Offset

        public long Offset
        {
            get
            {
                long offset;
                TryGetOffset(out offset).ThrowDbgEngNotOK();

                return offset;
            }
        }

        public HRESULT TryGetOffset(out long offset)
        {
            /*HRESULT GetOffset(
            [Out] out long offset);*/
            return Raw.GetOffset(out offset);
        }

        #endregion
        #endregion
        #region IDebugHostFunctionLocalStorage2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostFunctionLocalStorage2 Raw2 => (IDebugHostFunctionLocalStorage2) Raw;

        #region ExtendedRegisterAddressInfo

        public GetExtendedRegisterAddressInfoResult ExtendedRegisterAddressInfo
        {
            get
            {
                GetExtendedRegisterAddressInfoResult result;
                TryGetExtendedRegisterAddressInfo(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        public HRESULT TryGetExtendedRegisterAddressInfo(out GetExtendedRegisterAddressInfoResult result)
        {
            /*HRESULT GetExtendedRegisterAddressInfo(
            [Out] out int registerId,
            [Out] out long offset,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isIndirectAccess,
            [Out] out int indirectOffset);*/
            int registerId;
            long offset;
            bool isIndirectAccess;
            int indirectOffset;
            HRESULT hr = Raw2.GetExtendedRegisterAddressInfo(out registerId, out offset, out isIndirectAccess, out indirectOffset);

            if (hr == HRESULT.S_OK)
                result = new GetExtendedRegisterAddressInfoResult(registerId, offset, isIndirectAccess, indirectOffset);
            else
                result = default(GetExtendedRegisterAddressInfoResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
