using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("VirtualAddress = {VirtualAddress}, Size = {Size}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_DATA_DIRECTORY
    {
        public int VirtualAddress;
        public int Size;
    }
}
