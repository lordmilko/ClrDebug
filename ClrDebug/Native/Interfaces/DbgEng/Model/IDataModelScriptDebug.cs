using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DE8E0945-9750-4471-AB76-A8F79D6EC350")]
    [ComImport]
    public interface IDataModelScriptDebug
    {
        [PreserveSig]
        ScriptDebugState GetDebugState();
        
        [PreserveSig]
        HRESULT GetCurrentPosition(
            [Out] out ScriptDebugPosition currentPosition,
            [Out] out ScriptDebugPosition positionSpanEnd,
            [Out, MarshalAs(UnmanagedType.BStr)] out string lineText);
        
        [PreserveSig]
        HRESULT GetStack(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugStack stack);
        
        [PreserveSig]
        HRESULT SetBreakpoint(
            [In] int linePosition,
            [In] int columnPosition,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);
        
        [PreserveSig]
        HRESULT FindBreakpointById(
            [In] long breakpointId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);
        
        [PreserveSig]
        HRESULT EnumerateBreakpoints(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpointEnumerator breakpointEnum);
        
        [PreserveSig]
        HRESULT GetEventFilter(
            [In] ScriptDebugEventFilter eventFilter,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isBreakEnabled);
        
        [PreserveSig]
        HRESULT SetEventFilter(
            [In] ScriptDebugEventFilter eventFilter,
            [In, MarshalAs(UnmanagedType.U1)] bool isBreakEnabled);
        
        [PreserveSig]
        HRESULT StartDebugging(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptDebugClient debugClient);
        
        [PreserveSig]
        HRESULT StopDebugging(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptDebugClient debugClient);
    }
}
