using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("cbSize = {cbSize}, ulClipFmt = {ulClipFmt}, pClipData = {pClipData}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct CLIPDATA
    {
        public int cbSize;
        public int ulClipFmt;
        public byte* pClipData;
    }
}
