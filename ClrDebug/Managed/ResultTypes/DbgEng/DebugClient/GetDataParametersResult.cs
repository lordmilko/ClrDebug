using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugBreakpoint.DataParameters"/> property.
    /// </summary>
    [DebuggerDisplay("Size = {Size}, AccessType = {AccessType.ToString(),nq}")]
    public struct GetDataParametersResult
    {
        /// <summary>
        /// The size, in bytes, of the memory block whose access triggers the breakpoint. For more information about restrictions on the value of Size based on the processor type, see Valid Parameters for Processor Breakpoints.
        /// </summary>
        public int Size { get; }

        /// <summary>
        /// The type of access that triggers the breakpoint. For a list of possible values, see Valid Parameters for Processor Breakpoints.
        /// </summary>
        public DEBUG_BREAK AccessType { get; }

        public GetDataParametersResult(int size, DEBUG_BREAK accessType)
        {
            Size = size;
            AccessType = accessType;
        }
    }
}
