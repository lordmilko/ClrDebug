using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("53159B6D-D4C4-471B-A863-5B110CA800CA")]
    [ComImport]
    public interface IDataModelScriptDebugClient
    {
        [PreserveSig]
        HRESULT NotifyDebugEvent(
            [In] ref ScriptDebugEventInformation pEventInfo,
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScript pScript,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pEventDataObject,
            [In, Out] ref ScriptExecutionKind resumeEventKind);
    }
}
