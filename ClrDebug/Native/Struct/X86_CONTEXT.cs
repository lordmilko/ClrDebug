using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    [DebuggerDisplay("ContextFlags = {ContextFlags.ToString(),nq}, Dr0 = {Dr0}, Dr1 = {Dr1}, Dr2 = {Dr2}, Dr3 = {Dr3}, Dr6 = {Dr6}, Dr7 = {Dr7}, FloatSave = {FloatSave.ToString(),nq}, SegGs = {SegGs}, SegFs = {SegFs}, SegEs = {SegEs}, SegDs = {SegDs}, Edi = {Edi}, Esi = {Esi}, Ebx = {Ebx}, Edx = {Edx}, Ecx = {Ecx}, Eax = {Eax}, Ebp = {Ebp}, Eip = {Eip}, SegCs = {SegCs}, EFlags = {EFlags}, Esp = {Esp}, SegSs = {SegSs}, ExtendedRegisters = {ExtendedRegisters}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct X86_CONTEXT
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
        public X86_CONTEXT_FLAGS EFlags;
        public int Esp;
        public int SegSs;

        // Retrieved by CONTEXT_EXTENDED_REGISTERS
        public fixed byte ExtendedRegisters[512];
    }
}
