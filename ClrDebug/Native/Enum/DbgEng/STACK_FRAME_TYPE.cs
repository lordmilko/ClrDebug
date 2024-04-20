using System;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The types of inline frame context.
    /// </summary>
    [Flags]
    public enum STACK_FRAME_TYPE : byte
    {
        STACK_FRAME_TYPE_INIT = 0x00,
        STACK_FRAME_TYPE_STACK = 0x01,
        STACK_FRAME_TYPE_INLINE = 0x02,

        /// <summary>
        /// Whether the instruction pointer is the current IP or a RA from callee frame.
        /// </summary>
        STACK_FRAME_TYPE_RA = 0x80,

        STACK_FRAME_TYPE_IGNORE = 0xFF
    }
}
