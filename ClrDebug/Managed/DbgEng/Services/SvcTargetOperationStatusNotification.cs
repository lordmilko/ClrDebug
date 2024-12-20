namespace ClrDebug.DbgEng
{
    public class SvcTargetOperationStatusNotification : ComObject<ISvcTargetOperationStatusNotification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcTargetOperationStatusNotification"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcTargetOperationStatusNotification(ISvcTargetOperationStatusNotification raw) : base(raw)
        {
        }

        #region ISvcTargetOperationStatusNotification
        #region NotifyOperationChange

        /// <summary>
        /// Called by the step controller or step manager to notify a "client" that a requested operation has changed state (e.g.: completed or been canceled, etc...) The semantics of "pAffectedUnit" and "affectedAddress" depend on the type of operation.<para/>
        /// For a halt operation, this would be the "thread" or "core" that took the halt signal and the program counter at the point of the halt.
        /// </summary>
        public void NotifyOperationChange(ISvcTargetOperation pOperation, TargetOperationStatus opStatus, ISvcExecutionUnit pAffectedUnit, long affectedAddress)
        {
            /*void NotifyOperationChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperation pOperation,
            [In] TargetOperationStatus opStatus,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pAffectedUnit,
            [In] long affectedAddress);*/
            Raw.NotifyOperationChange(pOperation, opStatus, pAffectedUnit, affectedAddress);
        }

        #endregion
        #endregion
    }
}
