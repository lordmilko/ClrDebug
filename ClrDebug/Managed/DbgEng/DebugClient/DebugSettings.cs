namespace ClrDebug.DbgEng
{
    public class DebugSettings : ComObject<IDebugSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugSettings"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugSettings(IDebugSettings raw) : base(raw)
        {
        }

        #region IDebugSettings
        #region LoadSettingsFromString

        public void LoadSettingsFromString(string contents)
        {
            TryLoadSettingsFromString(contents).ThrowDbgEngNotOK();
        }

        public HRESULT TryLoadSettingsFromString(string contents)
        {
            /*HRESULT LoadSettingsFromString(
            [MarshalAs(UnmanagedType.LPWStr), In] string contents);*/
            return Raw.LoadSettingsFromString(contents);
        }

        #endregion
        #region StoreSettingsInStream

        public void StoreSettingsInStream(IDebugOutputStream output)
        {
            TryStoreSettingsInStream(output).ThrowDbgEngNotOK();
        }

        public HRESULT TryStoreSettingsInStream(IDebugOutputStream output)
        {
            /*HRESULT StoreSettingsInStream(
            [MarshalAs(UnmanagedType.Interface), In] IDebugOutputStream output);*/
            return Raw.StoreSettingsInStream(output);
        }

        #endregion
        #endregion
    }
}
