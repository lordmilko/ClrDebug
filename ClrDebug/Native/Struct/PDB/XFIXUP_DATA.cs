using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [DebuggerDisplay("wType = {wType}, wExtra = {wExtra}, rva = {rva}, rvaTarget = {rvaTarget}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct XFIXUP_DATA
    {
        public short wType; //todo: enum?
        public short wExtra;
        public int rva;
        public int rvaTarget;
    }
}
