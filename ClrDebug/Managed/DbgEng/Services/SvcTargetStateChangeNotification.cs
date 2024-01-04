namespace ClrDebug.DbgEng
{
    public class SvcTargetStateChangeNotification : ComObject<ISvcTargetStateChangeNotification>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcTargetStateChangeNotification"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcTargetStateChangeNotification(ISvcTargetStateChangeNotification raw) : base(raw)
        {
        }

        #region ISvcTargetStateChangeNotification
        #region NotifyStateChange

        public void NotifyStateChange(TargetStatus currentStatus, HaltReason haltReason, ISvcTargetOperation pOperation, ISvcExecutionUnit pAffectedUnit, long affectedAddress, object pArgs)
        {
            /*void NotifyStateChange(
            [In] TargetStatus currentStatus,
            [In] HaltReason haltReason,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperation pOperation,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pAffectedUnit,
            [In] long affectedAddress,
            [In, MarshalAs(UnmanagedType.Interface)] object pArgs);*/
            Raw.NotifyStateChange(currentStatus, haltReason, pOperation, pAffectedUnit, affectedAddress, pArgs);
        }

        #endregion
        #endregion
    }
}
