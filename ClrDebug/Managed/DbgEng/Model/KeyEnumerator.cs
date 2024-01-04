namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator which runs through keys on an object.
    /// </summary>
    public class KeyEnumerator : ComObject<IKeyEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public KeyEnumerator(IKeyEnumerator raw) : base(raw)
        {
        }

        #region IKeyEnumerator
        #region Next

        /// <summary>
        /// Moves the iterator forward and fetches the name of the next key and, optionally, its value (or a reference to it) and associated metadata.<para/>
        /// Note that depending on how this enumerator was acquired, the object returned in the value field may be the value associated with the key (EnumerateKeys), the resolved value of any property that the key refers to (EnumerateKeyValues), or a reference to the key (EnumerateKeyReferences).<para/>
        /// If there was an error in resolving the value of the key (for EnumerateKeyValues, for instance), the method may return an error AND fill value with an error object.<para/>
        /// When the enumerator hits the end of the sequence, E_BOUNDS will be returned.
        /// </summary>
        public KeyEnumerator_GetNextResult Next
        {
            get
            {
                KeyEnumerator_GetNextResult result;
                TryGetNext(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// Moves the iterator forward and fetches the name of the next key and, optionally, its value (or a reference to it) and associated metadata.<para/>
        /// Note that depending on how this enumerator was acquired, the object returned in the value field may be the value associated with the key (EnumerateKeys), the resolved value of any property that the key refers to (EnumerateKeyValues), or a reference to the key (EnumerateKeyReferences).<para/>
        /// If there was an error in resolving the value of the key (for EnumerateKeyValues, for instance), the method may return an error AND fill value with an error object.<para/>
        /// When the enumerator hits the end of the sequence, E_BOUNDS will be returned.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetNext(out KeyEnumerator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            string key;
            IModelObject value;
            IKeyStore metadata;
            HRESULT hr = Raw.GetNext(out key, out value, out metadata);

            if (hr == HRESULT.S_OK)
                result = new KeyEnumerator_GetNextResult(key, value == null ? null : new ModelObject(value), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(KeyEnumerator_GetNextResult);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first key in enumerator order.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first key in enumerator order.
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
