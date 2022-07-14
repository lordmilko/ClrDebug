﻿using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_STACK_FRAME structure describes a stack frame and the address of the current instruction for the stack frame.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct DEBUG_STACK_FRAME
    {
        /// <summary>
        /// The location in the process's virtual address space of the related instruction for the stack frame. This is typically the return address for the next stack frame, or the current instruction pointer if the frame is at the top of the stack.
        /// </summary>
        public ulong InstructionOffset;

        /// <summary>
        /// The location in the process's virtual address space of the return address for the stack frame. This is typically the related instruction for the previous stack frame.
        /// </summary>
        public ulong ReturnOffset;

        /// <summary>
        /// The location in the process's virtual address space of the stack frame, if known. Some processor architectures do not have a frame or have more than one.<para/>
        /// In these cases, the engine chooses a value most representative for the given level of the stack.
        /// </summary>
        public ulong FrameOffset;

        /// <summary>
        /// The location in the process's virtual address space of the processor stack.
        /// </summary>
        public ulong StackOffset;

        /// <summary>
        /// The location in the target's virtual address space of the function entry for this frame, if available. When set, this pointer is not guaranteed to remain valid indefinitely and should not be held for future use.<para/>
        /// Instead, save the value of InstructionOffset and use it with <see cref="IDebugSymbols3.GetFunctionEntryByOffset"/> to retrieve function entry information later.
        /// </summary>
        public ulong FuncTableEntry;

        /// <summary>
        /// The values of the first four stack slots that are passed to the function, if available. If there are less than four arguments, the remaining entries are set to zero.<para/>
        /// These stack slots are not guaranteed to contain parameter values. Some calling conventions and compiler optimizations might interfere with identification of parameter information.<para/>
        /// For more detailed argument information and proper location handling, use <see cref="IDebugSymbols.GetScopeSymbolGroup"/> to retrieve the actual parameter symbols.
        /// </summary>
        public fixed ulong Params[4];

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public fixed ulong Reserved[6];

        /// <summary>
        /// The value is set to TRUE if this stack frame was generated by the debugger by unwinding. Otherwise, the value is FALSE if it was formed from a thread's current context.<para/>
        /// Typically, this is TRUE for the frame at the top of the stack, where InstructionOffset is the current instruction pointer.
        /// </summary>
        public uint Virtual;

        /// <summary>
        /// The index of the frame. This index counts the number of frames from the top of the call stack. The frame at the top of the stack, representing the current call, has index zero.
        /// </summary>
        public uint FrameNumber;
    }
}