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

        public DataAccessFlags DataAccessFlags
        {
            get
            {
                DataAccessFlags pFlags;
                TryGetDataAccessFlags(out pFlags).ThrowDbgEngNotOK();

                return pFlags;
            }
        }

        public HRESULT TryGetDataAccessFlags(out DataAccessFlags pFlags)
        {
            /*HRESULT GetDataAccessFlags(
            [Out] out DataAccessFlags pFlags);*/
            return Raw.GetDataAccessFlags(out pFlags);
        }

        #endregion
        #region DataWidth

        public long DataWidth
        {
            get
            {
                long pWidth;
                TryGetDataWidth(out pWidth).ThrowDbgEngNotOK();

                return pWidth;
            }
        }

        public HRESULT TryGetDataWidth(out long pWidth)
        {
            /*HRESULT GetDataWidth(
            [Out] out long pWidth);*/
            return Raw.GetDataWidth(out pWidth);
        }

        #endregion
        #region Delete

        public void Delete()
        {
            TryDelete().ThrowDbgEngNotOK();
        }

        public HRESULT TryDelete()
        {
            /*HRESULT Delete();*/
            return Raw.Delete();
        }

        #endregion
        #region Disable

        public void Disable()
        {
            TryDisable().ThrowDbgEngNotOK();
        }

        public HRESULT TryDisable()
        {
            /*HRESULT Disable();*/
            return Raw.Disable();
        }

        #endregion
        #region Enable

        public void Enable()
        {
            TryEnable().ThrowDbgEngNotOK();
        }

        public HRESULT TryEnable()
        {
            /*HRESULT Enable();*/
            return Raw.Enable();
        }

        #endregion
        #endregion
    }
}
