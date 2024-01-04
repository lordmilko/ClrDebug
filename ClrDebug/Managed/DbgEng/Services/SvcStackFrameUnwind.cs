namespace ClrDebug.DbgEng
{
    public class SvcStackFrameUnwind : ComObject<ISvcStackFrameUnwind>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackFrameUnwind"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackFrameUnwind(ISvcStackFrameUnwind raw) : base(raw)
        {
        }

        #region ISvcStackFrameUnwind
        #region UnwindFrame

        public SvcRegisterContext UnwindFrame(ISvcStackUnwindContext pUnwindContext, ref SVC_STACK_FRAME pStackFrame, ISvcRegisterContext pInRegisterContext)
        {
            SvcRegisterContext ppOutRegisterContextResult;
            TryUnwindFrame(pUnwindContext, ref pStackFrame, pInRegisterContext, out ppOutRegisterContextResult).ThrowDbgEngNotOK();

            return ppOutRegisterContextResult;
        }

        public HRESULT TryUnwindFrame(ISvcStackUnwindContext pUnwindContext, ref SVC_STACK_FRAME pStackFrame, ISvcRegisterContext pInRegisterContext, out SvcRegisterContext ppOutRegisterContextResult)
        {
            /*HRESULT UnwindFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pInRegisterContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppOutRegisterContext);*/
            ISvcRegisterContext ppOutRegisterContext;
            HRESULT hr = Raw.UnwindFrame(pUnwindContext, ref pStackFrame, pInRegisterContext, out ppOutRegisterContext);

            if (hr == HRESULT.S_OK)
                ppOutRegisterContextResult = ppOutRegisterContext == null ? null : new SvcRegisterContext(ppOutRegisterContext);
            else
                ppOutRegisterContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #endregion
    }
}
