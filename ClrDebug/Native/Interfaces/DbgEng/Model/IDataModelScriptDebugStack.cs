using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("051364DD-E449-443E-9762-FE578F4A5473")]
    [ComImport]
    public interface IDataModelScriptDebugStack
    {
        [PreserveSig]
        long GetFrameCount();
        
        [PreserveSig]
        HRESULT GetStackFrame(
            [In] long frameNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugStackFrame stackFrame);
    }
}
