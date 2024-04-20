using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("Number = {Number}, Size = {Size}")]
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSymbolRegisterDescription
    {
        public int Number;
        public int Size;
    }
}
