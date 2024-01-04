using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CBB10ED3-839E-426C-9243-E23535C1AE1A")]
    [ComImport]
    public interface IDataModelScriptDebug2 : IDataModelScriptDebug
    {
        [PreserveSig]
        new ScriptDebugState GetDebugState();
        
        [PreserveSig]
        new HRESULT GetCurrentPosition(
            [Out] out ScriptDebugPosition currentPosition,
            [Out] out ScriptDebugPosition positionSpanEnd,
            [Out, MarshalAs(UnmanagedType.BStr)] out string lineText);
        
        [PreserveSig]
        new HRESULT GetStack(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugStack stack);
        
        [PreserveSig]
        new HRESULT SetBreakpoint(
            [In] int linePosition,
            [In] int columnPosition,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);
        
        [PreserveSig]
        new HRESULT FindBreakpointById(
            [In] long breakpointId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);
        
        [PreserveSig]
        new HRESULT EnumerateBreakpoints(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpointEnumerator breakpointEnum);
        
        [PreserveSig]
        new HRESULT GetEventFilter(
            [In] ScriptDebugEventFilter eventFilter,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isBreakEnabled);
        
        [PreserveSig]
        new HRESULT SetEventFilter(
            [In] ScriptDebugEventFilter eventFilter,
            [In, MarshalAs(UnmanagedType.U1)] bool isBreakEnabled);
        
        [PreserveSig]
        new HRESULT StartDebugging(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptDebugClient debugClient);
        
        [PreserveSig]
        new HRESULT StopDebugging(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptDebugClient debugClient);
        
        [PreserveSig]
        HRESULT SetBreakpointAtFunction(
            [In, MarshalAs(UnmanagedType.LPWStr)] string functionName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);
    }
}
