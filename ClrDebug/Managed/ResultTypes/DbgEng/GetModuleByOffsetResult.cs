using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetModuleByOffset"/> method.
    /// </summary>
    [DebuggerDisplay("Index = {Index}, Base = {Base}")]
    public struct GetModuleByOffsetResult
    {
        /// <summary>
        /// Receives the index of the module. If Index is NULL, this information is not returned.
        /// </summary>
        public uint Index { get; }

        /// <summary>
        /// Receives the location in the target's memory address space of the base of the module. If Base is NULL, this information is not returned.
        /// </summary>
        public ulong Base { get; }

        public GetModuleByOffsetResult(uint index, ulong @base)
        {
            Index = index;
            Base = @base;
        }
    }
}
