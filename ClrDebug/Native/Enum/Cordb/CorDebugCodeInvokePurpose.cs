namespace ClrDebug
{
    /// <summary>
    /// Describes why an exported function calls managed code.
    /// </summary>
    /// <remarks>
    /// This enumeration is used by the <see cref="ICorDebugProcess6.GetExportStepInfo"/> method to provide information
    /// about stepping through managed code.
    /// </remarks>
    public enum CorDebugCodeInvokePurpose
    {
        /// <summary>
        /// None or unknown.
        /// </summary>
        CODE_INVOKE_PURPOSE_NONE,

        /// <summary>
        /// The managed code will run any managed entry point, such as a reverse p-invoke. Any more detailed purpose is unknown by the runtime.
        /// </summary>
        CODE_INVOKE_PURPOSE_NATIVE_TO_MANAGED_TRANSITION,

        /// <summary>
        /// The managed code will run a static constructor.
        /// </summary>
        CODE_INVOKE_PURPOSE_CLASS_INIT,

        /// <summary>
        /// The managed code will run the implementation for some interface method that was called.
        /// </summary>
        CODE_INVOKE_PURPOSE_INTERFACE_DISPATCH
    }
}
