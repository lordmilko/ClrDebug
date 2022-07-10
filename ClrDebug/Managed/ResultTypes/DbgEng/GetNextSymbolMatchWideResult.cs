using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugSymbols.GetNextSymbolMatchWide"/> method.
    /// </summary>
    [DebuggerDisplay("Buffer = {Buffer}, Offset = {Offset}")]
    public struct GetNextSymbolMatchWideResult
    {
        /// <summary>
        /// Receives the name of the symbol. If Buffer is NULL, the same symbol will be returned again next time one of these methods are called (with the same handle); this can be used to determine the size of the name of the symbol.
        /// </summary>
        public string Buffer { get; }

        /// <summary>
        /// Receives the location in the target's virtual address space of the symbol. If Offset is NULL, this information is not returned.
        /// </summary>
        public ulong Offset { get; }

        public GetNextSymbolMatchWideResult(string buffer, ulong offset)
        {
            Buffer = buffer;
            Offset = offset;
        }
    }
}
