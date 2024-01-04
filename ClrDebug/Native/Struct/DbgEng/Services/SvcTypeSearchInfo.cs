using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcTypeSearchInfo
    {
        public SvcSymbolTypeKind SearchType;
    }
}
