using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5CA0337C-80AD-471D-9B4F-37803E4087CC")]
    [ComImport]
    public interface ISvcStepController
    {
        [PreserveSig]
        HRESULT NotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetStateChangeNotification pNotify);
        
        [PreserveSig]
        HRESULT RemoveOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetStateChangeNotification pNotify);
        
        [PreserveSig]
        TargetStatus GetStatus();
        
        [PreserveSig]
        HaltReason GetHaltReason();
        
        [PreserveSig]
        HRESULT Run(
            [In] TargetOperationDirection dir,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppRunHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);
        
        [PreserveSig]
        HRESULT Halt(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppHaltHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);
        
        [PreserveSig]
        HRESULT Step(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pStepUnit,
            [In] TargetOperationDirection dir,
            [In] long steps,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppStepHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);
    }
}
