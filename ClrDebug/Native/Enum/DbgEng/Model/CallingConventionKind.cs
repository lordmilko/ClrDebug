namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines the kind of calling convention of a function type.
    /// </summary>
    public enum CallingConventionKind : uint
    {
        /// <summary>
        /// The calling convention is not known
        /// </summary>
        CallingConventionUnknown,

        /// <summary>
        /// The calling convention is __cdecl
        /// </summary>
        CallingConventionCDecl,

        /// <summary>
        /// The calling convention is fastcall
        /// </summary>
        CallingConventionFastCall,

        /// <summary>
        /// The calling convention is stdcall
        /// </summary>
        CallingConventionStdCall,

        /// <summary>
        /// The calling convention is syscall
        /// </summary>
        CallingConventionSysCall,

        /// <summary>
        /// The calling convention is thiscall
        /// </summary>
        CallingConventionThisCall
    }
}
