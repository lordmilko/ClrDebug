using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSymbolSearchInfo
    {
        public int HeaderSize;
        public int InfoSize;
        public int SearchOptions;
    }
}
