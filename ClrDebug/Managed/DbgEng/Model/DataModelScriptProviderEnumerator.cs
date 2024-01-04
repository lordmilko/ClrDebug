namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator which returns a set of known script providers.
    /// </summary>
    public class DataModelScriptProviderEnumerator : ComObject<IDataModelScriptProviderEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptProviderEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptProviderEnumerator(IDataModelScriptProviderEnumerator raw) : base(raw)
        {
        }

        #region IDataModelScriptProviderEnumerator
        #region Next

        /// <summary>
        /// The GetNext method will move the enumerator forward one element and return the script provider which is at that element.<para/>
        /// When the enumerator hits the end of enumeration, E_BOUNDS will be returned. Calling the GetNext method after receiving this error will continue to return E_BOUNDS indefinitely.
        /// </summary>
        public DataModelScriptProvider Next
        {
            get
            {
                DataModelScriptProvider providerResult;
                TryGetNext(out providerResult).ThrowDbgEngNotOK();

                return providerResult;
            }
        }

        /// <summary>
        /// The GetNext method will move the enumerator forward one element and return the script provider which is at that element.<para/>
        /// When the enumerator hits the end of enumeration, E_BOUNDS will be returned. Calling the GetNext method after receiving this error will continue to return E_BOUNDS indefinitely.
        /// </summary>
        /// <param name="providerResult">The next script provider registered with the script manager will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetNext(out DataModelScriptProvider providerResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptProvider provider);*/
            IDataModelScriptProvider provider;
            HRESULT hr = Raw.GetNext(out provider);

            if (hr == HRESULT.S_OK)
                providerResult = provider == null ? null : new DataModelScriptProvider(provider);
            else
                providerResult = default(DataModelScriptProvider);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator to the first element.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator to the first element.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
