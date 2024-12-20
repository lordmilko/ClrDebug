namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Flags in SVC_STACK_FRAME that define attributes of the unwind information.
    /// </summary>
    public enum SvcStackUnwindFlags : uint
    {
        /// <summary>
        /// Indicates that ReturnAddress of the stack frame should be considered invalid -- it could not be determined.
        /// </summary>
        StackUnwindUnknownReturn = 0x00000001,

        /// <summary>
        /// On entry -- indicates that "FrameMachine" specifies an alternate input architecture to the unwinder. On exit -- indicates that "UnwoundMachine" specifies that the architecture of the stack changed.
        /// </summary>
        StackUnwindArchitectureSpecified = 0x00000002,

        /// <summary>
        /// Indicates that the Parameters array is populated and valid; otherwise -- it should be considered invalid.
        /// </summary>
        StackUnwindParametersSpecified = 0x00000004,

        /// <summary>
        /// Indicates that the unwinder has determined that the unwound return address is outside the bounds of the function with the containing call site because the call site was a [[noreturn]] tail call.<para/>
        /// It is optional for an unwinder to populate this information. It is extra information which can be used as a hint to the caller.
        /// </summary>
        StackUnwindTailCallReturn = 0x00000008,

        /// <summary>
        /// Indicates that there may be skipped stack frames between the prior frame and the one on which this flag is returned.
        /// </summary>
        StackUnwindSkippedFrames = 0x00000010,

        StackUnwindFromExceptionOrSignalFrame = 0x00000020
    }
}
