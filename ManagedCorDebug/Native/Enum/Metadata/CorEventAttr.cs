namespace ManagedCorDebug
{
    /// <summary>
    /// Contains values that describe the metadata of an event.
    /// </summary>
    public enum CorEventAttr
    {
        /// <summary>
        /// Specifies that the event is special, and that its name describes how.
        /// </summary>
        evSpecialName = 0x0200,     // event is special.  Name describes how.

        /// <summary>
        /// Reserved for internal use by the common language runtime.
        /// </summary>
        evReservedMask = 0x0400,

        /// <summary>
        /// Specifies that the common language runtime should check the encoding of the event name.
        /// </summary>
        evRTSpecialName = 0x0400,     // Runtime(metadata internal APIs) should check name encoding.
    }
}