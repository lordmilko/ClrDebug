using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DF1323B9-3586-499F-94E2-F1AAA80EBBCD")]
    [ComImport]
    public interface ISvcTargetStateChangeNotification
    {
        [PreserveSig]
        void NotifyStateChange(
            [In] TargetStatus currentStatus,
            [In] HaltReason haltReason,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperation pOperation,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pAffectedUnit,
            [In] long affectedAddress,
            [In, MarshalAs(UnmanagedType.Interface)] object pArgs);
    }
}
