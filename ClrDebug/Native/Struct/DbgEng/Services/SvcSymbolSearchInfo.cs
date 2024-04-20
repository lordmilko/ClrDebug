using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("HeaderSize = {HeaderSize}, InfoSize = {InfoSize}, SearchOptions = {SearchOptions}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSymbolSearchInfo
    {
        public int HeaderSize;
        public int InfoSize;
        public int SearchOptions;
    }
}
