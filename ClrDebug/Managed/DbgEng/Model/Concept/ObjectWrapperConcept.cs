namespace ClrDebug.DbgEng
{
    public class ObjectWrapperConcept : ComObject<IObjectWrapperConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectWrapperConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ObjectWrapperConcept(IObjectWrapperConcept raw) : base(raw)
        {
        }

        #region IObjectWrapperConcept
        #region GetWrappedObject

        public GetWrappedObjectResult GetWrappedObject(IModelObject pContextObject)
        {
            GetWrappedObjectResult result;
            TryGetWrappedObject(pContextObject, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetWrappedObject(IModelObject pContextObject, out GetWrappedObjectResult result)
        {
            /*HRESULT GetWrappedObject(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pContextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject wrappedObject,
            [Out] out WrappedObjectPreference pUsagePreference);*/
            IModelObject wrappedObject;
            WrappedObjectPreference pUsagePreference;
            HRESULT hr = Raw.GetWrappedObject(pContextObject, out wrappedObject, out pUsagePreference);

            if (hr == HRESULT.S_OK)
                result = new GetWrappedObjectResult(wrappedObject == null ? null : new ModelObject(wrappedObject), pUsagePreference);
            else
                result = default(GetWrappedObjectResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
