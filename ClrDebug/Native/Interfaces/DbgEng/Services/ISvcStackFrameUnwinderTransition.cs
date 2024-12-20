using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// If a given stack unwinder service implements this interface and is in an aggregate container, this interface will be asked if the stack unwinder wants to "take over" unwinding -- even if the currently delegated stack unwinder would continue.<para/>
    /// This allows a given unwind service to transition between two unwinders or stacks or otherwise inject stack frames for a variety of purposes.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2ED57D21-39C8-4D09-9751-8A80E15DECF4")]
    [ComImport]
    public interface ISvcStackFrameUnwinderTransition
    {
        /// <summary>
        /// Given the information that would normally be passed to UnwindFrame, this asks an alternate unwinder if it would like to "take over" unwinding at a particular point.<para/>
        /// The implementation can either leave the _Inout_ arguments alone and return UnwinderTransition none in the 'pTransitionKind' argument (indicating that no transition should occur) or it can adjust the _Inout_ arguments and indicate that it would like control of the unwind with specific behaviors as indicated by the 'pTransitionKind' argument.<para/>
        /// If multiple stack unwinders in an aggregate container indicate they want to take over unwinding, the request is passed to the highest priority unwinder.<para/>
        /// Such priority is given by linear insertion order into the container.
        /// </summary>
        [PreserveSig]
        HRESULT RequestsEntryTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterContext,
            [Out] out UnwinderTransitionKind pTransitionKind);

        /// <summary>
        /// Given the information that would normally be passed to UnwindFrame, this asks the current unwinder whether it would like to stop "taking over" unwinding at a particular point and give the unwinding to another unwinder.<para/>
        /// The unwinder should have previously taken over via RequestsEntryTransition. The behaviors of the transition kind are identical to RequestsEntryTransition with the exception that the yes/no is opposite (UnwinderTransitionNone indicates continuation of use; others requests that the aggregate unwinder stop using the called unwinder).
        /// </summary>
        [PreserveSig]
        HRESULT RequestsExitTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterCotnext,
            [Out] out UnwinderTransitionKind pTransitionKind);

        /// <summary>
        /// Given the information that would normally be passed to UnwindFrame after the *CURRENT* unwinder has reached the end of the stack, this asks an alternate unwinder if it would like to "take over" unwinding at this particular point.<para/>
        /// If the callee returns UnwinderTransitionAddFrame, the adjusted stack frame and context record are presented as a new stack frame *BEFORE* unwinding.<para/>
        /// If the callee returns UnwinderTransitionUnwindFrame, the returned register context is unwound as the next entry in the stack.<para/>
        /// If multiple stack unwinders in an aggregate container indicate that they want a terminal transition, the request is passed to the unwinder which returns a register context that has a stack pointer closest to the stack pointer of the unwinder which terminated.
        /// </summary>
        [PreserveSig]
        HRESULT RequestsTerminalTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterContext,
            [Out] out UnwinderTransitionKind pTransitionKind);
    }
}
