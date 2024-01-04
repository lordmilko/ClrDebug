using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C06B2FD1-8D55-4705-8A68-1C32B2977E94")]
    [ComImport]
    public interface ISvcTargetOperation
    {
        [PreserveSig]
        TargetOperationKind GetKind();
        
        [PreserveSig]
        TargetOperationDirection GetDirection();
        
        [PreserveSig]
        TargetOperationStatus GetStatus();
        
        [return: MarshalAs(UnmanagedType.U1)]
        bool Cancel();
        
        [PreserveSig]
        HRESULT WaitForChange(
            [Out] out TargetOperationStatus pOpStatus);
        
        [PreserveSig]
        HRESULT NotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);
        
        [PreserveSig]
        HRESULT RemoveNotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);
    }
}
