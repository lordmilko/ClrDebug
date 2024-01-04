using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SvcSymbolRegisterDescription
    {
        public int Number;
        public int Size;
    }
}
