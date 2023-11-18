namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Internal debugger output, used mainly for debugging the debugger. Output
    /// may only occur in debug builds.<para/>
    /// Use anywhere <see cref="DEBUG_OUTPUT"/> is specified as a mask.
    /// </summary>
    public enum DEBUG_IOUTPUT : uint
    {
        /// <summary>
        /// KD protocol output.
        /// </summary>
        KD_PROTOCOL = 0x80000000,

        /// <summary>
        /// Remoting output.
        /// </summary>
        REMOTING = 0x40000000,

        /// <summary>
        /// Breakpoint output.
        /// </summary>
        BREAKPOINT = 0x20000000,

        /// <summary>
        /// Event output.
        /// </summary>
        EVENT = 0x10000000,

        /// <summary>
        /// Virtual/Physical address translation
        /// </summary>
        ADDR_TRANSLATE = 0x08000000
    }
}
