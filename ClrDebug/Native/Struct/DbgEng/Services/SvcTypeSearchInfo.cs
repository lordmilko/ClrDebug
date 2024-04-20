using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("SearchType = {SearchType.ToString(),nq}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcTypeSearchInfo
    {
        public SvcSymbolTypeKind SearchType;
    }
}
