﻿using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DF1323B9-3586-499F-94E2-F1AAA80EBBCD")]
    [ComImport]
    public interface ISvcTargetStateChangeNotification
    {
        /// <summary>
        /// Called by the step controller or step manager to notify a "client" that a state change has occurred. This may or may not be the result of a particular operation.<para/>
        /// If the halt is associated with a particular operation, the operation is passed here. *NOTE*: If a state change is associated with an operation and callbacks are registered for both, the step controller/manager's general state change notification *MUST* happen *BEFORE* the operation's notification.<para/>
        /// pArgs is defined as follows (currentStatus / haltReason) - TargetHalted / HaltBreakpoint: The ISvcBreakpoint which was hit - Otherwise: Undefined.
        /// </summary>
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
