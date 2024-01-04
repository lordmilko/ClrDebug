namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A key/value store. Typically used for metadata.
    /// </summary>
    public class KeyStore : ComObject<IKeyStore>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyStore"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public KeyStore(IKeyStore raw) : base(raw)
        {
        }

        #region IKeyStore
        #region GetKey

        /// <summary>
        /// The GetKey method is analogous to the GetKey method on <see cref="IModelObject"/>. It will return the value of the specified key if it exists in the key store or the key store's parent store.<para/>
        /// Note that if the value of the key is a property accessor, the GetValue method will not be called on the property accessor.<para/>
        /// The actual <see cref="IModelPropertyAccessor"/> boxed into an <see cref="IModelObject"/> will be returned. It is typical that a client will call GetKeyValue for this reason.
        /// </summary>
        /// <param name="key">The name of the key to get a value for</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public KeyStore_GetKeyResult GetKey(string key)
        {
            KeyStore_GetKeyResult result;
            TryGetKey(key, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetKey method is analogous to the GetKey method on <see cref="IModelObject"/>. It will return the value of the specified key if it exists in the key store or the key store's parent store.<para/>
        /// Note that if the value of the key is a property accessor, the GetValue method will not be called on the property accessor.<para/>
        /// The actual <see cref="IModelPropertyAccessor"/> boxed into an <see cref="IModelObject"/> will be returned. It is typical that a client will call GetKeyValue for this reason.
        /// </summary>
        /// <param name="key">The name of the key to get a value for</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. The return values E_BOUNDS (or E_NOT_SET in some cases) indicates the key could not be found.</returns>
        public HRESULT TryGetKey(string key, out KeyStore_GetKeyResult result)
        {
            /*HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject @object;
            IKeyStore metadata;
            HRESULT hr = Raw.GetKey(key, out @object, out metadata);

            if (hr == HRESULT.S_OK)
                result = new KeyStore_GetKeyResult(@object == null ? null : new ModelObject(@object), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(KeyStore_GetKeyResult);

            return hr;
        }

        #endregion
        #region SetKey

        /// <summary>
        /// The SetKey method is analogous to the SetKey method on <see cref="IModelObject"/>. It is the only method which is capable of creating a key and associating metadata with it within the key store.
        /// </summary>
        /// <param name="key">The name of the key to create or set a value for.</param>
        /// <param name="object">The value of the key.</param>
        /// <param name="metadata">Optional metadata to be associated with this key. There is no present use for second level metadata. This argument should therefore typically be specified as null.</param>
        public void SetKey(string key, IModelObject @object, IKeyStore metadata)
        {
            TrySetKey(key, @object, metadata).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetKey method is analogous to the SetKey method on <see cref="IModelObject"/>. It is the only method which is capable of creating a key and associating metadata with it within the key store.
        /// </summary>
        /// <param name="key">The name of the key to create or set a value for.</param>
        /// <param name="object">The value of the key.</param>
        /// <param name="metadata">Optional metadata to be associated with this key. There is no present use for second level metadata. This argument should therefore typically be specified as null.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TrySetKey(string key, IModelObject @object, IKeyStore metadata)
        {
            /*HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);*/
            return Raw.SetKey(key, @object, metadata);
        }

        #endregion
        #region GetKeyValue

        /// <summary>
        /// The GetKeyValue method is the first method a client will go to in order to find the value of a particular key within the metadata store.<para/>
        /// If the key specified by the key argument exists within the store (or it's parent store), the value of that key and any metadata associated with it will be returned.<para/>
        /// If the value of the key is a property accessor (an <see cref="IModelPropertyAccessor"/> boxed into an <see cref="IModelObject"/>), the GetValue method of the property accessor will automatically be called by GetKeyValue and the underlying value of the property returned.
        /// </summary>
        /// <param name="key">The name of the key to return a value for.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public GetKeyValueResult GetKeyValue(string key)
        {
            GetKeyValueResult result;
            TryGetKeyValue(key, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetKeyValue method is the first method a client will go to in order to find the value of a particular key within the metadata store.<para/>
        /// If the key specified by the key argument exists within the store (or it's parent store), the value of that key and any metadata associated with it will be returned.<para/>
        /// If the value of the key is a property accessor (an <see cref="IModelPropertyAccessor"/> boxed into an <see cref="IModelObject"/>), the GetValue method of the property accessor will automatically be called by GetKeyValue and the underlying value of the property returned.
        /// </summary>
        /// <param name="key">The name of the key to return a value for.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetKeyValue(string key, out GetKeyValueResult result)
        {
            /*HRESULT GetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject @object;
            IKeyStore metadata;
            HRESULT hr = Raw.GetKeyValue(key, out @object, out metadata);

            if (hr == HRESULT.S_OK)
                result = new GetKeyValueResult(@object == null ? null : new ModelObject(@object), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(GetKeyValueResult);

            return hr;
        }

        #endregion
        #region SetKeyValue

        /// <summary>
        /// The SetKeyValue method is analogous to the SetKeyValue method on <see cref="IModelObject"/>. This method is not capable of creating a new key within the metadata store.<para/>
        /// If there is an existing key as indicated by the key argument, its value will be set as indicated. If the key is a property accessor, the SetValue method will be called on the property accessor in order to set the underlying value.<para/>
        /// Note that metadata is typically static once created. Use of this method on a metadata key store should be infrequent.
        /// </summary>
        /// <param name="key">The name of the key to set a value for.</param>
        /// <param name="object">The value to assign to the key. If the current key's value is a property accessor, the SetValue method will be called on the property accessor to set the underlying value.</param>
        public void SetKeyValue(string key, IModelObject @object)
        {
            TrySetKeyValue(key, @object).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetKeyValue method is analogous to the SetKeyValue method on <see cref="IModelObject"/>. This method is not capable of creating a new key within the metadata store.<para/>
        /// If there is an existing key as indicated by the key argument, its value will be set as indicated. If the key is a property accessor, the SetValue method will be called on the property accessor in order to set the underlying value.<para/>
        /// Note that metadata is typically static once created. Use of this method on a metadata key store should be infrequent.
        /// </summary>
        /// <param name="key">The name of the key to set a value for.</param>
        /// <param name="object">The value to assign to the key. If the current key's value is a property accessor, the SetValue method will be called on the property accessor to set the underlying value.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TrySetKeyValue(string key, IModelObject @object)
        {
            /*HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);*/
            return Raw.SetKeyValue(key, @object);
        }

        #endregion
        #region ClearKeys

        /// <summary>
        /// The ClearKeys method is analogous to the ClearKeys method on <see cref="IModelObject"/>. It will remove every key from the given metadata store.<para/>
        /// This method has no effect on any parent store.
        /// </summary>
        public void ClearKeys()
        {
            TryClearKeys().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The ClearKeys method is analogous to the ClearKeys method on <see cref="IModelObject"/>. It will remove every key from the given metadata store.<para/>
        /// This method has no effect on any parent store.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryClearKeys()
        {
            /*HRESULT ClearKeys();*/
            return Raw.ClearKeys();
        }

        #endregion
        #endregion
    }
}
