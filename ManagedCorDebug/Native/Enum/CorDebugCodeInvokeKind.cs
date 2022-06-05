namespace ManagedCorDebug
{
    /// <summary>
    /// Describes how an exported function invokes managed code.
    /// </summary>
    /// <remarks>
    /// This enumeration is used by the <see cref="ICorDebugProcess6.GetExportStepInfo"/> method to provide information
    /// about stepping through managed code.
    /// </remarks>
    public enum CorDebugCodeInvokeKind
    {
        /// <summary>
        /// If any managed code is invoked by this method, it will have to be located by explicit events or breakpoints later. --or-- We may just miss some of the managed code this method calls because there is no easy way to stop on it. --or-- The method may never invoke managed code.
        /// </summary>
        CODE_INVOKE_KIND_NONE,

        /// <summary>
        /// This method will invoke managed code via a return instruction. Stepping out should arrive at the next managed code.
        /// </summary>
        CODE_INVOKE_KIND_RETURN,

        /// <summary>
        /// This method will invoke managed code via a tail-call. Single-stepping and stepping over any call instructions should arrive at managed code.
        /// </summary>
        CODE_INVOKE_KIND_TAILCALL
    }
}