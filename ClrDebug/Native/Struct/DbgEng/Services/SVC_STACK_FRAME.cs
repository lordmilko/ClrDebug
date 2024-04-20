using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [DebuggerDisplay("SizeOfStruct = {SizeOfStruct}, UnwindFlags = {UnwindFlags}, InstructionPointer = {InstructionPointer}, StackPointer = {StackPointer}, FramePointer = {FramePointer}, ReturnAddress = {ReturnAddress}, FrameMachine = {FrameMachine.ToString(),nq}, UnwoundMachine = {UnwoundMachine.ToString(),nq}, Parameters = {Parameters}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SVC_STACK_FRAME
    {
        //v1 Fields

        public int SizeOfStruct; // sizeof(SVC_STACK_FRAME) on entry to unwinder
        public int UnwindFlags;  // See SvcStackUnwindFlags re: non-zero flags on entry, many will be set on exit

        public long InstructionPointer;
        public long StackPointer;
        public long FramePointer;
        public long ReturnAddress;

        //v2 Fields

        public IMAGE_FILE_MACHINE FrameMachine;
        public IMAGE_FILE_MACHINE UnwoundMachine;

        //v3 Fields
        public fixed long Parameters[4];
    }
}
