namespace ClrDebug.DbgEng
{
    public class SvcStackFrameUnwinderTransition : ComObject<ISvcStackFrameUnwinderTransition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackFrameUnwinderTransition"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackFrameUnwinderTransition(ISvcStackFrameUnwinderTransition raw) : base(raw)
        {
        }

        #region ISvcStackFrameUnwinderTransition
        #region RequestsEntryTransition

        public void RequestsEntryTransition(ISvcStackUnwindContext pUnwindContext, ref SVC_STACK_FRAME pStackFrame, ref ISvcRegisterContext pRegisterContext)
        {
            TryRequestsEntryTransition(pUnwindContext, ref pStackFrame, ref pRegisterContext).ThrowDbgEngNotOK();
        }

        public HRESULT TryRequestsEntryTransition(ISvcStackUnwindContext pUnwindContext, ref SVC_STACK_FRAME pStackFrame, ref ISvcRegisterContext pRegisterContext)
        {
            /*HRESULT RequestsEntryTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterContext,
            [Out] out UnwinderTransitionKind pTransitionKind);*/
            UnwinderTransitionKind pTransitionKind;

            return Raw.RequestsEntryTransition(pUnwindContext, ref pStackFrame, ref pRegisterContext, out pTransitionKind);
        }

        #endregion
        #region RequestsExitTransition

        public void RequestsExitTransition(ISvcStackUnwindContext pUnwindContext, ref SVC_STACK_FRAME pStackFrame, ref ISvcRegisterContext pRegisterCotnext)
        {
            TryRequestsExitTransition(pUnwindContext, ref pStackFrame, ref pRegisterCotnext).ThrowDbgEngNotOK();
        }

        public HRESULT TryRequestsExitTransition(ISvcStackUnwindContext pUnwindContext, ref SVC_STACK_FRAME pStackFrame, ref ISvcRegisterContext pRegisterCotnext)
        {
            /*HRESULT RequestsExitTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterCotnext,
            [Out] out UnwinderTransitionKind pTransitionKind);*/
            UnwinderTransitionKind pTransitionKind;

            return Raw.RequestsExitTransition(pUnwindContext, ref pStackFrame, ref pRegisterCotnext, out pTransitionKind);
        }

        #endregion
        #region RequestsTerminalTransition

        public void RequestsTerminalTransition(ISvcStackUnwindContext pUnwindContext, ref SVC_STACK_FRAME pStackFrame, ref ISvcRegisterContext pRegisterContext)
        {
            TryRequestsTerminalTransition(pUnwindContext, ref pStackFrame, ref pRegisterContext).ThrowDbgEngNotOK();
        }

        public HRESULT TryRequestsTerminalTransition(ISvcStackUnwindContext pUnwindContext, ref SVC_STACK_FRAME pStackFrame, ref ISvcRegisterContext pRegisterContext)
        {
            /*HRESULT RequestsTerminalTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterContext,
            [Out] out UnwinderTransitionKind pTransitionKind);*/
            UnwinderTransitionKind pTransitionKind;

            return Raw.RequestsTerminalTransition(pUnwindContext, ref pStackFrame, ref pRegisterContext, out pTransitionKind);
        }

        #endregion
        #endregion
    }
}
