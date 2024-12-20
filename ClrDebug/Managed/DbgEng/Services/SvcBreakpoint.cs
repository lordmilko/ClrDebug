namespace ClrDebug.DbgEng
{
    public class SvcBreakpoint : ComObject<ISvcBreakpoint>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcBreakpoint"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcBreakpoint(ISvcBreakpoint raw) : base(raw)
        {
        }

        #region ISvcBreakpoint
        #region Kind

        /// <summary>
        /// Gets the kind of breakpoint that this ISvcBreakpoint represents.
        /// </summary>
        public BreakpointKind Kind
        {
            get
            {
                /*BreakpointKind GetKind();*/
                return Raw.GetKind();
            }
        }

        #endregion
        #region ProcessKey

        /// <summary>
        /// Gets the process key which this breakpoint is set within.
        /// </summary>
        public long ProcessKey
        {
            get
            {
                /*long GetProcessKey();*/
                return Raw.GetProcessKey();
            }
        }

        #endregion
        #region Address

        /// <summary>
        /// Gets the address for this breakpoint.
        /// </summary>
        public long Address
        {
            get
            {
                /*long GetAddress();*/
                return Raw.GetAddress();
            }
        }

        #endregion
        #region DataAccessFlags

        /// <summary>
        /// Gets the data access flags for this breakpoint. This method will fail when called on a breakpoint which is not a data breakpoint.
        /// </summary>
        public DataAccessFlags DataAccessFlags
        {
            get
            {
                DataAccessFlags pFlags;
                TryGetDataAccessFlags(out pFlags).ThrowDbgEngNotOK();

                return pFlags;
            }
        }

        /// <summary>
        /// Gets the data access flags for this breakpoint. This method will fail when called on a breakpoint which is not a data breakpoint.
        /// </summary>
        public HRESULT TryGetDataAccessFlags(out DataAccessFlags pFlags)
        {
            /*HRESULT GetDataAccessFlags(
            [Out] out DataAccessFlags pFlags);*/
            return Raw.GetDataAccessFlags(out pFlags);
        }

        #endregion
        #region DataWidth

        /// <summary>
        /// Gets the data access width for this breakpoint. This method will fail when called on a breakpoint which is not a data brakpoint.
        /// </summary>
        public long DataWidth
        {
            get
            {
                long pWidth;
                TryGetDataWidth(out pWidth).ThrowDbgEngNotOK();

                return pWidth;
            }
        }

        /// <summary>
        /// Gets the data access width for this breakpoint. This method will fail when called on a breakpoint which is not a data brakpoint.
        /// </summary>
        public HRESULT TryGetDataWidth(out long pWidth)
        {
            /*HRESULT GetDataWidth(
            [Out] out long pWidth);*/
            return Raw.GetDataWidth(out pWidth);
        }

        #endregion
        #region Delete

        /// <summary>
        /// Deletes the breakpoint.
        /// </summary>
        public void Delete()
        {
            TryDelete().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Deletes the breakpoint.
        /// </summary>
        public HRESULT TryDelete()
        {
            /*HRESULT Delete();*/
            return Raw.Delete();
        }

        #endregion
        #region Disable

        /// <summary>
        /// Disables the breakpoint. Disable is an on/off operation. You cannot disable a disabled breakpoint. Calling Disable on a disabled breakpoint will return S_FALSE as an indication that the breakpoint is disabled BUT that the Disable call was not the actor which performed the operation.
        /// </summary>
        public void Disable()
        {
            TryDisable().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Disables the breakpoint. Disable is an on/off operation. You cannot disable a disabled breakpoint. Calling Disable on a disabled breakpoint will return S_FALSE as an indication that the breakpoint is disabled BUT that the Disable call was not the actor which performed the operation.
        /// </summary>
        public HRESULT TryDisable()
        {
            /*HRESULT Disable();*/
            return Raw.Disable();
        }

        #endregion
        #region Enable

        /// <summary>
        /// Enables the breakpoint. Enable is an on/off operation. You cannot enable an enabled breakpoint. Calling Enable on an enabled breakpoint will return S_FALSE as an indication that the breakpoint is enabled BUT that the Enable call was not the actor which performed the operation.
        /// </summary>
        public void Enable()
        {
            TryEnable().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Enables the breakpoint. Enable is an on/off operation. You cannot enable an enabled breakpoint. Calling Enable on an enabled breakpoint will return S_FALSE as an indication that the breakpoint is enabled BUT that the Enable call was not the actor which performed the operation.
        /// </summary>
        public HRESULT TryEnable()
        {
            /*HRESULT Enable();*/
            return Raw.Enable();
        }

        #endregion
        #endregion
    }
}
