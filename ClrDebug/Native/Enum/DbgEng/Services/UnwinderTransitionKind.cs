namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of transition from one stack unwinder to another when there are multiple unwinders in an aggregate service.
    /// </summary>
    public enum UnwinderTransitionKind : uint
    {
        /// <summary>
        /// The given unwinder is not requesting a transition from the currently active stack unwinder.
        /// </summary>
        UnwinderTransitionNone,

        /// <summary>
        /// Indicates that the given unwinder would like control of stack unwinding. The stack frame and register context have been adjusted.<para/>
        /// In addition, they have been adjusted to the TOP of the stack for the given unwinder. Such should be utilized as a stack frame prior to calling the unwinder to unwind a frame.
        /// </summary>
        UnwinderTransitionAddFrame,

        /// <summary>
        /// Indicates that the given unwinder would like control of stack unwinding. The stack frame and register context may or may not have been adjusted.<para/>
        /// The client should call the transitioned unwinder to get the next frame. The stack frame/register context output arguments from the RequestsTransition call should not be used as an independent stack frame.
        /// </summary>
        UnwinderTransitionUnwindFrame
    }
}
