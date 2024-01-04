using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A key/value store. Typically used for metadata.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0FC7557D-401D-4FCA-9365-DA1E9850697C")]
    [ComImport]
    public interface IKeyStore
    {
        /// <summary>
        /// The GetKey method is analogous to the GetKey method on <see cref="IModelObject"/>. It will return the value of the specified key if it exists in the key store or the key store's parent store.<para/>
        /// Note that if the value of the key is a property accessor, the GetValue method will not be called on the property accessor.<para/>
        /// The actual <see cref="IModelPropertyAccessor"/> boxed into an <see cref="IModelObject"/> will be returned. It is typical that a client will call GetKeyValue for this reason.
        /// </summary>
        /// <param name="key">The name of the key to get a value for</param>
        /// <param name="object">The value of the key will be returned in this argument.</param>
        /// <param name="metadata">The metadata store associated with this key will be optionally returned in this argument. There is no present use for second level metadata.<para/>
        /// This argument should therefore typically be specified as null.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. The return values E_BOUNDS (or E_NOT_SET in some cases) indicates the key could not be found.</returns>
        [PreserveSig]
        HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The SetKey method is analogous to the SetKey method on <see cref="IModelObject"/>. It is the only method which is capable of creating a key and associating metadata with it within the key store.
        /// </summary>
        /// <param name="key">The name of the key to create or set a value for.</param>
        /// <param name="object">The value of the key.</param>
        /// <param name="metadata">Optional metadata to be associated with this key. There is no present use for second level metadata. This argument should therefore typically be specified as null.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);

        /// <summary>
        /// The GetKeyValue method is the first method a client will go to in order to find the value of a particular key within the metadata store.<para/>
        /// If the key specified by the key argument exists within the store (or it's parent store), the value of that key and any metadata associated with it will be returned.<para/>
        /// If the value of the key is a property accessor (an <see cref="IModelPropertyAccessor"/> boxed into an <see cref="IModelObject"/>), the GetValue method of the property accessor will automatically be called by GetKeyValue and the underlying value of the property returned.
        /// </summary>
        /// <param name="key">The name of the key to return a value for.</param>
        /// <param name="object">The value of the key will be returned here. If the key's value is a property accessor, the GetValue method will be called on the property accessor and that underlying value will be returned here..</param>
        /// <param name="metadata">Any metadata which is associated with the key is optionally returned here. There is no present use for second level metadata.<para/>
        /// This argument should therefore typically be specified as null.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The SetKeyValue method is analogous to the SetKeyValue method on <see cref="IModelObject"/>. This method is not capable of creating a new key within the metadata store.<para/>
        /// If there is an existing key as indicated by the key argument, its value will be set as indicated. If the key is a property accessor, the SetValue method will be called on the property accessor in order to set the underlying value.<para/>
        /// Note that metadata is typically static once created. Use of this method on a metadata key store should be infrequent.
        /// </summary>
        /// <param name="key">The name of the key to set a value for.</param>
        /// <param name="object">The value to assign to the key. If the current key's value is a property accessor, the SetValue method will be called on the property accessor to set the underlying value.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);

        /// <summary>
        /// The ClearKeys method is analogous to the ClearKeys method on <see cref="IModelObject"/>. It will remove every key from the given metadata store.<para/>
        /// This method has no effect on any parent store.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT ClearKeys();
    }
}
