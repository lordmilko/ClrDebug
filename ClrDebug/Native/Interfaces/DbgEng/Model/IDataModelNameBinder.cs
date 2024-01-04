using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Interface to a name binder – a component which can associate names in a context with objects or symbols. The default name binder for script providers.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("AF352B7B-8292-4C01-B360-2DC3696C65E7")]
    [ComImport]
    public interface IDataModelNameBinder
    {
        /// <summary>
        /// The BindValue method performs the equivalent of contextObject.name on the given object according to a set of binding rules.<para/>
        /// The result of this binding is a value. As a value, the underlying script provider cannot use the value to perform assignment back to name.
        /// </summary>
        /// <param name="contextObject">The object to bind a name against.</param>
        /// <param name="name">The name to bind in the context of contextObject.</param>
        /// <param name="value">The value of name in the context of contextObject is returned. As a value binding, this cannot be used to support assignment back to name.</param>
        /// <param name="metadata">Any metadata optionally associated with name is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT BindValue(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The BindReference method is similar to BindValue in that it also performs the equivalent of contextObject.name on the given object according to a set of binding rules.<para/>
        /// The result of the binding from this method is, however, a reference instead of a value. As a reference, the script provider can utilize the reference to perform assignment back to name.
        /// </summary>
        /// <param name="contextObject">The object to bind a name against.</param>
        /// <param name="name">The name to bind in the context of contextObject.</param>
        /// <param name="reference">A reference to name in the context of contextObject is returned. As a reference binding, this can be used to support assignment back to name.</param>
        /// <param name="metadata">Any metadata optionally associated with name is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT BindReference(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject reference,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The EnumerateValues method enumerates the set of names and values which will bind against the object according to the rules of the BindValue method.<para/>
        /// Unlike the EnumerateKeys, EnumerateValues, and similar methods on <see cref="IModelObject"/> which may return multiple names with the same value (for base classes, parent models, and the like), this enumerator will only return the specific set of names which will bind with BindValue and BindReference.<para/>
        /// Names will never be duplicated. Note that there is a significantly higher cost of enumerating an object via the name binder than calling the <see cref="IModelObject"/> methods.
        /// </summary>
        /// <param name="contextObject">The object for which to enumerate all name bindings and their values.</param>
        /// <param name="enumerator">An enumerator which will enumerate every name that would bind according to calls to BindValue and their values.<para/>
        /// Note that this enumerator will never duplicate names. It will only return the set of names and values which would come out of explicit calls to BindValue.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT EnumerateValues(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);

        /// <summary>
        /// The EnumerateReferences method enumerates the set of names and references to them which will bind against the object according to the rules of the BindReference method.<para/>
        /// Unlike the EnumerateKeys, EnumerateValues, and similar methods on <see cref="IModelObject"/> which may return multiple names with the same value (for base classes, parent models, and the like), this enumerator will only return the specific set of names which will bind with BindValue and BindReference.<para/>
        /// Names will never be duplicated. Note that there is a significantly higher cost of enumerating an object via the name binder than calling the <see cref="IModelObject"/> methods.
        /// </summary>
        /// <param name="contextObject">The object for which to enumerate all name bindings and references to them.</param>
        /// <param name="enumerator">An enumerator which will enumerate every name that would bind according to calls to BindReference and references to them.<para/>
        /// Note that this enumerator will never duplicate names. It will only return the set of names and values which would come out of explicit calls to BindReference.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT EnumerateReferences(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);
    }
}
