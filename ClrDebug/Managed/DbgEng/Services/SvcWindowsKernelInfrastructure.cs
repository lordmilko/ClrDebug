namespace ClrDebug.DbgEng
{
    public class SvcWindowsKernelInfrastructure : ComObject<ISvcWindowsKernelInfrastructure>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcWindowsKernelInfrastructure"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcWindowsKernelInfrastructure(ISvcWindowsKernelInfrastructure raw) : base(raw)
        {
        }

        #region ISvcWindowsKernelInfrastructure
        #region FindKpcrForProcessor

        public long FindKpcrForProcessor(long processorNumber)
        {
            long kpcrAddress;
            TryFindKpcrForProcessor(processorNumber, out kpcrAddress).ThrowDbgEngNotOK();

            return kpcrAddress;
        }

        public HRESULT TryFindKpcrForProcessor(long processorNumber, out long kpcrAddress)
        {
            /*HRESULT FindKpcrForProcessor(
            [In] long processorNumber,
            [Out] out long kpcrAddress);*/
            return Raw.FindKpcrForProcessor(processorNumber, out kpcrAddress);
        }

        #endregion
        #region FindKprcbForProcessor

        public long FindKprcbForProcessor(long processorNumber)
        {
            long kprcbAddress;
            TryFindKprcbForProcessor(processorNumber, out kprcbAddress).ThrowDbgEngNotOK();

            return kprcbAddress;
        }

        public HRESULT TryFindKprcbForProcessor(long processorNumber, out long kprcbAddress)
        {
            /*HRESULT FindKprcbForProcessor(
            [In] long processorNumber,
            [Out] out long kprcbAddress);*/
            return Raw.FindKprcbForProcessor(processorNumber, out kprcbAddress);
        }

        #endregion
        #region FindThreadForProcessor

        public long FindThreadForProcessor(long processorNumber)
        {
            long kthreadAddress;
            TryFindThreadForProcessor(processorNumber, out kthreadAddress).ThrowDbgEngNotOK();

            return kthreadAddress;
        }

        public HRESULT TryFindThreadForProcessor(long processorNumber, out long kthreadAddress)
        {
            /*HRESULT FindThreadForProcessor(
            [In] long processorNumber,
            [Out] out long kthreadAddress);*/
            return Raw.FindThreadForProcessor(processorNumber, out kthreadAddress);
        }

        #endregion
        #region ReadContextForProcessor

        public SvcRegisterContext ReadContextForProcessor(long processorNumber, SvcContextFlags contextFlags)
        {
            SvcRegisterContext ppRegisterContextResult;
            TryReadContextForProcessor(processorNumber, contextFlags, out ppRegisterContextResult).ThrowDbgEngNotOK();

            return ppRegisterContextResult;
        }

        public HRESULT TryReadContextForProcessor(long processorNumber, SvcContextFlags contextFlags, out SvcRegisterContext ppRegisterContextResult)
        {
            /*HRESULT ReadContextForProcessor(
            [In] long processorNumber,
            [In] SvcContextFlags contextFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);*/
            ISvcRegisterContext ppRegisterContext;
            HRESULT hr = Raw.ReadContextForProcessor(processorNumber, contextFlags, out ppRegisterContext);

            if (hr == HRESULT.S_OK)
                ppRegisterContextResult = ppRegisterContext == null ? null : new SvcRegisterContext(ppRegisterContext);
            else
                ppRegisterContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #region ReadSpecialContextForProcessor

        public SvcRegisterContext ReadSpecialContextForProcessor(long processorNumber)
        {
            SvcRegisterContext ppSpecialContextResult;
            TryReadSpecialContextForProcessor(processorNumber, out ppSpecialContextResult).ThrowDbgEngNotOK();

            return ppSpecialContextResult;
        }

        public HRESULT TryReadSpecialContextForProcessor(long processorNumber, out SvcRegisterContext ppSpecialContextResult)
        {
            /*HRESULT ReadSpecialContextForProcessor(
            [In] long processorNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppSpecialContext);*/
            ISvcRegisterContext ppSpecialContext;
            HRESULT hr = Raw.ReadSpecialContextForProcessor(processorNumber, out ppSpecialContext);

            if (hr == HRESULT.S_OK)
                ppSpecialContextResult = ppSpecialContext == null ? null : new SvcRegisterContext(ppSpecialContext);
            else
                ppSpecialContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #endregion
    }
}
