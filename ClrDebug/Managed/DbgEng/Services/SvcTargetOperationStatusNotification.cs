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
