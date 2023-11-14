using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("cbSize = {cbSize}, pBlobData = {pBlobData}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct BLOB
    {
        public int cbSize;
        public byte* pBlobData;
    }
}
