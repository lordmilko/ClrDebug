using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("5CA0337C-80AD-471D-9B4F-37803E4087CC")]
    [ComImport]
    public interface ISvcStepController
    {
        /// <summary>
        /// Called to setup a callback on state change of the step controller more generally. Such a state change may or may not be the result of an operation.<para/>
        /// Note that more than one notification can be registered (though one is most typical).
        /// </summary>
        [PreserveSig]
        HRESULT NotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetStateChangeNotification pNotify);

        /// <summary>
        /// RemoveNotifyOnChange() Called to remove a notification callback as registered via NotifyOnChange.
        /// </summary>
        [PreserveSig]
        HRESULT RemoveOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetStateChangeNotification pNotify);

        /// <summary>
        /// Gets the current status of the target.
        /// </summary>
        [PreserveSig]
        TargetStatus GetStatus();

        /// <summary>
        /// Gets the reason why the target is halted. This call may only legally be made while GetStatus() returns that the target is halted.<para/>
        /// Calling otherwise will always return HaltUnknown.
        /// </summary>
        [PreserveSig]
        HaltReason GetHaltReason();

        /// <summary>
        /// Causes the underlying target to resume execution. A handle to the run operation is returned. If the requested operation cannot be performed (e.g.: a requested "Run backward" call is made on a target which can only "Run forward"), the implementation may legally return E_NOTIMPL.<para/>
        /// A run operation is considered completed when the underlying target has *STARTED* running. This call may only be made when the target is in a halted status.<para/>
        /// Calling in other circumstnaces will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
        [PreserveSig]
        HRESULT Run(
            [In] TargetOperationDirection dir,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppRunHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);

        /// <summary>
        /// Causes the underlying target to halt execution (break in). A handle to the halt operation is returned. A halt operation is considered completed when the underlying target has completely halted.<para/>
        /// This call may only be made when the target is in a running status. Calling in other circumstances will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
        [PreserveSig]
        HRESULT Halt(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppHaltHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);

        /// <summary>
        /// Causes the underlying target to step a particular execution unit by 'steps' fundamental units (e.g.: instructions).<para/>
        /// If the requested operation cannot be performed (e.g.: a requeted "Step backward" call is made on a target which can only "Step forward"), the implementation may legally return E_NOTIMPL.<para/>
        /// A step operation is considered completed when the step has completed and the target has successfully halted. This call may only be made when the target is in a halted status.<para/>
        /// Calling in other circumstances will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
        [PreserveSig]
        HRESULT Step(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pStepUnit,
            [In] TargetOperationDirection dir,
            [In] long steps,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppStepHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);
    }
}
