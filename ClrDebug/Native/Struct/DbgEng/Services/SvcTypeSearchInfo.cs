using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An optional record passed in a search info which restricts the type search further.
    /// </summary>
    [DebuggerDisplay("SearchType = {SearchType.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcTypeSearchInfo
    {
        public SvcSymbolTypeKind SearchType;
    }
}
