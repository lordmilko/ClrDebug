namespace ClrDebug.DbgEng
{
    public class SvcStackFrameInjection : ComObject<ISvcStackFrameInjection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackFrameInjection"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackFrameInjection(ISvcStackFrameInjection raw) : base(raw)
        {
        }

        #region ISvcStackFrameInjection
        #region InjectStackFrame

        public void InjectStackFrame(ISvcStackUnwindContext pUnwindContext, SVC_STACK_FRAME pStackFrame, ISvcRegisterContext pRegisterContext)
        {
            TryInjectStackFrame(pUnwindContext, pStackFrame, pRegisterContext).ThrowDbgEngNotOK();
        }

        public HRESULT TryInjectStackFrame(ISvcStackUnwindContext pUnwindContext, SVC_STACK_FRAME pStackFrame, ISvcRegisterContext pRegisterContext)
        {
            /*HRESULT InjectStackFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In] ref SVC_STACK_FRAME pStackFrame,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pRegisterContext);*/
            return Raw.InjectStackFrame(pUnwindContext, ref pStackFrame, pRegisterContext);
        }

        #endregion
        #endregion
    }
}
