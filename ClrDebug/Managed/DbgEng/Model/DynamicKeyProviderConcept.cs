namespace ClrDebug.DbgEng
{
    /// <summary>
    /// If a client wants to take over the storage of keys and values for an object, it can implement this concept interface.<para/>
    /// The object is a dynamic provider of keys and wishes to take over all key queries from the core data model. This interface is typically used as a bridge to dynamic languages such as JavaScript.
    /// </summary>
    public class DynamicKeyProviderConcept : ComObject<IDynamicKeyProviderConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicKeyProviderConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DynamicKeyProviderConcept(IDynamicKeyProviderConcept raw) : base(raw)
        {
        }

        #region IDynamicKeyProviderConcept
        #region GetKey

        /// <summary>
        /// The GetKey method on a dynamic key provider is largely an override of the GetKey method on <see cref="IModelObject"/>.<para/>
        /// The dynamic key provider is expected to return the value of the key and any metadata associated with that key. In the event that the key is not present (but no other error occurs), the provider must return false in the hasKey parameter and succeed with S_OK.<para/>
        /// Failing this call is considered a failure to fetch a key and will explicitly halt the search for the key through the parent model chain.<para/>
        /// Returning false in hasKey and success will continue the search for the key. Note that it is perfectly legal for GetKey to return a boxed property accessor as the key.<para/>
        /// This would be semantically identical to the GetKey method on <see cref="IModelObject"/> returning a property accessor.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to get a key.</param>
        /// <param name="key">The name of the key being retrieved.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetKeyResult GetKey(IModelObject contextObject, string key)
        {
            GetKeyResult result;
            TryGetKey(contextObject, key, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetKey method on a dynamic key provider is largely an override of the GetKey method on <see cref="IModelObject"/>.<para/>
        /// The dynamic key provider is expected to return the value of the key and any metadata associated with that key. In the event that the key is not present (but no other error occurs), the provider must return false in the hasKey parameter and succeed with S_OK.<para/>
        /// Failing this call is considered a failure to fetch a key and will explicitly halt the search for the key through the parent model chain.<para/>
        /// Returning false in hasKey and success will continue the search for the key. Note that it is perfectly legal for GetKey to return a boxed property accessor as the key.<para/>
        /// This would be semantically identical to the GetKey method on <see cref="IModelObject"/> returning a property accessor.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to get a key.</param>
        /// <param name="key">The name of the key being retrieved.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetKey(IModelObject contextObject, string key, out GetKeyResult result)
        {
            /*HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject keyValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata,
            [Out, MarshalAs(UnmanagedType.U1)] out bool hasKey);*/
            IModelObject keyValue;
            IKeyStore metadata;
            bool hasKey;
            HRESULT hr = Raw.GetKey(contextObject, key, out keyValue, out metadata, out hasKey);

            if (hr == HRESULT.S_OK)
                result = new GetKeyResult(keyValue == null ? null : new ModelObject(keyValue), metadata == null ? null : new KeyStore(metadata), hasKey);
            else
                result = default(GetKeyResult);

            return hr;
        }

        #endregion
        #region SetKey

        /// <summary>
        /// The SetKey method on a dynamic key provider is effectively an override of the SetKey method on <see cref="IModelObject"/>.<para/>
        /// This sets a key in the dynamic provider. It is effectively the creation of a new property on the provider. Note that a provider which does not support any notion of something like the creation of expando properties should return E_NOTIMPL here.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to set a key.</param>
        /// <param name="key">The name of the key to set.</param>
        /// <param name="keyValue">The value of the key to set.</param>
        /// <param name="metadata">Optional metadata to be associated with the (newly created) key.</param>
        public void SetKey(IModelObject contextObject, string key, IModelObject keyValue, IKeyStore metadata)
        {
            TrySetKey(contextObject, key, keyValue, metadata).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetKey method on a dynamic key provider is effectively an override of the SetKey method on <see cref="IModelObject"/>.<para/>
        /// This sets a key in the dynamic provider. It is effectively the creation of a new property on the provider. Note that a provider which does not support any notion of something like the creation of expando properties should return E_NOTIMPL here.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to set a key.</param>
        /// <param name="key">The name of the key to set.</param>
        /// <param name="keyValue">The value of the key to set.</param>
        /// <param name="metadata">Optional metadata to be associated with the (newly created) key.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TrySetKey(IModelObject contextObject, string key, IModelObject keyValue, IKeyStore metadata)
        {
            /*HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject keyValue,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);*/
            return Raw.SetKey(contextObject, key, keyValue, metadata);
        }

        #endregion
        #region EnumerateKeys

        /// <summary>
        /// The EnumerateKeys method on a dynamic key provider is effectively an override of the EnumerateKeys method on <see cref="IModelObject"/>.<para/>
        /// This enumerates all the keys in the dynamic provider. The returned enumerator has several restrictions that must be honored by the implementation:
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to enumerate keys.</param>
        /// <returns>An enumerator for all keys on the dynamic provider must be returned here.</returns>
        public KeyEnumerator EnumerateKeys(IModelObject contextObject)
        {
            KeyEnumerator ppEnumeratorResult;
            TryEnumerateKeys(contextObject, out ppEnumeratorResult).ThrowDbgEngNotOK();

            return ppEnumeratorResult;
        }

        /// <summary>
        /// The EnumerateKeys method on a dynamic key provider is effectively an override of the EnumerateKeys method on <see cref="IModelObject"/>.<para/>
        /// This enumerates all the keys in the dynamic provider. The returned enumerator has several restrictions that must be honored by the implementation:
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to enumerate keys.</param>
        /// <param name="ppEnumeratorResult">An enumerator for all keys on the dynamic provider must be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryEnumerateKeys(IModelObject contextObject, out KeyEnumerator ppEnumeratorResult)
        {
            /*HRESULT EnumerateKeys(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);*/
            IKeyEnumerator ppEnumerator;
            HRESULT hr = Raw.EnumerateKeys(contextObject, out ppEnumerator);

            if (hr == HRESULT.S_OK)
                ppEnumeratorResult = ppEnumerator == null ? null : new KeyEnumerator(ppEnumerator);
            else
                ppEnumeratorResult = default(KeyEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
