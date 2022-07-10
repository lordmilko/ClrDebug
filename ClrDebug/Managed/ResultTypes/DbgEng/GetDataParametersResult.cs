using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugBreakpoint.GetDataParameters"/> method.
    /// </summary>
    [DebuggerDisplay("Size = {Size}, AccessType = {AccessType.ToString(),nq}")]
    public struct GetDataParametersResult
    {
        /// <summary>
        /// The size, in bytes, of the memory block whose access triggers the breakpoint. For more information about restrictions on the value of Size based on the processor type, see Valid Parameters for Processor Breakpoints.
        /// </summary>
        public uint Size { get; }

        /// <summary>
        /// The type of access that triggers the breakpoint. For a list of possible values, see Valid Parameters for Processor Breakpoints.
        /// </summary>
        public DEBUG_BREAKPOINT_ACCESS_TYPE AccessType { get; }

        public GetDataParametersResult(uint size, DEBUG_BREAKPOINT_ACCESS_TYPE accessType)
        {
            Size = size;
            AccessType = accessType;
        }
    }
}
