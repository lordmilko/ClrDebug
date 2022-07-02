using System.Runtime.InteropServices;

namespace ClrDebug
{
    [StructLayout(LayoutKind.Sequential)]
    public struct X86_CONTEXT
    {
        public ContextFlags ContextFlags; //set this to an appropriate value

        // Retrieved by CONTEXT_DEBUG_REGISTERS
        public int Dr0;
        public int Dr1;
        public int Dr2;
        public int Dr3;
        public int Dr6;
        public int Dr7;

        // Retrieved by CONTEXT_FLOATING_POINT
        public X86_FLOATING_SAVE_AREA FloatSave;

        // Retrieved by CONTEXT_SEGMENTS
        public int SegGs;
        public int SegFs;
        public int SegEs;
        public int SegDs;

        // Retrieved by CONTEXT_INTEGER
        public int Edi;
        public int Esi;
        public int Ebx;
        public int Edx;
        public int Ecx;
        public int Eax;

        // Retrieved by CONTEXT_CONTROL
        public int Ebp;
        public int Eip;
        public int SegCs;
        public int EFlags;
        public int Esp;
        public int SegSs;

        // Retrieved by CONTEXT_EXTENDED_REGISTERS
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] ExtendedRegisters;
    }
}