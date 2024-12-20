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

        /// <summary>
        /// Gets the current status of the target.
        /// </summary>
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

        /// <summary>
        /// Gets the reason why the target is halted. This call may only legally be made while GetStatus() returns that the target is halted.<para/>
        /// Calling otherwise will always return HaltUnknown.
        /// </summary>
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

        /// <summary>
        /// Called to setup a callback on state change of the step controller more generally. Such a state change may or may not be the result of an operation.<para/>
        /// Note that more than one notification can be registered (though one is most typical).
        /// </summary>
        public void NotifyOnChange(ISvcTargetStateChangeNotification pNotify)
        {
            TryNotifyOnChange(pNotify).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Called to setup a callback on state change of the step controller more generally. Such a state change may or may not be the result of an operation.<para/>
        /// Note that more than one notification can be registered (though one is most typical).
        /// </summary>
        public HRESULT TryNotifyOnChange(ISvcTargetStateChangeNotification pNotify)
        {
            /*HRESULT NotifyOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetStateChangeNotification pNotify);*/
            return Raw.NotifyOnChange(pNotify);
        }

        #endregion
        #region RemoveOnChange

        /// <summary>
        /// RemoveNotifyOnChange() Called to remove a notification callback as registered via NotifyOnChange.
        /// </summary>
        public void RemoveOnChange(ISvcTargetStateChangeNotification pNotify)
        {
            TryRemoveOnChange(pNotify).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// RemoveNotifyOnChange() Called to remove a notification callback as registered via NotifyOnChange.
        /// </summary>
        public HRESULT TryRemoveOnChange(ISvcTargetStateChangeNotification pNotify)
        {
            /*HRESULT RemoveOnChange(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcTargetStateChangeNotification pNotify);*/
            return Raw.RemoveOnChange(pNotify);
        }

        #endregion
        #region Run

        /// <summary>
        /// Causes the underlying target to resume execution. A handle to the run operation is returned. If the requested operation cannot be performed (e.g.: a requested "Run backward" call is made on a target which can only "Run forward"), the implementation may legally return E_NOTIMPL.<para/>
        /// A run operation is considered completed when the underlying target has *STARTED* running. This call may only be made when the target is in a halted status.<para/>
        /// Calling in other circumstnaces will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
        public SvcTargetOperation Run(TargetOperationDirection dir, ISvcTargetOperationStatusNotification pNotify)
        {
            SvcTargetOperation ppRunHandleResult;
            TryRun(dir, pNotify, out ppRunHandleResult).ThrowDbgEngNotOK();

            return ppRunHandleResult;
        }

        /// <summary>
        /// Causes the underlying target to resume execution. A handle to the run operation is returned. If the requested operation cannot be performed (e.g.: a requested "Run backward" call is made on a target which can only "Run forward"), the implementation may legally return E_NOTIMPL.<para/>
        /// A run operation is considered completed when the underlying target has *STARTED* running. This call may only be made when the target is in a halted status.<para/>
        /// Calling in other circumstnaces will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
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

        /// <summary>
        /// Causes the underlying target to halt execution (break in). A handle to the halt operation is returned. A halt operation is considered completed when the underlying target has completely halted.<para/>
        /// This call may only be made when the target is in a running status. Calling in other circumstances will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
        public SvcTargetOperation Halt(ISvcTargetOperationStatusNotification pNotify)
        {
            SvcTargetOperation ppHaltHandleResult;
            TryHalt(pNotify, out ppHaltHandleResult).ThrowDbgEngNotOK();

            return ppHaltHandleResult;
        }

        /// <summary>
        /// Causes the underlying target to halt execution (break in). A handle to the halt operation is returned. A halt operation is considered completed when the underlying target has completely halted.<para/>
        /// This call may only be made when the target is in a running status. Calling in other circumstances will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
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

        /// <summary>
        /// Causes the underlying target to step a particular execution unit by 'steps' fundamental units (e.g.: instructions).<para/>
        /// If the requested operation cannot be performed (e.g.: a requeted "Step backward" call is made on a target which can only "Step forward"), the implementation may legally return E_NOTIMPL.<para/>
        /// A step operation is considered completed when the step has completed and the target has successfully halted. This call may only be made when the target is in a halted status.<para/>
        /// Calling in other circumstances will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
        public SvcTargetOperation Step(ISvcExecutionUnit pStepUnit, TargetOperationDirection dir, long steps, ISvcTargetOperationStatusNotification pNotify)
        {
            SvcTargetOperation ppStepHandleResult;
            TryStep(pStepUnit, dir, steps, pNotify, out ppStepHandleResult).ThrowDbgEngNotOK();

            return ppStepHandleResult;
        }

        /// <summary>
        /// Causes the underlying target to step a particular execution unit by 'steps' fundamental units (e.g.: instructions).<para/>
        /// If the requested operation cannot be performed (e.g.: a requeted "Step backward" call is made on a target which can only "Step forward"), the implementation may legally return E_NOTIMPL.<para/>
        /// A step operation is considered completed when the step has completed and the target has successfully halted. This call may only be made when the target is in a halted status.<para/>
        /// Calling in other circumstances will result in E_ILLEGAL_METHOD_CALL.
        /// </summary>
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
