namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An iterator of contained objects (client implemented and returned by <see cref="IIterableConcept"/>).
    /// </summary>
    public class ModelIterator : ComObject<IModelIterator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelIterator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ModelIterator(IModelIterator raw) : base(raw)
        {
        }

        #region IModelIterator
        #region Reset

        /// <summary>
        /// The Reset method on an iterator returned from the iterable concept will restore the position of the iterator to where it was when the iterator was first created (before the first element).<para/>
        /// While it is strongly recommended that iterator's support the Reset method, it is not required. An iterator can be the equivalent of a C++ input iterator and only allow a single pass of forward iteration.<para/>
        /// In such case, the Reset method may fail with E_NOTIMPL.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Reset method on an iterator returned from the iterable concept will restore the position of the iterator to where it was when the iterator was first created (before the first element).<para/>
        /// While it is strongly recommended that iterator's support the Reset method, it is not required. An iterator can be the equivalent of a C++ input iterator and only allow a single pass of forward iteration.<para/>
        /// In such case, the Reset method may fail with E_NOTIMPL.
        /// </summary>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #region GetNext

        /// <summary>
        /// The GetNext method moves the iterator forward and fetches the next iterated element. If the object is indexable in addition to being iterable and this is indicated by the GetDefaultIndexDimensionality argument returning a non-zero value, this method may optionally return the default indicies to get back to the produced value from the indexer.<para/>
        /// Note that a caller may choose to pass 0/nullptr and not retrieve any indicies. It is considered illegal for the caller to request partial indicies (e.g.: less than the number produced by GetDefaultIndexDimensionality).<para/>
        /// If the iterator moved forward successfully but there was an error in reading the value of the iterated element, the method may return an error AND fill "object" with an error object.At the end of iteration of the contained elements, the iterator will return E_BOUNDS from the GetNext method.<para/>
        /// Any subsequent call (unless there has been an intervening Reset call) will also return E_BOUNDS.
        /// </summary>
        /// <param name="dimensions">The number of dimensions of the default index that the caller is requesting. If this is zero, the caller does not wish the default index returned.<para/>
        /// If it is non-zero, it should be at least as high as the default index's dimensionality.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public ModelIterator_GetNextResult GetNext(long dimensions)
        {
            ModelIterator_GetNextResult result;
            TryGetNext(dimensions, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The GetNext method moves the iterator forward and fetches the next iterated element. If the object is indexable in addition to being iterable and this is indicated by the GetDefaultIndexDimensionality argument returning a non-zero value, this method may optionally return the default indicies to get back to the produced value from the indexer.<para/>
        /// Note that a caller may choose to pass 0/nullptr and not retrieve any indicies. It is considered illegal for the caller to request partial indicies (e.g.: less than the number produced by GetDefaultIndexDimensionality).<para/>
        /// If the iterator moved forward successfully but there was an error in reading the value of the iterated element, the method may return an error AND fill "object" with an error object.At the end of iteration of the contained elements, the iterator will return E_BOUNDS from the GetNext method.<para/>
        /// Any subsequent call (unless there has been an intervening Reset call) will also return E_BOUNDS.
        /// </summary>
        /// <param name="dimensions">The number of dimensions of the default index that the caller is requesting. If this is zero, the caller does not wish the default index returned.<para/>
        /// If it is non-zero, it should be at least as high as the default index's dimensionality.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryGetNext(long dimensions, out ModelIterator_GetNextResult result)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject @object;
            IModelObject[] indexers = new IModelObject[(int) dimensions];
            IKeyStore metadata;
            HRESULT hr = Raw.GetNext(out @object, dimensions, indexers, out metadata);

            if (hr == HRESULT.S_OK)
                result = new ModelIterator_GetNextResult(@object == null ? null : new ModelObject(@object), indexers, metadata == null ? null : new KeyStore(metadata));
            else
                result = default(ModelIterator_GetNextResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
