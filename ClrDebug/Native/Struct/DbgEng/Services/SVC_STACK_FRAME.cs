using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Abstraction for an architecture neutral stack frame.
    /// </summary>
    [DebuggerDisplay("SizeOfStruct = {SizeOfStruct}, UnwindFlags = {UnwindFlags}, InstructionPointer = {InstructionPointer}, StackPointer = {StackPointer}, FramePointer = {FramePointer}, ReturnAddress = {ReturnAddress}, FrameMachine = {FrameMachine.ToString(),nq}, UnwoundMachine = {UnwoundMachine.ToString(),nq}, Parameters = {Parameters}")]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SVC_STACK_FRAME
    {
        /// <summary>
        /// sizeof(SVC_STACK_FRAME) on entry to unwinder.
        /// </summary>
        public int SizeOfStruct;

        /// <summary>
        /// See SvcStackUnwindFlags re: non-zero flags on entry, many will be set on exit
        /// </summary>
        public int UnwindFlags;

        public long InstructionPointer;
        public long StackPointer;
        public long FramePointer;
        public long ReturnAddress;

        /// <summary>
        /// For stack unwinds that can span machine/register architectures (e.g.: CHPE), this allows specification of the "architecture" of both the frame of InstructionPointer and the frame of ReturnAddress.<para/>
        /// These fields are only valid if StackUnwindArchitectureSpecified is set. On input to -&gt;UnwindFrame(), StackUnwindArchitectureSpecified may be set with "FrameMachine" set to a specific architecture to indicate an "alternate input architecture" to the unwinder.<para/>
        /// In such cases, UnwoundMachine should be initialized to zero. On exit from unwind, if StackUnwindArchitectureSpecified is set, both fields must be valid.<para/>
        /// Normally, both of these will indicate the architecture of the machine. Indicates the architecture (IMAGE_FILE_MACHINE_*) of this frame.
        /// </summary>
        public IMAGE_FILE_MACHINE FrameMachine;

        public IMAGE_FILE_MACHINE UnwoundMachine;

        //v3 Fields
        public fixed long Parameters[4];
    }
}
