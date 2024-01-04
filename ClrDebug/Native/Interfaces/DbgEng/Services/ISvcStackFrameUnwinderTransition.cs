using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("2ED57D21-39C8-4D09-9751-8A80E15DECF4")]
    [ComImport]
    public interface ISvcStackFrameUnwinderTransition
    {
        [PreserveSig]
        HRESULT RequestsEntryTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterContext,
            [Out] out UnwinderTransitionKind pTransitionKind);
        
        [PreserveSig]
        HRESULT RequestsExitTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterCotnext,
            [Out] out UnwinderTransitionKind pTransitionKind);
        
        [PreserveSig]
        HRESULT RequestsTerminalTransition(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackUnwindContext pUnwindContext,
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [In, Out, MarshalAs(UnmanagedType.Interface)] ref ISvcRegisterContext pRegisterContext,
            [Out] out UnwinderTransitionKind pTransitionKind);
    }
}
