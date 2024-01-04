namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The data model representation of a property accessor (get/set).
    /// </summary>
    public class ModelPropertyAccessor : ComObject<IModelPropertyAccessor>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelPropertyAccessor"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ModelPropertyAccessor(IModelPropertyAccessor raw) : base(raw)
        {
        }

        #region IModelPropertyAccessor
        #region GetValue

        /// <summary>
        /// The GetValue method is the getter for the property accessor. It is called whenever a client wishes to fetch the underlying value of the property.<para/>
        /// Note that any caller which directly gets a property accessor is responsible for passing the key name and accurate instance object (this pointer) to the property accessor's GetValue method.
        /// </summary>
        /// <param name="key">The name of the key to get a value for. A caller which fetches a property accessor directly is responsible for passing this accurately.</param>
        /// <param name="contextObject">The context object (instance this pointer) from which the property accessor was fetched.</param>
        /// <returns>The underlying value of the property is returned here.</returns>
        public ModelObject GetValue(string key, IModelObject contextObject)
        {
            ModelObject valueResult;
            TryGetValue(key, contextObject, out valueResult).ThrowDbgEngNotOK();

            return valueResult;
        }

        /// <summary>
        /// The GetValue method is the getter for the property accessor. It is called whenever a client wishes to fetch the underlying value of the property.<para/>
        /// Note that any caller which directly gets a property accessor is responsible for passing the key name and accurate instance object (this pointer) to the property accessor's GetValue method.
        /// </summary>
        /// <param name="key">The name of the key to get a value for. A caller which fetches a property accessor directly is responsible for passing this accurately.</param>
        /// <param name="contextObject">The context object (instance this pointer) from which the property accessor was fetched.</param>
        /// <param name="valueResult">The underlying value of the property is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetValue(string key, IModelObject contextObject, out ModelObject valueResult)
        {
            /*HRESULT GetValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value);*/
            IModelObject value;
            HRESULT hr = Raw.GetValue(key, contextObject, out value);

            if (hr == HRESULT.S_OK)
                valueResult = value == null ? null : new ModelObject(value);
            else
                valueResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region SetValue

        /// <summary>
        /// The SetValue method is the setter for the property accessor. It is called whenever a client wishes to assign a value to the underlying property.<para/>
        /// Many properties are read-only. In such cases, calling the SetValue method will return E_NOTIMPL. Note that any caller which directly gets a property accessor is responsible for passing the key name and accurate instance object (this pointer) to the property accessor's SetValue method.
        /// </summary>
        /// <param name="key">The name of the key to get a value for. A caller which fetches a property accessor directly is responsible for passing this accurately.</param>
        /// <param name="contextObject">The context object (instance this pointer) from which the property accessor was fetched.</param>
        /// <param name="value">The value to assign to the property.</param>
        public void SetValue(string key, IModelObject contextObject, IModelObject value)
        {
            TrySetValue(key, contextObject, value).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetValue method is the setter for the property accessor. It is called whenever a client wishes to assign a value to the underlying property.<para/>
        /// Many properties are read-only. In such cases, calling the SetValue method will return E_NOTIMPL. Note that any caller which directly gets a property accessor is responsible for passing the key name and accurate instance object (this pointer) to the property accessor's SetValue method.
        /// </summary>
        /// <param name="key">The name of the key to get a value for. A caller which fetches a property accessor directly is responsible for passing this accurately.</param>
        /// <param name="contextObject">The context object (instance this pointer) from which the property accessor was fetched.</param>
        /// <param name="value">The value to assign to the property.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TrySetValue(string key, IModelObject contextObject, IModelObject value)
        {
            /*HRESULT SetValue(
            [In, MarshalAs(UnmanagedType.LPWStr)] string key,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject value);*/
            return Raw.SetValue(key, contextObject, value);
        }

        #endregion
        #endregion
    }
}
