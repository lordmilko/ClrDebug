namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any object which is a container that supports random access retrieval of elements from given N-dimensional indexers implements this concept.<para/>
    /// It is legal for an object to be indexable (via support of IIndexableConcept) and not iterable (via lack of support for <see cref="IIterableConcept"/>).
    /// </summary>
    public class IndexableConcept : ComObject<IIndexableConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IndexableConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public IndexableConcept(IIndexableConcept raw) : base(raw)
        {
        }

        #region IIndexableConcept
        #region GetDimensionality

        /// <summary>
        /// The GetDimensionality method returns the number of dimensions that the object is indexed in. Note that if the object is both iterable and indexable, the implementation of GetDefaultIndexDimensionality must agree with the implementation of GetDimensionality as to how many dimensions the indexer has.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) which is being indexed is passed here.</param>
        /// <returns>The number of dimensions that the object is indexed in is returned here.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public long GetDimensionality(IModelObject contextObject)
        {
            long dimensionality;
            TryGetDimensionality(contextObject, out dimensionality).ThrowDbgEngNotOK();

            return dimensionality;
        }

        /// <summary>
        /// The GetDimensionality method returns the number of dimensions that the object is indexed in. Note that if the object is both iterable and indexable, the implementation of GetDefaultIndexDimensionality must agree with the implementation of GetDimensionality as to how many dimensions the indexer has.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) which is being indexed is passed here.</param>
        /// <param name="dimensionality">The number of dimensions that the object is indexed in is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public HRESULT TryGetDimensionality(IModelObject contextObject, out long dimensionality)
        {
            /*HRESULT GetDimensionality(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out] out long dimensionality);*/
            return Raw.GetDimensionality(contextObject, out dimensionality);
        }

        #endregion
        #region GetAt

        /// <summary>
        /// The GetAt method retrieves the value at a particular N-dimensional index from within the indexed object. An indexer of N-dimensions where N is the value returned from GetDimensionality must be supported.<para/>
        /// Note that an object may be indexable in different domains by different types (e.g.: indexable via both ordinals and strings).<para/>
        /// If the index is out of range (or could not be accessed), the method will return a failure; however, in such cases, the output object may still be set to an error object.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) which is being indexed is passed here.</param>
        /// <param name="indexerCount">The number of dimensions that the object is being indexed in.</param>
        /// <param name="indexers">An array (sized according to the indexerCount) of indicies indicating where inside the instance object to access.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public GetAtResult GetAt(IModelObject contextObject, long indexerCount, IModelObject[] indexers)
        {
            GetAtResult result;
            TryGetAt(contextObject, indexerCount, indexers, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetAt method retrieves the value at a particular N-dimensional index from within the indexed object. An indexer of N-dimensions where N is the value returned from GetDimensionality must be supported.<para/>
        /// Note that an object may be indexable in different domains by different types (e.g.: indexable via both ordinals and strings).<para/>
        /// If the index is out of range (or could not be accessed), the method will return a failure; however, in such cases, the output object may still be set to an error object.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) which is being indexed is passed here.</param>
        /// <param name="indexerCount">The number of dimensions that the object is being indexed in.</param>
        /// <param name="indexers">An array (sized according to the indexerCount) of indicies indicating where inside the instance object to access.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public HRESULT TryGetAt(IModelObject contextObject, long indexerCount, IModelObject[] indexers, out GetAtResult result)
        {
            /*HRESULT GetAt(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In] long indexerCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject @object;
            IKeyStore metadata;
            HRESULT hr = Raw.GetAt(contextObject, indexerCount, indexers, out @object, out metadata);

            if (hr == HRESULT.S_OK)
                result = new GetAtResult(@object == null ? null : new ModelObject(@object), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(GetAtResult);

            return hr;
        }

        #endregion
        #region SetAt

        /// <summary>
        /// The SetAt method attempts to set the value at a particular N-dimensional index from within the indexed object. An indexer of N-dimensions where N is the value returned from GetDimensionality must be supported.<para/>
        /// Note that an object may be indexable in different domains by different types (e.g.: indexable via both ordinals and strings).<para/>
        /// Some indexers are read-only. In such cases, E_NOTIMPL will be returned from any call to the SetAt method.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) which is being indexed is passed here.</param>
        /// <param name="indexerCount">The number of dimensions that the object is being indexed in.</param>
        /// <param name="indexers">An array (sized according to the indexerCount) of indicies indicating where inside the instance object to access.</param>
        /// <param name="value">The value of the element to assign at the specified indicies.</param>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public void SetAt(IModelObject contextObject, long indexerCount, IModelObject[] indexers, IModelObject value)
        {
            TrySetAt(contextObject, indexerCount, indexers, value).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetAt method attempts to set the value at a particular N-dimensional index from within the indexed object. An indexer of N-dimensions where N is the value returned from GetDimensionality must be supported.<para/>
        /// Note that an object may be indexable in different domains by different types (e.g.: indexable via both ordinals and strings).<para/>
        /// Some indexers are read-only. In such cases, E_NOTIMPL will be returned from any call to the SetAt method.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) which is being indexed is passed here.</param>
        /// <param name="indexerCount">The number of dimensions that the object is being indexed in.</param>
        /// <param name="indexers">An array (sized according to the indexerCount) of indicies indicating where inside the instance object to access.</param>
        /// <param name="value">The value of the element to assign at the specified indicies.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public HRESULT TrySetAt(IModelObject contextObject, long indexerCount, IModelObject[] indexers, IModelObject value)
        {
            /*HRESULT SetAt(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In] long indexerCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject value);*/
            return Raw.SetAt(contextObject, indexerCount, indexers, value);
        }

        #endregion
        #endregion
    }
}
