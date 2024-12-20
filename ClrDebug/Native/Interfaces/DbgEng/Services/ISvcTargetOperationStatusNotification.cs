using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F3F597C4-A43D-4057-A717-8E0F04E78820")]
    [ComImport]
    public interface ISvcTargetOperationStatusNotification
    {
        /// <summary>
        /// Called by the step controller or step manager to notify a "client" that a requested operation has changed state (e.g.: completed or been canceled, etc...) The semantics of "pAffectedUnit" and "affectedAddress" depend on the type of operation.<para/>
        /// For a halt operation, this would be the "thread" or "core" that took the halt signal and the program counter at the point of the halt.
        /// </summary>
        [PreserveSig]
        void NotifyOperationChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperation pOperation,
            [In] TargetOperationStatus opStatus,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pAffectedUnit,
            [In] long affectedAddress);
    }
}
