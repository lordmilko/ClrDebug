using System.Runtime.InteropServices;

namespace ClrDebug
{
    [StructLayout(LayoutKind.Sequential)]
    public struct X86_FLOATING_SAVE_AREA
    {
        public int ControlWord;
        public int StatusWord;
        public int TagWord;
        public int ErrorOffset;
        public int ErrorSelector;
        public int DataOffset;
        public int DataSelector;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
        public byte[] RegisterArea;
        public int Cr0NpxState;
    }
}