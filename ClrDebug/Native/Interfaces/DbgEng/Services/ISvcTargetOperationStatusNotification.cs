using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F3F597C4-A43D-4057-A717-8E0F04E78820")]
    [ComImport]
    public interface ISvcTargetOperationStatusNotification
    {
        [PreserveSig]
        void NotifyOperationChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperation pOperation,
            [In] TargetOperationStatus opStatus,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pAffectedUnit,
            [In] long affectedAddress);
    }
}
