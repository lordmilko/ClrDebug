namespace ClrDebug.DbgEng
{
    public class SvcStepController : ComObject<ISvcStepController>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStepController"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStepController(ISvcStepController raw) : base(raw)
        {
        }

        #region ISvcStepController
        #region Status

        public TargetStatus Status
        {
            get
            {
                /*TargetStatus GetStatus();*/
                return Raw.GetStatus();
            }
        }

        #endregion
        #region HaltReason

        public HaltReason HaltReason
        {
            get
            {
                /*HaltReason GetHaltReason();*/
                return Raw.GetHaltReason();
            }
        }

        #endregion
        #region NotifyOnChange

        public void NotifyOnChange(ISvcTargetStateChangeNotification pNotify)
        {
            TryNotifyOnChange(pNotify).ThrowDbgEngNotOK();
        }

        public HRESULT TryNotifyOnChange(ISvcTargetStateChangeNotification pNotify)
        {
            /*HRESULT NotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetStateChangeNotification pNotify);*/
            return Raw.NotifyOnChange(pNotify);
        }

        #endregion
        #region RemoveOnChange

        public void RemoveOnChange(ISvcTargetStateChangeNotification pNotify)
        {
            TryRemoveOnChange(pNotify).ThrowDbgEngNotOK();
        }

        public HRESULT TryRemoveOnChange(ISvcTargetStateChangeNotification pNotify)
        {
            /*HRESULT RemoveOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetStateChangeNotification pNotify);*/
            return Raw.RemoveOnChange(pNotify);
        }

        #endregion
        #region Run

        public SvcTargetOperation Run(TargetOperationDirection dir, ISvcTargetOperationStatusNotification pNotify)
        {
            SvcTargetOperation ppRunHandleResult;
            TryRun(dir, pNotify, out ppRunHandleResult).ThrowDbgEngNotOK();

            return ppRunHandleResult;
        }

        public HRESULT TryRun(TargetOperationDirection dir, ISvcTargetOperationStatusNotification pNotify, out SvcTargetOperation ppRunHandleResult)
        {
            /*HRESULT Run(
            [In] TargetOperationDirection dir,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppRunHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);*/
            ISvcTargetOperation ppRunHandle;
            HRESULT hr = Raw.Run(dir, out ppRunHandle, pNotify);

            if (hr == HRESULT.S_OK)
                ppRunHandleResult = ppRunHandle == null ? null : new SvcTargetOperation(ppRunHandle);
            else
                ppRunHandleResult = default(SvcTargetOperation);

            return hr;
        }

        #endregion
        #region Halt

        public SvcTargetOperation Halt(ISvcTargetOperationStatusNotification pNotify)
        {
            SvcTargetOperation ppHaltHandleResult;
            TryHalt(pNotify, out ppHaltHandleResult).ThrowDbgEngNotOK();

            return ppHaltHandleResult;
        }

        public HRESULT TryHalt(ISvcTargetOperationStatusNotification pNotify, out SvcTargetOperation ppHaltHandleResult)
        {
            /*HRESULT Halt(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppHaltHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);*/
            ISvcTargetOperation ppHaltHandle;
            HRESULT hr = Raw.Halt(out ppHaltHandle, pNotify);

            if (hr == HRESULT.S_OK)
                ppHaltHandleResult = ppHaltHandle == null ? null : new SvcTargetOperation(ppHaltHandle);
            else
                ppHaltHandleResult = default(SvcTargetOperation);

            return hr;
        }

        #endregion
        #region Step

        public SvcTargetOperation Step(ISvcExecutionUnit pStepUnit, TargetOperationDirection dir, long steps, ISvcTargetOperationStatusNotification pNotify)
        {
            SvcTargetOperation ppStepHandleResult;
            TryStep(pStepUnit, dir, steps, pNotify, out ppStepHandleResult).ThrowDbgEngNotOK();

            return ppStepHandleResult;
        }

        public HRESULT TryStep(ISvcExecutionUnit pStepUnit, TargetOperationDirection dir, long steps, ISvcTargetOperationStatusNotification pNotify, out SvcTargetOperation ppStepHandleResult)
        {
            /*HRESULT Step(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcExecutionUnit pStepUnit,
            [In] TargetOperationDirection dir,
            [In] long steps,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcTargetOperation ppStepHandle,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetOperationStatusNotification pNotify);*/
            ISvcTargetOperation ppStepHandle;
            HRESULT hr = Raw.Step(pStepUnit, dir, steps, out ppStepHandle, pNotify);

            if (hr == HRESULT.S_OK)
                ppStepHandleResult = ppStepHandle == null ? null : new SvcTargetOperation(ppStepHandle);
            else
                ppStepHandleResult = default(SvcTargetOperation);

            return hr;
        }

        #endregion
        #endregion
    }
}
