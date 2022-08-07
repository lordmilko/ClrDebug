namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Specifies the types of information that can be queried from <see cref="IDebugDataSpaces4.GetOffsetInformation"/>
    /// </summary>
    public enum DEBUG_OFFSINFO : uint
    {
        /// <summary>
        /// Returns the source of the target's virtual memory at Offset. This is where the debugger engine reads the memory from.
        /// Space must be set to DEBUG_DATA_SPACE_VIRTUAL. A <see cref="DEBUG_VSOURCE"/> is returned to Buffer
        /// </summary>
        VIRTUAL_SOURCE = 0x00000001,
    }
}
