namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Interface to a name binder – a component which can associate names in a context with objects or symbols. The default name binder for script providers.
    /// </summary>
    public class DataModelNameBinder : ComObject<IDataModelNameBinder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelNameBinder"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelNameBinder(IDataModelNameBinder raw) : base(raw)
        {
        }

        #region IDataModelNameBinder
        #region BindValue

        /// <summary>
        /// The BindValue method performs the equivalent of contextObject.name on the given object according to a set of binding rules.<para/>
        /// The result of this binding is a value. As a value, the underlying script provider cannot use the value to perform assignment back to name.
        /// </summary>
        /// <param name="contextObject">The object to bind a name against.</param>
        /// <param name="name">The name to bind in the context of contextObject.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public BindValueResult BindValue(IModelObject contextObject, string name)
        {
            BindValueResult result;
            TryBindValue(contextObject, name, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The BindValue method performs the equivalent of contextObject.name on the given object according to a set of binding rules.<para/>
        /// The result of this binding is a value. As a value, the underlying script provider cannot use the value to perform assignment back to name.
        /// </summary>
        /// <param name="contextObject">The object to bind a name against.</param>
        /// <param name="name">The name to bind in the context of contextObject.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryBindValue(IModelObject contextObject, string name, out BindValueResult result)
        {
            /*HRESULT BindValue(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject value;
            IKeyStore metadata;
            HRESULT hr = Raw.BindValue(contextObject, name, out value, out metadata);

            if (hr == HRESULT.S_OK)
                result = new BindValueResult(value == null ? null : new ModelObject(value), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(BindValueResult);

            return hr;
        }

        #endregion
        #region BindReference

        /// <summary>
        /// The BindReference method is similar to BindValue in that it also performs the equivalent of contextObject.name on the given object according to a set of binding rules.<para/>
        /// The result of the binding from this method is, however, a reference instead of a value. As a reference, the script provider can utilize the reference to perform assignment back to name.
        /// </summary>
        /// <param name="contextObject">The object to bind a name against.</param>
        /// <param name="name">The name to bind in the context of contextObject.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public BindReferenceResult BindReference(IModelObject contextObject, string name)
        {
            BindReferenceResult result;
            TryBindReference(contextObject, name, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The BindReference method is similar to BindValue in that it also performs the equivalent of contextObject.name on the given object according to a set of binding rules.<para/>
        /// The result of the binding from this method is, however, a reference instead of a value. As a reference, the script provider can utilize the reference to perform assignment back to name.
        /// </summary>
        /// <param name="contextObject">The object to bind a name against.</param>
        /// <param name="name">The name to bind in the context of contextObject.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryBindReference(IModelObject contextObject, string name, out BindReferenceResult result)
        {
            /*HRESULT BindReference(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string name,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject reference,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject reference;
            IKeyStore metadata;
            HRESULT hr = Raw.BindReference(contextObject, name, out reference, out metadata);

            if (hr == HRESULT.S_OK)
                result = new BindReferenceResult(reference == null ? null : new ModelObject(reference), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(BindReferenceResult);

            return hr;
        }

        #endregion
        #region EnumerateValues

        /// <summary>
        /// The EnumerateValues method enumerates the set of names and values which will bind against the object according to the rules of the BindValue method.<para/>
        /// Unlike the EnumerateKeys, EnumerateValues, and similar methods on <see cref="IModelObject"/> which may return multiple names with the same value (for base classes, parent models, and the like), this enumerator will only return the specific set of names which will bind with BindValue and BindReference.<para/>
        /// Names will never be duplicated. Note that there is a significantly higher cost of enumerating an object via the name binder than calling the <see cref="IModelObject"/> methods.
        /// </summary>
        /// <param name="contextObject">The object for which to enumerate all name bindings and their values.</param>
        /// <returns>An enumerator which will enumerate every name that would bind according to calls to BindValue and their values.<para/>
        /// Note that this enumerator will never duplicate names. It will only return the set of names and values which would come out of explicit calls to BindValue.</returns>
        public KeyEnumerator EnumerateValues(IModelObject contextObject)
        {
            KeyEnumerator enumeratorResult;
            TryEnumerateValues(contextObject, out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        /// <summary>
        /// The EnumerateValues method enumerates the set of names and values which will bind against the object according to the rules of the BindValue method.<para/>
        /// Unlike the EnumerateKeys, EnumerateValues, and similar methods on <see cref="IModelObject"/> which may return multiple names with the same value (for base classes, parent models, and the like), this enumerator will only return the specific set of names which will bind with BindValue and BindReference.<para/>
        /// Names will never be duplicated. Note that there is a significantly higher cost of enumerating an object via the name binder than calling the <see cref="IModelObject"/> methods.
        /// </summary>
        /// <param name="contextObject">The object for which to enumerate all name bindings and their values.</param>
        /// <param name="enumeratorResult">An enumerator which will enumerate every name that would bind according to calls to BindValue and their values.<para/>
        /// Note that this enumerator will never duplicate names. It will only return the set of names and values which would come out of explicit calls to BindValue.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryEnumerateValues(IModelObject contextObject, out KeyEnumerator enumeratorResult)
        {
            /*HRESULT EnumerateValues(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);*/
            IKeyEnumerator enumerator;
            HRESULT hr = Raw.EnumerateValues(contextObject, out enumerator);

            if (hr == HRESULT.S_OK)
                enumeratorResult = enumerator == null ? null : new KeyEnumerator(enumerator);
            else
                enumeratorResult = default(KeyEnumerator);

            return hr;
        }

        #endregion
        #region EnumerateReferences

        /// <summary>
        /// The EnumerateReferences method enumerates the set of names and references to them which will bind against the object according to the rules of the BindReference method.<para/>
        /// Unlike the EnumerateKeys, EnumerateValues, and similar methods on <see cref="IModelObject"/> which may return multiple names with the same value (for base classes, parent models, and the like), this enumerator will only return the specific set of names which will bind with BindValue and BindReference.<para/>
        /// Names will never be duplicated. Note that there is a significantly higher cost of enumerating an object via the name binder than calling the <see cref="IModelObject"/> methods.
        /// </summary>
        /// <param name="contextObject">The object for which to enumerate all name bindings and references to them.</param>
        /// <returns>An enumerator which will enumerate every name that would bind according to calls to BindReference and references to them.<para/>
        /// Note that this enumerator will never duplicate names. It will only return the set of names and values which would come out of explicit calls to BindReference.</returns>
        public KeyEnumerator EnumerateReferences(IModelObject contextObject)
        {
            KeyEnumerator enumeratorResult;
            TryEnumerateReferences(contextObject, out enumeratorResult).ThrowDbgEngNotOK();

            return enumeratorResult;
        }

        /// <summary>
        /// The EnumerateReferences method enumerates the set of names and references to them which will bind against the object according to the rules of the BindReference method.<para/>
        /// Unlike the EnumerateKeys, EnumerateValues, and similar methods on <see cref="IModelObject"/> which may return multiple names with the same value (for base classes, parent models, and the like), this enumerator will only return the specific set of names which will bind with BindValue and BindReference.<para/>
        /// Names will never be duplicated. Note that there is a significantly higher cost of enumerating an object via the name binder than calling the <see cref="IModelObject"/> methods.
        /// </summary>
        /// <param name="contextObject">The object for which to enumerate all name bindings and references to them.</param>
        /// <param name="enumeratorResult">An enumerator which will enumerate every name that would bind according to calls to BindReference and references to them.<para/>
        /// Note that this enumerator will never duplicate names. It will only return the set of names and values which would come out of explicit calls to BindReference.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryEnumerateReferences(IModelObject contextObject, out KeyEnumerator enumeratorResult)
        {
            /*HRESULT EnumerateReferences(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyEnumerator enumerator);*/
            IKeyEnumerator enumerator;
            HRESULT hr = Raw.EnumerateReferences(contextObject, out enumerator);

            if (hr == HRESULT.S_OK)
                enumeratorResult = enumerator == null ? null : new KeyEnumerator(enumerator);
            else
                enumeratorResult = default(KeyEnumerator);

            return hr;
        }

        #endregion
        #endregion
    }
}
