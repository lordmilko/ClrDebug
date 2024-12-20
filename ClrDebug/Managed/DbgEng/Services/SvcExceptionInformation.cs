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

        /// <summary>
        /// Gets the kind of exception this represents.
        /// </summary>
        public SvcExceptionKind ExceptionKind
        {
            get
            {
                SvcExceptionKind pExceptionKind;
                TryGetExceptionKind(out pExceptionKind).ThrowDbgEngNotOK();

                return pExceptionKind;
            }
        }

        /// <summary>
        /// Gets the kind of exception this represents.
        /// </summary>
        public HRESULT TryGetExceptionKind(out SvcExceptionKind pExceptionKind)
        {
            /*HRESULT GetExceptionKind(
            [Out] out SvcExceptionKind pExceptionKind);*/
            return Raw.GetExceptionKind(out pExceptionKind);
        }

        #endregion
        #region Address

        /// <summary>
        /// Gets the address associated with the exception. Some exceptions (e.g.: Win32 exceptions and Linux fault type signals) have an address associated with them and some don't.<para/>
        /// This method will return E_NOT_SET if an address is unavailable for the exceptional event.
        /// </summary>
        public long Address
        {
            get
            {
                long pSignalAddress;
                TryGetAddress(out pSignalAddress).ThrowDbgEngNotOK();

                return pSignalAddress;
            }
        }

        /// <summary>
        /// Gets the address associated with the exception. Some exceptions (e.g.: Win32 exceptions and Linux fault type signals) have an address associated with them and some don't.<para/>
        /// This method will return E_NOT_SET if an address is unavailable for the exceptional event.
        /// </summary>
        public HRESULT TryGetAddress(out long pSignalAddress)
        {
            /*HRESULT GetAddress(
            [Out] out long pSignalAddress);*/
            return Raw.GetAddress(out pSignalAddress);
        }

        #endregion
        #region ExecutionUnit

        /// <summary>
        /// Gets the execution unit on which the exceptional event occurred.
        /// </summary>
        public SvcExecutionUnit ExecutionUnit
        {
            get
            {
                SvcExecutionUnit executionUnitResult;
                TryGetExecutionUnit(out executionUnitResult).ThrowDbgEngNotOK();

                return executionUnitResult;
            }
        }

        /// <summary>
        /// Gets the execution unit on which the exceptional event occurred.
        /// </summary>
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

        /// <summary>
        /// Gets the size of any data structure associated with this exception (e.g.: an EXCEPTION_RECORD64, a siginfo_t, or whatever a specific architecture/platform define) If there is no available data associated, 0 is returned.<para/>
        /// It is entirely optional for a given implementation to provide this.
        /// </summary>
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

        /// <summary>
        /// Gets the register context associated with the signal. This may legitimately return E_NOT_SET in many (particularly post-mortem) cases.
        /// </summary>
        public SvcRegisterContext GetContext(SvcContextFlags contextFlags)
        {
            SvcRegisterContext ppRegisterContextResult;
            TryGetContext(contextFlags, out ppRegisterContextResult).ThrowDbgEngNotOK();

            return ppRegisterContextResult;
        }

        /// <summary>
        /// Gets the register context associated with the signal. This may legitimately return E_NOT_SET in many (particularly post-mortem) cases.
        /// </summary>
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

        /// <summary>
        /// Fills a supplied buffer with a copy of the canonicalized data record for this given exception type. If no such record is defined, GetDataRecordSize will return 0 and this method will return E_NOTIMPL.<para/>
        /// If there is no available data associated, E_NOTIMPL is returned. It is entirely optional for a given implementation to provide this.<para/>
        /// Each given exception kind has a specific interface (e.g.: ISvcLinuxSignalInformation) which provides more detailed information based on potentially parsing the given data record.<para/>
        /// The vast majority of consumers should rely on those interfaces and not try to get the underlying data record that a service provider understands.
        /// </summary>
        public long FillDataRecord(long bufferSize, IntPtr buffer)
        {
            long bytesWritten;
            TryFillDataRecord(bufferSize, buffer, out bytesWritten).ThrowDbgEngNotOK();

            return bytesWritten;
        }

        /// <summary>
        /// Fills a supplied buffer with a copy of the canonicalized data record for this given exception type. If no such record is defined, GetDataRecordSize will return 0 and this method will return E_NOTIMPL.<para/>
        /// If there is no available data associated, E_NOTIMPL is returned. It is entirely optional for a given implementation to provide this.<para/>
        /// Each given exception kind has a specific interface (e.g.: ISvcLinuxSignalInformation) which provides more detailed information based on potentially parsing the given data record.<para/>
        /// The vast majority of consumers should rely on those interfaces and not try to get the underlying data record that a service provider understands.
        /// </summary>
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
