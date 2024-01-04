namespace ClrDebug.DbgEng
{
    public class SvcTrapContextRestoration : ComObject<ISvcTrapContextRestoration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcTrapContextRestoration"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcTrapContextRestoration(ISvcTrapContextRestoration raw) : base(raw)
        {
        }

        #region ISvcTrapContextRestoration
        #region ReadTrapContext

        public SvcRegisterContext ReadTrapContext(TrapContextKind trapKind, ISvcAddressContext pAddressContext, ISvcRegisterContext pInContext, long trapContext)
        {
            SvcRegisterContext ppOutContextResult;
            TryReadTrapContext(trapKind, pAddressContext, pInContext, trapContext, out ppOutContextResult).ThrowDbgEngNotOK();

            return ppOutContextResult;
        }

        public HRESULT TryReadTrapContext(TrapContextKind trapKind, ISvcAddressContext pAddressContext, ISvcRegisterContext pInContext, long trapContext, out SvcRegisterContext ppOutContextResult)
        {
            /*HRESULT ReadTrapContext(
            [In] TrapContextKind trapKind,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext pAddressContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pInContext,
            [In] long trapContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppOutContext);*/
            ISvcRegisterContext ppOutContext;
            HRESULT hr = Raw.ReadTrapContext(trapKind, pAddressContext, pInContext, trapContext, out ppOutContext);

            if (hr == HRESULT.S_OK)
                ppOutContextResult = ppOutContext == null ? null : new SvcRegisterContext(ppOutContext);
            else
                ppOutContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #endregion
    }
}
