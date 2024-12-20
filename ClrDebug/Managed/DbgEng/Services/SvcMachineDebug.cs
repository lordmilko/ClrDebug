namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Provided By: DEBUG_SERVICE_MACHINE (where applicable). The ISvcMachineDebug interface is provided only for configurations which are debugging at a hardware or kernel level where the debug primitives are in terms of processors and their contexts rather than threads and processes.
    /// </summary>
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

        /// <summary>
        /// If a default address context is available, this returns it. The machine implementor can decide what constitues a defualt address context.<para/>
        /// If automatic kernel discovery is to take place this must be an address context in which that can occur.
        /// </summary>
        public SvcAddressContext DefaultAddressContext
        {
            get
            {
                SvcAddressContext defaultAddressContextResult;
                TryGetDefaultAddressContext(out defaultAddressContextResult).ThrowDbgEngNotOK();

                return defaultAddressContextResult;
            }
        }

        /// <summary>
        /// If a default address context is available, this returns it. The machine implementor can decide what constitues a defualt address context.<para/>
        /// If automatic kernel discovery is to take place this must be an address context in which that can occur.
        /// </summary>
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

        /// <summary>
        /// ; Returns the number of processors on the machine.
        /// </summary>
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

        /// <summary>
        /// Gets an interface for the given processor.
        /// </summary>
        public SvcExecutionUnit GetProcessor(long processorNumber)
        {
            SvcExecutionUnit processorResult;
            TryGetProcessor(processorNumber, out processorResult).ThrowDbgEngNotOK();

            return processorResult;
        }

        /// <summary>
        /// Gets an interface for the given processor.
        /// </summary>
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
