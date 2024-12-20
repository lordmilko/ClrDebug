namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Details what kind of stack frame has been returned.
    /// </summary>
    public enum StackProviderFrameKind : uint
    {
        /// <summary>
        /// Indicates that the frame is generic. There must be an implementation of ISvcStackProviderFrameAttributes.
        /// </summary>
        StackProviderFrameGeneric,

        /// <summary>
        /// Indicates that the frame is a physical frame from an underlying stack unwinder. The frame interface must QI for ISvcStackProviderPhysicalFrame and must be able to provide a SVC_STACK_FRAME structure and an unwound register context for the stack frame.
        /// </summary>
        StackProviderFramePhysical,

        /// <summary>
        /// Indicates that the frame is an inline frame on top of another type of stack frame. The frame interface must QI for ISvcStackProviderInlineFrame and must be able to return another frame which represents the "underlying" frame (the non-inline one).
        /// </summary>
        StackProviderFrameInline,

        /// <summary>
        /// Indicates that the frame is a partial physical frame. The frame interface must QI for ISvcStackProviderPartialPhysicalFrame and must be able to return, at minimum, an instruction pointer.<para/>
        /// Other values are optional.
        /// </summary>
        StackProviderFramePartialPhysical
    }
}
