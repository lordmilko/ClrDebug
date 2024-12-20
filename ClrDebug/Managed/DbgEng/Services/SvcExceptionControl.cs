namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Notes If a target which supports live debugging issues a state change notification to the halted state for an "exception", that "exception" should support both ISvcExceptionInformation *AND* ISvcExceptionControl.<para/>
    /// This interface is only necessary for controlling exception flow within a live target.
    /// </summary>
    public class SvcExceptionControl : ComObject<ISvcExceptionControl>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcExceptionControl"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcExceptionControl(ISvcExceptionControl raw) : base(raw)
        {
        }

        #region ISvcExceptionControl
        #region IsFirstChance

        /// <summary>
        /// Indicates whether this exception is the first or second chance. If the target cannot make a determination of first/second chance, E_NOTIMPL should be returned.
        /// </summary>
        public bool IsFirstChance
        {
            get
            {
                bool isFirstChance;
                TryIsFirstChance(out isFirstChance).ThrowDbgEngNotOK();

                return isFirstChance;
            }
        }

        /// <summary>
        /// Indicates whether this exception is the first or second chance. If the target cannot make a determination of first/second chance, E_NOTIMPL should be returned.
        /// </summary>
        public HRESULT TryIsFirstChance(out bool isFirstChance)
        {
            /*HRESULT IsFirstChance(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isFirstChance);*/
            return Raw.IsFirstChance(out isFirstChance);
        }

        #endregion
        #region WillPassToTarget

        /// <summary>
        /// Indicates whether this exception will be passed onto the target or will be considered handled by the halt.
        /// </summary>
        public bool WillPassToTarget()
        {
            /*bool WillPassToTarget();*/
            return Raw.WillPassToTarget();
        }

        #endregion
        #region PassToTarget

        /// <summary>
        /// Indicates that this exception should be passed to the target. Flags are currently reserved and should be set to zero.<para/>
        /// If this exception is a form that CANNOT be passed to the target, E_ILLEGAL_METHOD_CALL should be returned. If the target is incapable of passing the exception on, E_NOTIMPL should be returned.<para/>
        /// NOTE: The exception is not *ACTUALLY* passed to the target until the target resumes execution via a call to the step controller.
        /// </summary>
        public void PassToTarget(int flags)
        {
            TryPassToTarget(flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Indicates that this exception should be passed to the target. Flags are currently reserved and should be set to zero.<para/>
        /// If this exception is a form that CANNOT be passed to the target, E_ILLEGAL_METHOD_CALL should be returned. If the target is incapable of passing the exception on, E_NOTIMPL should be returned.<para/>
        /// NOTE: The exception is not *ACTUALLY* passed to the target until the target resumes execution via a call to the step controller.
        /// </summary>
        public HRESULT TryPassToTarget(int flags)
        {
            /*HRESULT PassToTarget(
            [In] int flags);*/
            return Raw.PassToTarget(flags);
        }

        #endregion
        #region Handle

        /// <summary>
        /// Indicates that this exception should *NOT* be passed to the target and should be considered handled by the debugger.<para/>
        /// Flags are currently reserved and should be set to zero. If this exception is a form that CANNOT be passed to the target, E_ILLEGAL_METHOD_CALL should be returned.<para/>
        /// If the target is incapable of handling exceptions without passing them on, E_NOTIMPL should be returned. NOTE: The excepiton is not *ACTUALLY* handled and dismissed until the target resumes execution via a call to the step controller.
        /// </summary>
        public void Handle(int flags)
        {
            TryHandle(flags).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Indicates that this exception should *NOT* be passed to the target and should be considered handled by the debugger.<para/>
        /// Flags are currently reserved and should be set to zero. If this exception is a form that CANNOT be passed to the target, E_ILLEGAL_METHOD_CALL should be returned.<para/>
        /// If the target is incapable of handling exceptions without passing them on, E_NOTIMPL should be returned. NOTE: The excepiton is not *ACTUALLY* handled and dismissed until the target resumes execution via a call to the step controller.
        /// </summary>
        public HRESULT TryHandle(int flags)
        {
            /*HRESULT Handle(
            [In] int flags);*/
            return Raw.Handle(flags);
        }

        #endregion
        #endregion
    }
}
