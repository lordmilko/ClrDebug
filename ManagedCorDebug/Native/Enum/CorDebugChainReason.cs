namespace ManagedCorDebug
{
    /// <summary>
    /// Indicates the reason or reasons for the initiation of a call chain.
    /// </summary>
    /// <remarks>
    /// Use the <see cref="ICorDebugChain.GetReason"/> method to ascertain the reasons for the initiation of a call chain.
    /// </remarks>
    public enum CorDebugChainReason
    {
        /// <summary>
        /// No call chain has been initiated.
        /// </summary>
        CHAIN_NONE = 0,

        /// <summary>
        /// The chain was initiated by a constructor.
        /// </summary>
        CHAIN_CLASS_INIT = 1,

        /// <summary>
        /// The chain was initiated by an exception filter.
        /// </summary>
        CHAIN_EXCEPTION_FILTER = 2,

        /// <summary>
        /// The chain was initiated by code that enforces security.
        /// </summary>
        CHAIN_SECURITY = 4,

        /// <summary>
        /// The chain was initiated by a context policy.
        /// </summary>
        CHAIN_CONTEXT_POLICY = 8,

        /// <summary>
        /// Not used.
        /// </summary>
        CHAIN_INTERCEPTION = 16, // 0x00000010

        /// <summary>
        /// Not used.
        /// </summary>
        CHAIN_PROCESS_START = 32, // 0x00000020

        /// <summary>
        /// The chain was initiated by the start of a thread execution.
        /// </summary>
        CHAIN_THREAD_START = 64, // 0x00000040

        /// <summary>
        /// The chain was initiated by entry into managed code.
        /// </summary>
        CHAIN_ENTER_MANAGED = 128, // 0x00000080

        /// <summary>
        /// The chain was initiated by entry into unmanaged code.
        /// </summary>
        CHAIN_ENTER_UNMANAGED = 256, // 0x00000100

        /// <summary>
        /// Not used.
        /// </summary>
        CHAIN_DEBUGGER_EVAL = 512, // 0x00000200

        /// <summary>
        /// Not used.
        /// </summary>
        CHAIN_CONTEXT_SWITCH = 1024, // 0x00000400

        /// <summary>
        /// The chain was initiated by a function evaluation.
        /// </summary>
        CHAIN_FUNC_EVAL = 2048 // 0x00000800
    }
}