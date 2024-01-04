using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("39484A75-B4F3-4799-86DA-691AFA57B299")]
    [ComImport]
    public interface IDataModelScriptDebugBreakpointEnumerator
    {
        [PreserveSig]
        HRESULT Reset();
        
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);
    }
}
