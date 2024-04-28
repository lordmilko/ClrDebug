using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// If a client wants to take over the storage of keys and values for an object, it can implement this concept interface.<para/>
    /// The object is a dynamic provider of keys and wishes to take over all key queries from the core data model. This interface is typically used as a bridge to dynamic languages such as JavaScript.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E7983FA1-80A7-498C-988F-518DDC5D4025")]
    [ComImport]
    public interface IDynamicKeyProviderConcept
    {
        /// <summary>
        /// The GetKey method on a dynamic key provider is largely an override of the GetKey method on <see cref="IModelObject"/>.<para/>
        /// The dynamic key provider is expected to return the value of the key and any metadata associated with that key. In the event that the key is not present (but no other error occurs), the provider must return false in the hasKey parameter and succeed with S_OK.<para/>
        /// Failing this call is considered a failure to fetch a key and will explicitly halt the search for the key through the parent model chain.<para/>
        /// Returning false in hasKey and success will continue the search for the key. Note that it is perfectly legal for GetKey to return a boxed property accessor as the key.<para/>
        /// This would be semantically identical to the GetKey method on <see cref="IModelObject"/> returning a property accessor.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to get a key.</param>
        /// <param name="key">The name of the key being retrieved.</param>
        /// <param name="keyValue">The value of the key as determined by the dynamic provider is returned here. If an error occurs in the fetch and an invalid HRESULT is returned, this may return extended error information.<para/>
        /// It is legal for the implementation of the GetKey method to return a property accessor (<see cref="IModelPropertyAccessor"/>).</param>
        /// <param name="metadata">Any metadata which is associated with the key can optionally be returned here.</param>
        /// <param name="hasKey">An indication of whether the dynamic provider has the key or not. If the provider does not have the key, it must return false here and succeed.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject keyValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata,
            [Out, MarshalAs(UnmanagedType.U1)] out bool hasKey);

        /// <summary>
        /// The SetKey method on a dynamic key provider is effectively an override of the SetKey method on <see cref="IModelObject"/>.<para/>
        /// This sets a key in the dynamic provider. It is effectively the creation of a new property on the provider. Note that a provider which does not support any notion of something like the creation of expando properties should return E_NOTIMPL here.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to set a key.</param>
        /// <param name="key">The name of the key to set.</param>
        /// <param name="keyValue">The value of the key to set.</param>
        /// <param name="metadata">Optional metadata to be associated with the (newly created) key.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject keyValue,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);

        /// <summary>
        /// The EnumerateKeys method on a dynamic key provider is effectively an override of the EnumerateKeys method on <see cref="IModelObject"/>.<para/>
        /// This enumerates all the keys in the dynamic provider. The returned enumerator has several restrictions that must be honored by the implementation:
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) for which to enumerate keys.</param>
        /// <param name="ppEnumerator">An enumerator for all keys on the dynamic provider must be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        HRESULT EnumerateKeys(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator ppEnumerator);
    }
}
