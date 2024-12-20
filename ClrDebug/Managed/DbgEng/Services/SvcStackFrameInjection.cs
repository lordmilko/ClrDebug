namespace ClrDebug.DbgEng
{
    /// <summary>
    /// If a given stack unwinder service implements this interface, other components involved in unwind can inject a frame during the unwinder.<para/>
    /// The injected frame becomes the NEXT frame regardless of other Unwind* calls that may or may not be in progress.
    /// </summary>
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

        /// <summary>
        /// InjectStackFrame Adds a stack frame with the given information and register context as the immediately next frame from the unwind.
        /// </summary>
        public void InjectStackFrame(ISvcStackUnwindContext pUnwindContext, SVC_STACK_FRAME pStackFrame, ISvcRegisterContext pRegisterContext)
        {
            TryInjectStackFrame(pUnwindContext, pStackFrame, pRegisterContext).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// InjectStackFrame Adds a stack frame with the given information and register context as the immediately next frame from the unwind.
        /// </summary>
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
