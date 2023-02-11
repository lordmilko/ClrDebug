using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Represents a function's arguments, in left-to-right order.
    /// </summary>
    /// <remarks>
    /// A function may have many arguments. Those arguments might not be stored contiguously in memory. You might have
    /// a block of three arguments in one place, a block of two arguments in another place, and a final block of one argument
    /// in a different place. These arguments are all for the same function; they're just stored in different places. The
    /// COR_PRF_FUNCTION_ARGUMENT_INFO structure represents all the arguments of a single function. It uses an array to
    /// reference all the blocks of function arguments. So, for a single function, you have a single COR_PRF_FUNCTION_ARGUMENT_INFO
    /// structure, which references multiple COR_PRF_FUNCTION_ARGUMENT_RANGE structures, each of which points to one or
    /// more function arguments. Arguments that are stored in registers are spilled into memory to build the structures.
    /// </remarks>
    [DebuggerDisplay("numRanges = {numRanges}, totalArgumentSize = {totalArgumentSize}, ranges = {ranges}")]
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public unsafe struct COR_PRF_FUNCTION_ARGUMENT_INFO
    {
        /// <summary>
        /// The number of blocks of arguments. That is, this value is the number of <see cref="COR_PRF_FUNCTION_ARGUMENT_RANGE"/> structures in the ranges array.
        /// </summary>
        public int numRanges;

        /// <summary>
        /// The total size of all arguments. In other words, this value is the sum of the argument lengths.
        /// </summary>
        public int totalArgumentSize;

        /// <summary>
        /// An array of COR_PRF_FUNCTION_ARGUMENT_RANGE structures, each of which represents one block of function arguments.
        /// </summary>
        public COR_PRF_FUNCTION_ARGUMENT_RANGE* ranges;
    }
}
