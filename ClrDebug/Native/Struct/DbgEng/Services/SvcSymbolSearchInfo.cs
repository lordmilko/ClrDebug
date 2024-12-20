using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines options and properties for a symbol search. This struct is always given at &lt;HeaderSize&gt;. An optional per search type struct follows of InfoSize.
    /// </summary>
    [DebuggerDisplay("HeaderSize = {HeaderSize}, InfoSize = {InfoSize}, SearchOptions = {SearchOptions}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSymbolSearchInfo
    {
        public int HeaderSize;
        public int InfoSize;
        public int SearchOptions;
    }
}
