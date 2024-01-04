using System;

namespace ClrDebug.DbgEng
{
    public class SvcExceptionInformation : ComObject<ISvcExceptionInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcExceptionInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcExceptionInformation(ISvcExceptionInformation raw) : base(raw)
        {
        }

        #region ISvcExceptionInformation
        #region ExceptionKind

        public SvcExceptionKind ExceptionKind
        {
            get
            {
                SvcExceptionKind pExceptionKind;
                TryGetExceptionKind(out pExceptionKind).ThrowDbgEngNotOK();

                return pExceptionKind;
            }
        }

        public HRESULT TryGetExceptionKind(out SvcExceptionKind pExceptionKind)
        {
            /*HRESULT GetExceptionKind(
            [Out] out SvcExceptionKind pExceptionKind);*/
            return Raw.GetExceptionKind(out pExceptionKind);
        }

        #endregion
        #region Address

        public long Address
        {
            get
            {
                long pSignalAddress;
                TryGetAddress(out pSignalAddress).ThrowDbgEngNotOK();

                return pSignalAddress;
            }
        }

        public HRESULT TryGetAddress(out long pSignalAddress)
        {
            /*HRESULT GetAddress(
            [Out] out long pSignalAddress);*/
            return Raw.GetAddress(out pSignalAddress);
        }

        #endregion
        #region ExecutionUnit

        public SvcExecutionUnit ExecutionUnit
        {
            get
            {
                SvcExecutionUnit executionUnitResult;
                TryGetExecutionUnit(out executionUnitResult).ThrowDbgEngNotOK();

                return executionUnitResult;
            }
        }

        public HRESULT TryGetExecutionUnit(out SvcExecutionUnit executionUnitResult)
        {
            /*HRESULT GetExecutionUnit(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit executionUnit);*/
            ISvcExecutionUnit executionUnit;
            HRESULT hr = Raw.GetExecutionUnit(out executionUnit);

            if (hr == HRESULT.S_OK)
                executionUnitResult = executionUnit == null ? null : new SvcExecutionUnit(executionUnit);
            else
                executionUnitResult = default(SvcExecutionUnit);

            return hr;
        }

        #endregion
        #region DataRecordSize

        public long DataRecordSize
        {
            get
            {
                /*long GetDataRecordSize();*/
                return Raw.GetDataRecordSize();
            }
        }

        #endregion
        #region GetContext

        public SvcRegisterContext GetContext(SvcContextFlags contextFlags)
        {
            SvcRegisterContext ppRegisterContextResult;
            TryGetContext(contextFlags, out ppRegisterContextResult).ThrowDbgEngNotOK();

            return ppRegisterContextResult;
        }

        public HRESULT TryGetContext(SvcContextFlags contextFlags, out SvcRegisterContext ppRegisterContextResult)
        {
            /*HRESULT GetContext(
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);*/
            ISvcRegisterContext ppRegisterContext;
            HRESULT hr = Raw.GetContext(contextFlags, out ppRegisterContext);

            if (hr == HRESULT.S_OK)
                ppRegisterContextResult = ppRegisterContext == null ? null : new SvcRegisterContext(ppRegisterContext);
            else
                ppRegisterContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #region FillDataRecord

        public long FillDataRecord(long bufferSize, IntPtr buffer)
        {
            long bytesWritten;
            TryFillDataRecord(bufferSize, buffer, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

        public HRESULT TryFillDataRecord(long bufferSize, IntPtr buffer, out long bytesWritten)
        {
            /*HRESULT FillDataRecord(
            [In] long bufferSize,
            [Out] IntPtr buffer,
            [Out] out long bytesWritten);*/
            return Raw.FillDataRecord(bufferSize, buffer, out bytesWritten);
        }

        #endregion
        #endregion
    }
}
