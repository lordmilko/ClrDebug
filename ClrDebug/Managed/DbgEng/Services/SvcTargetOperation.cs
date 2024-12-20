namespace ClrDebug.DbgEng
{
    /// <summary>
    /// This interface represents a handle to a.
    /// </summary>
    public class SvcTargetOperation : ComObject<ISvcTargetOperation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcTargetOperation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcTargetOperation(ISvcTargetOperation raw) : base(raw)
        {
        }

        #region ISvcTargetOperation
        #region Kind

        /// <summary>
        /// Returns what kind of operation this is.
        /// </summary>
        public TargetOperationKind Kind
        {
            get
            {
                /*TargetOperationKind GetKind();*/
                return Raw.GetKind();
            }
        }

        #endregion
        #region Direction

        /// <summary>
        /// Returns what direction of operation this is.
        /// </summary>
        public TargetOperationDirection Direction
        {
            get
            {
                /*TargetOperationDirection GetDirection();*/
                return Raw.GetDirection();
            }
        }

        #endregion
        #region Status

        /// <summary>
        /// Returns the status of the operation (e.g.: whether it is compelted, canceled, etc...).
        /// </summary>
        public TargetOperationStatus Status
        {
            get
            {
                /*TargetOperationStatus GetStatus();*/
                return Raw.GetStatus();
            }
        }

        #endregion
        #region Cancel

        /// <summary>
        /// If the operation can be canceled, it will be canceled. The semantic meaning of a cancellation depends on the operation in question.<para/>
        /// For instance For a halt : the target will no longer be halted For a breakpoint: the breakpoint will be cleared.
        /// </summary>
        public bool Cancel()
        {
            /*bool Cancel();*/
            return Raw.Cancel();
        }

        #endregion
        #region WaitForChange

        /// <summary>
        /// Waits for the status of the operation to change. This may indicate that the operation was canceled, completed, or was otherwise triggered.
        /// </summary>
        public TargetOperationStatus WaitForChange()
        {
            TargetOperationStatus pOpStatus;
            TryWaitForChange(out pOpStatus).ThrowDbgEngNotOK();

            return pOpStatus;
        }

        /// <summary>
        /// Waits for the status of the operation to change. This may indicate that the operation was canceled, completed, or was otherwise triggered.
        /// </summary>
        public HRESULT TryWaitForChange(out TargetOperationStatus pOpStatus)
        {
            /*HRESULT WaitForChange(
            [Out] out TargetOperationStatus pOpStatus);*/
            return Raw.WaitForChange(out pOpStatus);
        }

        #endregion
        #region NotifyOnChange

        /// <summary>
        /// Called to setup a callback on state change of the operation. If the operation has changed state to anything other than pending prior to the call, such notification will be made immediately.<para/>
        /// Note that more than one notification can be registered on any particular operation (though one is most typical).
        /// </summary>
        public void NotifyOnChange(ISvcTargetOperationStatusNotification pNotify)
        {
            TryNotifyOnChange(pNotify).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Called to setup a callback on state change of the operation. If the operation has changed state to anything other than pending prior to the call, such notification will be made immediately.<para/>
        /// Note that more than one notification can be registered on any particular operation (though one is most typical).
        /// </summary>
        public HRESULT TryNotifyOnChange(ISvcTargetOperationStatusNotification pNotify)
        {
            /*HRESULT NotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);*/
            return Raw.NotifyOnChange(pNotify);
        }

        #endregion
        #region RemoveNotifyOnChange

        /// <summary>
        /// Called to remove a notification callback as registered via NotifyOnChange.
        /// </summary>
        public void RemoveNotifyOnChange(ISvcTargetOperationStatusNotification pNotify)
        {
            TryRemoveNotifyOnChange(pNotify).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Called to remove a notification callback as registered via NotifyOnChange.
        /// </summary>
        public HRESULT TryRemoveNotifyOnChange(ISvcTargetOperationStatusNotification pNotify)
        {
            /*HRESULT RemoveNotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);*/
            return Raw.RemoveNotifyOnChange(pNotify);
        }

        #endregion
        #endregion
    }
}
