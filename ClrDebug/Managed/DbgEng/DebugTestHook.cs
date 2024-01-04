namespace ClrDebug.DbgEng
{
    public class DebugTestHook : ComObject<IDebugTestHook>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugTestHook"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugTestHook(IDebugTestHook raw) : base(raw)
        {
        }

        #region IDebugTestHook
        #region SetValue

        public void SetValue(DEBUG_HOOK_INDEX index, long value)
        {
            TrySetValue(index, value).ThrowDbgEngNotOK();
        }

        public HRESULT TrySetValue(DEBUG_HOOK_INDEX index, long value)
        {
            /*HRESULT SetValue(
            [In] DEBUG_HOOK_INDEX index,
            [In] long value);*/
            return Raw.SetValue(index, value);
        }

        #endregion
        #endregion
    }
}
