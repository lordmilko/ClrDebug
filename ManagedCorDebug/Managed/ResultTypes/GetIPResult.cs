using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugILFrame.GetIP"/> method.
    /// </summary>
    [DebuggerDisplay("pnOffset = {pnOffset}, pMappingResult = {pMappingResult}")]
    public struct GetIPResult
    {
        /// <summary>
        /// [out] The value of the instruction pointer.
        /// </summary>
        public int pnOffset { get; }

        /// <summary>
        /// [out] A pointer to a bitwise combination of the <see cref="CorDebugMappingResult"/> enumeration values that describe how the value of the instruction pointer was obtained.
        /// </summary>
        public CorDebugMappingResult pMappingResult { get; }

        public GetIPResult(int pnOffset, CorDebugMappingResult pMappingResult)
        {
            this.pnOffset = pnOffset;
            this.pMappingResult = pMappingResult;
        }
    }
}