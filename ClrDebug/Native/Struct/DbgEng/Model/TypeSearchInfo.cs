using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The search record passed to EnumerateChildrenEx specifically for SymbolType searches.
    /// </summary>
    /// <remarks>
    /// Use SymbolSearchInfo to describe the search record used to restrict symbol searches.
    /// </remarks>
    [DebuggerDisplay("HeaderSize = {HeaderSize}, InfoSize = {InfoSize}, SearchOptions = {SearchOptions}, SearchType = {SearchType.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct TypeSearchInfo
    {
        public int HeaderSize; //sizeof SymbolSearchInfo
        public int InfoSize; //sizeof TypeSearchInfo
        public int SearchOptions;

        /// <summary>
        /// Defines the type being searched for.
        /// </summary>
        public TypeKind SearchType;
    }
}
