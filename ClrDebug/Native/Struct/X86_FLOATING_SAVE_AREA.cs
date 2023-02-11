using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("ControlWord = {ControlWord}, StatusWord = {StatusWord}, TagWord = {TagWord}, ErrorOffset = {ErrorOffset}, ErrorSelector = {ErrorSelector}, DataOffset = {DataOffset}, DataSelector = {DataSelector}, RegisterArea = {RegisterArea}, Cr0NpxState = {Cr0NpxState}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct X86_FLOATING_SAVE_AREA
    {
        public int ControlWord;
        public int StatusWord;
        public int TagWord;
        public int ErrorOffset;
        public int ErrorSelector;
        public int DataOffset;
        public int DataSelector;
        public fixed byte RegisterArea[80];
        public int Cr0NpxState;
    }
}
