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

        /// <summary>
        /// Given a register context of a trap handler (e.g.: a signal frame), restores the register context at the trap point.<para/>
        /// This operates in one of two modes - trapContext == 0: the input context is effectively for a stack frame and the location of the trap context should be determined from the trapKind and the input context.<para/>
        /// The restored context is a copy of the input context overwritten with the register values of the trap context. - trapContext != 0: the location of the trap context is given by trapContext.<para/>
        /// The restored context is a copy of the input context (which may just be an empty register context for the architecture) overwritten with the register values of the rap context.
        /// </summary>
        public SvcRegisterContext ReadTrapContext(TrapContextKind trapKind, ISvcAddressContext pAddressContext, ISvcRegisterContext pInContext, long trapContext)
        {
            SvcRegisterContext ppOutContextResult;
            TryReadTrapContext(trapKind, pAddressContext, pInContext, trapContext, out ppOutContextResult).ThrowDbgEngNotOK();

            return ppOutContextResult;
        }

        /// <summary>
        /// Given a register context of a trap handler (e.g.: a signal frame), restores the register context at the trap point.<para/>
        /// This operates in one of two modes - trapContext == 0: the input context is effectively for a stack frame and the location of the trap context should be determined from the trapKind and the input context.<para/>
        /// The restored context is a copy of the input context overwritten with the register values of the trap context. - trapContext != 0: the location of the trap context is given by trapContext.<para/>
        /// The restored context is a copy of the input context (which may just be an empty register context for the architecture) overwritten with the register values of the rap context.
        /// </summary>
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
