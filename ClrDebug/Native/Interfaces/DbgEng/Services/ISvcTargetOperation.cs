using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface represents a handle to a.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("C06B2FD1-8D55-4705-8A68-1C32B2977E94")]
    [ComImport]
    public interface ISvcTargetOperation
    {
        /// <summary>
        /// Returns what kind of operation this is.
        /// </summary>
        [PreserveSig]
        TargetOperationKind GetKind();

        /// <summary>
        /// Returns what direction of operation this is.
        /// </summary>
        [PreserveSig]
        TargetOperationDirection GetDirection();

        /// <summary>
        /// Returns the status of the operation (e.g.: whether it is compelted, canceled, etc...).
        /// </summary>
        [PreserveSig]
        TargetOperationStatus GetStatus();

        /// <summary>
        /// If the operation can be canceled, it will be canceled. The semantic meaning of a cancellation depends on the operation in question.<para/>
        /// For instance For a halt : the target will no longer be halted For a breakpoint: the breakpoint will be cleared.
        /// </summary>
        [return: MarshalAs(UnmanagedType.U1)]
        bool Cancel();

        /// <summary>
        /// Waits for the status of the operation to change. This may indicate that the operation was canceled, completed, or was otherwise triggered.
        /// </summary>
        [PreserveSig]
        HRESULT WaitForChange(
            [Out] out TargetOperationStatus pOpStatus);

        /// <summary>
        /// Called to setup a callback on state change of the operation. If the operation has changed state to anything other than pending prior to the call, such notification will be made immediately.<para/>
        /// Note that more than one notification can be registered on any particular operation (though one is most typical).
        /// </summary>
        [PreserveSig]
        HRESULT NotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);

        /// <summary>
        /// Called to remove a notification callback as registered via NotifyOnChange.
        /// </summary>
        [PreserveSig]
        HRESULT RemoveNotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);
    }
}
