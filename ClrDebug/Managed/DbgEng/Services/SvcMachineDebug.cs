namespace ClrDebug.DbgEng
{
    public class SvcMachineDebug : ComObject<ISvcMachineDebug>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcMachineDebug"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcMachineDebug(ISvcMachineDebug raw) : base(raw)
        {
        }

        #region ISvcMachineDebug
        #region DefaultAddressContext

        public SvcAddressContext DefaultAddressContext
        {
            get
            {
                SvcAddressContext defaultAddressContextResult;
                TryGetDefaultAddressContext(out defaultAddressContextResult).ThrowDbgEngNotOK();

                return defaultAddressContextResult;
            }
        }

        public HRESULT TryGetDefaultAddressContext(out SvcAddressContext defaultAddressContextResult)
        {
            /*HRESULT GetDefaultAddressContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcAddressContext defaultAddressContext);*/
            ISvcAddressContext defaultAddressContext;
            HRESULT hr = Raw.GetDefaultAddressContext(out defaultAddressContext);

            if (hr == HRESULT.S_OK)
                defaultAddressContextResult = defaultAddressContext == null ? null : new SvcAddressContext(defaultAddressContext);
            else
                defaultAddressContextResult = default(SvcAddressContext);

            return hr;
        }

        #endregion
        #region NumberOfProcessors

        public long NumberOfProcessors
        {
            get
            {
                /*long GetNumberOfProcessors();*/
                return Raw.GetNumberOfProcessors();
            }
        }

        #endregion
        #region GetProcessor

        public SvcExecutionUnit GetProcessor(long processorNumber)
        {
            SvcExecutionUnit processorResult;
            TryGetProcessor(processorNumber, out processorResult).ThrowDbgEngNotOK();

            return processorResult;
        }

        public HRESULT TryGetProcessor(long processorNumber, out SvcExecutionUnit processorResult)
        {
            /*HRESULT GetProcessor(
            [In] long processorNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcExecutionUnit processor);*/
            ISvcExecutionUnit processor;
            HRESULT hr = Raw.GetProcessor(processorNumber, out processor);

            if (hr == HRESULT.S_OK)
                processorResult = processor == null ? null : new SvcExecutionUnit(processor);
            else
                processorResult = default(SvcExecutionUnit);

            return hr;
        }

        #endregion
        #endregion
    }
}
