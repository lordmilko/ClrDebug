namespace ClrDebug.DbgEng
{
    public class DebugHostContextAlternator : ComObject<IDebugHostContextAlternator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostContextAlternator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostContextAlternator(IDebugHostContextAlternator raw) : base(raw)
        {
        }

        #region IDebugHostContextAlternator
        #region SwitchTo

        public void SwitchTo(bool fullSwitch)
        {
            TrySwitchTo(fullSwitch).ThrowDbgEngNotOK();
        }

        public HRESULT TrySwitchTo(bool fullSwitch)
        {
            /*HRESULT SwitchTo(
            [In, MarshalAs(UnmanagedType.U1)] bool fullSwitch);*/
            return Raw.SwitchTo(fullSwitch);
        }

        #endregion
        #region SwitchBack

        public void SwitchBack()
        {
            TrySwitchBack().ThrowDbgEngNotOK();
        }

        public HRESULT TrySwitchBack()
        {
            /*HRESULT SwitchBack();*/
            return Raw.SwitchBack();
        }

        #endregion
        #endregion
    }
}
