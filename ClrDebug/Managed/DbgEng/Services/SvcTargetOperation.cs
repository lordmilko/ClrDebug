namespace ClrDebug.DbgEng
{
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

        public bool Cancel()
        {
            /*bool Cancel();*/
            return Raw.Cancel();
        }

        #endregion
        #region WaitForChange

        public TargetOperationStatus WaitForChange()
        {
            TargetOperationStatus pOpStatus;
            TryWaitForChange(out pOpStatus).ThrowDbgEngNotOK();

            return pOpStatus;
        }

        public HRESULT TryWaitForChange(out TargetOperationStatus pOpStatus)
        {
            /*HRESULT WaitForChange(
            [Out] out TargetOperationStatus pOpStatus);*/
            return Raw.WaitForChange(out pOpStatus);
        }

        #endregion
        #region NotifyOnChange

        public void NotifyOnChange(ISvcTargetOperationStatusNotification pNotify)
        {
            TryNotifyOnChange(pNotify).ThrowDbgEngNotOK();
        }

        public HRESULT TryNotifyOnChange(ISvcTargetOperationStatusNotification pNotify)
        {
            /*HRESULT NotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);*/
            return Raw.NotifyOnChange(pNotify);
        }

        #endregion
        #region RemoveNotifyOnChange

        public void RemoveNotifyOnChange(ISvcTargetOperationStatusNotification pNotify)
        {
            TryRemoveNotifyOnChange(pNotify).ThrowDbgEngNotOK();
        }

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
