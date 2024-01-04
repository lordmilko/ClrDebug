using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// A reference to a key on a data model object.
    /// </summary>
    public class ModelKeyReference : ComObject<IModelKeyReference>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelKeyReference"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ModelKeyReference(IModelKeyReference raw) : base(raw)
        {
        }

        #region IModelKeyReference
        #region KeyName

        /// <summary>
        /// The GetKeyName method returns the name of the key to which this key reference is a handle. The returned string is a standard BSTR and must be freed via a call to SysFreeString.
        /// </summary>
        public string KeyName
        {
            get
            {
                string keyName;
                TryGetKeyName(out keyName).ThrowDbgEngNotOK();

                return keyName;
            }
        }

        /// <summary>
        /// The GetKeyName method returns the name of the key to which this key reference is a handle. The returned string is a standard BSTR and must be freed via a call to SysFreeString.
        /// </summary>
        /// <param name="keyName">The name of the key to which this key reference is a handle will be returned here as an allocated string.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetKeyName(out string keyName)
        {
            /*HRESULT GetKeyName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string keyName);*/
            return Raw.GetKeyName(out keyName);
        }

        #endregion
        #region OriginalObject

        /// <summary>
        /// The GetOriginalObject method returns the instance object from which the key reference was created. Note that the key may itself be on a parent model of the instance object.
        /// </summary>
        public ModelObject OriginalObject
        {
            get
            {
                ModelObject originalObjectResult;
                TryGetOriginalObject(out originalObjectResult).ThrowDbgEngNotOK();

                return originalObjectResult;
            }
        }

        /// <summary>
        /// The GetOriginalObject method returns the instance object from which the key reference was created. Note that the key may itself be on a parent model of the instance object.
        /// </summary>
        /// <param name="originalObjectResult">The instance object from which the key reference was created will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetOriginalObject(out ModelObject originalObjectResult)
        {
            /*HRESULT GetOriginalObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject originalObject);*/
            IModelObject originalObject;
            HRESULT hr = Raw.GetOriginalObject(out originalObject);

            if (hr == HRESULT.S_OK)
                originalObjectResult = originalObject == null ? null : new ModelObject(originalObject);
            else
                originalObjectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region ContextObject

        /// <summary>
        /// The GetContextObject method returns the context (this pointer) which will be passed to a property accessor's GetValue or SetValue method if the key in question refers to a property accessor.<para/>
        /// The context object returned here may or may not be the same as the original object fetched from GetOriginalObject.<para/>
        /// If a key is on a parent model and there is a context adjustor associated with that parent model, the original object is the instance object on which GetKeyReference or EnumerateKeyReferences was called.<para/>
        /// The context object would be whatever comes out of the final context adjustor between the original object and the parent model containing the key to which this key reference is a handle.<para/>
        /// If there are no context adjustors, the original object and the context object are identical.
        /// </summary>
        public ModelObject ContextObject
        {
            get
            {
                ModelObject containingObjectResult;
                TryGetContextObject(out containingObjectResult).ThrowDbgEngNotOK();

                return containingObjectResult;
            }
        }

        /// <summary>
        /// The GetContextObject method returns the context (this pointer) which will be passed to a property accessor's GetValue or SetValue method if the key in question refers to a property accessor.<para/>
        /// The context object returned here may or may not be the same as the original object fetched from GetOriginalObject.<para/>
        /// If a key is on a parent model and there is a context adjustor associated with that parent model, the original object is the instance object on which GetKeyReference or EnumerateKeyReferences was called.<para/>
        /// The context object would be whatever comes out of the final context adjustor between the original object and the parent model containing the key to which this key reference is a handle.<para/>
        /// If there are no context adjustors, the original object and the context object are identical.
        /// </summary>
        /// <param name="containingObjectResult">The context object which will be passed to any property accessor method is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetContextObject(out ModelObject containingObjectResult)
        {
            /*HRESULT GetContextObject(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject containingObject);*/
            IModelObject containingObject;
            HRESULT hr = Raw.GetContextObject(out containingObject);

            if (hr == HRESULT.S_OK)
                containingObjectResult = containingObject == null ? null : new ModelObject(containingObject);
            else
                containingObjectResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region Key

        /// <summary>
        /// The GetKey method on a key reference behaves as the GetKey method on <see cref="IModelObject"/> would. It returns the value of the underlying key and any metadata associated with the key.<para/>
        /// If the value of the key happens to be a property accessor, this will return the property accessor (<see cref="IModelPropertyAccessor"/>) boxed into an <see cref="IModelObject"/>.<para/>
        /// This method will not call the underlying GetValue or SetValue methods on the property accessor.
        /// </summary>
        public ModelKeyReference_GetKeyResult Key
        {
            get
            {
                ModelKeyReference_GetKeyResult result;
                TryGetKey(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetKey method on a key reference behaves as the GetKey method on <see cref="IModelObject"/> would. It returns the value of the underlying key and any metadata associated with the key.<para/>
        /// If the value of the key happens to be a property accessor, this will return the property accessor (<see cref="IModelPropertyAccessor"/>) boxed into an <see cref="IModelObject"/>.<para/>
        /// This method will not call the underlying GetValue or SetValue methods on the property accessor.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetKey(out ModelKeyReference_GetKeyResult result)
        {
            /*HRESULT GetKey(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject @object;
            IKeyStore metadata;
            HRESULT hr = Raw.GetKey(out @object, out metadata);

            if (hr == HRESULT.S_OK)
                result = new ModelKeyReference_GetKeyResult(@object == null ? null : new ModelObject(@object), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(ModelKeyReference_GetKeyResult);

            return hr;
        }

        #endregion
        #region KeyValue

        /// <summary>
        /// The GetKeyValue method on a key reference behaves as the GetKeyValue method on <see cref="IModelObject"/> would.<para/>
        /// It returns the value of the underlying key and any metadata associated with the key. If the value of the key happens to be a property accessor, this will call the underlying GetValue method on the property accessor automatically.
        /// </summary>
        public GetKeyValueResult KeyValue
        {
            get
            {
                GetKeyValueResult result;
                TryGetKeyValue(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetKeyValue method on a key reference behaves as the GetKeyValue method on <see cref="IModelObject"/> would.<para/>
        /// It returns the value of the underlying key and any metadata associated with the key. If the value of the key happens to be a property accessor, this will call the underlying GetValue method on the property accessor automatically.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetKeyValue(out GetKeyValueResult result)
        {
            /*HRESULT GetKeyValue(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject @object;
            IKeyStore metadata;
            HRESULT hr = Raw.GetKeyValue(out @object, out metadata);

            if (hr == HRESULT.S_OK)
                result = new GetKeyValueResult(@object == null ? null : new ModelObject(@object), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(GetKeyValueResult);

            return hr;
        }

        #endregion
        #region SetKey

        /// <summary>
        /// The SetKey method on a key reference behaves as the SetKey method on <see cref="IModelObject"/> would. It will assign the value of the key.<para/>
        /// If the original key was a property accessor, this will replace the property accessor. It will not call the SetValue method on the property accessor.
        /// </summary>
        /// <param name="object">The value to assign to the key.</param>
        /// <param name="metadata">Optional metadata to be associated with the key.</param>
        public void SetKey(IModelObject @object, IKeyStore metadata)
        {
            TrySetKey(@object, metadata).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetKey method on a key reference behaves as the SetKey method on <see cref="IModelObject"/> would. It will assign the value of the key.<para/>
        /// If the original key was a property accessor, this will replace the property accessor. It will not call the SetValue method on the property accessor.
        /// </summary>
        /// <param name="object">The value to assign to the key.</param>
        /// <param name="metadata">Optional metadata to be associated with the key.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TrySetKey(IModelObject @object, IKeyStore metadata)
        {
            /*HRESULT SetKey(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object,
            [In, MarshalAs(UnmanagedType.Interface)] IKeyStore metadata);*/
            return Raw.SetKey(@object, metadata);
        }

        #endregion
        #region SetKeyValue

        /// <summary>
        /// The SetKeyValue method on a key reference behaves as the SetKeyValue method on <see cref="IModelObject"/> would.<para/>
        /// It will assign the value of the key. If the original key was a property accessor, this will call the underlying SetValue method on the property accessor rather than replacing the property accessor itself.
        /// </summary>
        /// <param name="object">The value to assign to the key.</param>
        public void SetKeyValue(IModelObject @object)
        {
            TrySetKeyValue(@object).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetKeyValue method on a key reference behaves as the SetKeyValue method on <see cref="IModelObject"/> would.<para/>
        /// It will assign the value of the key. If the original key was a property accessor, this will call the underlying SetValue method on the property accessor rather than replacing the property accessor itself.
        /// </summary>
        /// <param name="object">The value to assign to the key.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TrySetKeyValue(IModelObject @object)
        {
            /*HRESULT SetKeyValue(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject @object);*/
            return Raw.SetKeyValue(@object);
        }

        #endregion
        #endregion
        #region IModelKeyReference2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IModelKeyReference2 Raw2 => (IModelKeyReference2) Raw;

        #region OverrideContextObject

        /// <summary>
        /// The OverrideContextObject method (only present on <see cref="IModelKeyReference2"/>) is an advanced method which is used to permanently alter the context object which this key reference will pass to any underlying property accessor's GetValue or SetValue methods.<para/>
        /// The object passed to this method will also be returned from a call to GetContextObject. This method can be used by script providers to replicate certain dynamic language behaviors.<para/>
        /// Most clients should not call this method.
        /// </summary>
        /// <param name="newContextObject">The new context object to pass to any underlying property accessor's GetValue or SetValue methods.</param>
        public void OverrideContextObject(IModelObject newContextObject)
        {
            TryOverrideContextObject(newContextObject).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The OverrideContextObject method (only present on <see cref="IModelKeyReference2"/>) is an advanced method which is used to permanently alter the context object which this key reference will pass to any underlying property accessor's GetValue or SetValue methods.<para/>
        /// The object passed to this method will also be returned from a call to GetContextObject. This method can be used by script providers to replicate certain dynamic language behaviors.<para/>
        /// Most clients should not call this method.
        /// </summary>
        /// <param name="newContextObject">The new context object to pass to any underlying property accessor's GetValue or SetValue methods.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryOverrideContextObject(IModelObject newContextObject)
        {
            /*HRESULT OverrideContextObject(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject newContextObject);*/
            return Raw2.OverrideContextObject(newContextObject);
        }

        #endregion
        #endregion
    }
}
