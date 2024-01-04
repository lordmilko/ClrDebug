using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A reference to a key on a data model object. This version 2 of the interface supports all of the previous methods with identical signatures and includes additional new methods that provide added functionality.<para/>
    /// The new methods are listed in the header at the end of the section for that interface.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("80E2F7C5-7159-4E92-887E-7E0347E88406")]
    [ComImport]
    public interface IModelKeyReference2 : IModelKeyReference
    {
        /// <summary>
        /// The GetKeyName method returns the name of the key to which this key reference is a handle. The returned string is a standard BSTR and must be freed via a call to SysFreeString.
        /// </summary>
        /// <param name="keyName">The name of the key to which this key reference is a handle will be returned here as an allocated string.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetKeyName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string keyName);

        /// <summary>
        /// The GetOriginalObject method returns the instance object from which the key reference was created. Note that the key may itself be on a parent model of the instance object.
        /// </summary>
        /// <param name="originalObject">The instance object from which the key reference was created will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetOriginalObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject originalObject);

        /// <summary>
        /// The GetContextObject method returns the context (this pointer) which will be passed to a property accessor's GetValue or SetValue method if the key in question refers to a property accessor.<para/>
        /// The context object returned here may or may not be the same as the original object fetched from GetOriginalObject.<para/>
        /// If a key is on a parent model and there is a context adjustor associated with that parent model, the original object is the instance object on which GetKeyReference or EnumerateKeyReferences was called.<para/>
        /// The context object would be whatever comes out of the final context adjustor between the original object and the parent model containing the key to which this key reference is a handle.<para/>
        /// If there are no context adjustors, the original object and the context object are identical.
        /// </summary>
        /// <param name="containingObject">The context object which will be passed to any property accessor method is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetContextObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject containingObject);

        /// <summary>
        /// The GetKey method on a key reference behaves as the GetKey method on <see cref="IModelObject"/> would. It returns the value of the underlying key and any metadata associated with the key.<para/>
        /// If the value of the key happens to be a property accessor, this will return the property accessor (<see cref="IModelPropertyAccessor"/>) boxed into an <see cref="IModelObject"/>.<para/>
        /// This method will not call the underlying GetValue or SetValue methods on the property accessor.
        /// </summary>
        /// <param name="object">The value of the key will be returned here.</param>
        /// <param name="metadata">Optional metadata which is associated with the key will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetKey(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The GetKeyValue method on a key reference behaves as the GetKeyValue method on <see cref="IModelObject"/> would.<para/>
        /// It returns the value of the underlying key and any metadata associated with the key. If the value of the key happens to be a property accessor, this will call the underlying GetValue method on the property accessor automatically.
        /// </summary>
        /// <param name="object">The value of the key will be returned here. Note that extended error information may be returned here on failure.</param>
        /// <param name="metadata">Optional metadata which is associated with the key will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT GetKeyValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The SetKey method on a key reference behaves as the SetKey method on <see cref="IModelObject"/> would. It will assign the value of the key.<para/>
        /// If the original key was a property accessor, this will replace the property accessor. It will not call the SetValue method on the property accessor.
        /// </summary>
        /// <param name="object">The value to assign to the key.</param>
        /// <param name="metadata">Optional metadata to be associated with the key.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);

        /// <summary>
        /// The SetKeyValue method on a key reference behaves as the SetKeyValue method on <see cref="IModelObject"/> would.<para/>
        /// It will assign the value of the key. If the original key was a property accessor, this will call the underlying SetValue method on the property accessor rather than replacing the property accessor itself.
        /// </summary>
        /// <param name="object">The value to assign to the key.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);

        /// <summary>
        /// The OverrideContextObject method (only present on <see cref="IModelKeyReference2"/>) is an advanced method which is used to permanently alter the context object which this key reference will pass to any underlying property accessor's GetValue or SetValue methods.<para/>
        /// The object passed to this method will also be returned from a call to GetContextObject. This method can be used by script providers to replicate certain dynamic language behaviors.<para/>
        /// Most clients should not call this method.
        /// </summary>
        /// <param name="newContextObject">The new context object to pass to any underlying property accessor's GetValue or SetValue methods.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT OverrideContextObject(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject newContextObject);
    }
}
