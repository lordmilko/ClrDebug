using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("44CFC4B1-02B5-490A-A51A-AD34E49457F4")]
    [ComImport]
    public interface ISvcStackFrameUnwind
    {
        /// <summary>
        /// Unwinds the stack frame given the architecture specific register context. A stack unwind context must have been created and initialized prior to calling this method.<para/>
        /// It is important to note that ownership of the input context is semantically being given to UnwindFrame. The operation may either modify the input register context and simply return the modified register context as the output context or it may create a new register context as the output context.<para/>
        /// Either is a valid implementation. If the architecture of the unwound frame changes for any reason (e.g.: CHPE/ARM64X), the output register context is guaranteed to be a new register context with the registers of the new architecture.<para/>
        /// A setup for calling this method for stack unwind includes - Setting stackFrame.SizeOfStruct to sizeof(SVC_STACK_FRAME) - Setting stackFrame.Flags to 0 - Getting the actual register context of the thread/stack to unwind - Calling UnwindFrame() After a call to UnwindFrame - The instruction pointer / stack pointer / frame pointer are copied out of the architecture specific register context into SVC_STACK_FRAME in an architecture neutral manner.<para/>
        /// - The return address for the unwound frame is placed into SVC_STACK_FRAME. If it cannot be determined, zero is placed in said value and the StackUnwindUnknownReturn flag is set.<para/>
        /// - The values in the architecture specific register context are those of the unwound frame (including the instruction pointer / stack pointer / frame pointer) The return value from UnwindFrame has significance - E_BOUNDS: The end of stack unwind has been reached - S_OK : Everything successfully unwound -- the register context is full - S_FALSE : The frame successfully unwound -- not all register context successfully unwound - E_* : Another error occurred that prevented stack unwind.
        /// </summary>
        [PreserveSig]
        HRESULT UnwindFrame(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext pInRegisterContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppOutRegisterContext);
    }
}
