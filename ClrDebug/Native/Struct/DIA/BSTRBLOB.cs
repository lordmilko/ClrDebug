using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DIA
{
    [DebuggerDisplay("cbSize = {cbSize}, pData = {pData}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public unsafe struct BSTRBLOB
    {
        public int cbSize;
        public byte* pData;
    }
}
