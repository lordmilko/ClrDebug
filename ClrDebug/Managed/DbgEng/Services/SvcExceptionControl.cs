namespace ClrDebug.DbgEng
{
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

        public bool IsFirstChance
        {
            get
            {
                bool isFirstChance;
                TryIsFirstChance(out isFirstChance).ThrowDbgEngNotOK();

                return isFirstChance;
            }
        }

        public HRESULT TryIsFirstChance(out bool isFirstChance)
        {
            /*HRESULT IsFirstChance(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isFirstChance);*/
            return Raw.IsFirstChance(out isFirstChance);
        }

        #endregion
        #region WillPassToTarget

        public bool WillPassToTarget()
        {
            /*bool WillPassToTarget();*/
            return Raw.WillPassToTarget();
        }

        #endregion
        #region PassToTarget

        public void PassToTarget(int flags)
        {
            TryPassToTarget(flags).ThrowDbgEngNotOK();
        }

        public HRESULT TryPassToTarget(int flags)
        {
            /*HRESULT PassToTarget(
            [In] int flags);*/
            return Raw.PassToTarget(flags);
        }

        #endregion
        #region Handle

        public void Handle(int flags)
        {
            TryHandle(flags).ThrowDbgEngNotOK();
        }

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
