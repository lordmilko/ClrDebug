using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This structure describes, the search record passed to EnumerateChildrenEx in order to restrict symbol searches.<para/>
    /// A given kind of symbol (as indicated by the SymbolKind enumeration) searched may have its own derived type.
    /// </summary>
    [DebuggerDisplay("HeaderSize = {HeaderSize}, InfoSize = {InfoSize}, SearchOptions = {SearchOptions}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SymbolSearchInfo
    {
        /// <summary>
        /// sizeof(SymbolSearchInfo)
        /// </summary>
        public int HeaderSize; //sizeof SymbolSearchInfo

        /// <summary>
        /// sizeof(* by SymbolKind *)
        /// </summary>
        public int InfoSize; //sizeof SymbolSearchInfo

        /// <summary>
        /// What follows is per SymbolKind.
        /// </summary>
        public int SearchOptions;
    }
}
