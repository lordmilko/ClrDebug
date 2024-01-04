namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The object is a container and can be iterated.
    /// </summary>
    public class IterableConcept : ComObject<IIterableConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IterableConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public IterableConcept(IIterableConcept raw) : base(raw)
        {
        }

        #region IIterableConcept
        #region GetDefaultIndexDimensionality

        /// <summary>
        /// The GetDefaultIndexDimensionality method returns the number of dimensions to the default index. If an object is not indexable, this method should return 0 and succeed (S_OK).<para/>
        /// Any object which returns a non-zero value from this method is declaring support for a protocol contract which states:
        /// </summary>
        /// <param name="contextObject">The instance (this pointer) being queried.</param>
        /// <returns>The number of dimensions of the default indexer is returned here. A return value of zero indicates that the object is not indexable.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public long GetDefaultIndexDimensionality(IModelObject contextObject)
        {
            long dimensionality;
            TryGetDefaultIndexDimensionality(contextObject, out dimensionality).ThrowDbgEngNotOK();

            return dimensionality;
        }

        /// <summary>
        /// The GetDefaultIndexDimensionality method returns the number of dimensions to the default index. If an object is not indexable, this method should return 0 and succeed (S_OK).<para/>
        /// Any object which returns a non-zero value from this method is declaring support for a protocol contract which states:
        /// </summary>
        /// <param name="contextObject">The instance (this pointer) being queried.</param>
        /// <param name="dimensionality">The number of dimensions of the default indexer is returned here. A return value of zero indicates that the object is not indexable.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public HRESULT TryGetDefaultIndexDimensionality(IModelObject contextObject, out long dimensionality)
        {
            /*HRESULT GetDefaultIndexDimensionality(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out] out long dimensionality);*/
            return Raw.GetDefaultIndexDimensionality(contextObject, out dimensionality);
        }

        #endregion
        #region GetIterator

        /// <summary>
        /// The GetIterator method on the iterable concept returns an iterator interface which can be used to iterate the object.<para/>
        /// The returned iterator must remember the context object that was passed to the GetIterator method. It will not be passed to methods on the iterator itself.
        /// </summary>
        /// <param name="contextObject">The instance (this pointer) for which to acquire an iterator.</param>
        /// <returns>An implementation of <see cref="IModelIterator"/> which iterates the instance object is returned here.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public ModelIterator GetIterator(IModelObject contextObject)
        {
            ModelIterator iteratorResult;
            TryGetIterator(contextObject, out iteratorResult).ThrowDbgEngNotOK();

            return iteratorResult;
        }

        /// <summary>
        /// The GetIterator method on the iterable concept returns an iterator interface which can be used to iterate the object.<para/>
        /// The returned iterator must remember the context object that was passed to the GetIterator method. It will not be passed to methods on the iterator itself.
        /// </summary>
        /// <param name="contextObject">The instance (this pointer) for which to acquire an iterator.</param>
        /// <param name="iteratorResult">An implementation of <see cref="IModelIterator"/> which iterates the instance object is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        public HRESULT TryGetIterator(IModelObject contextObject, out ModelIterator iteratorResult)
        {
            /*HRESULT GetIterator(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelIterator iterator);*/
            IModelIterator iterator;
            HRESULT hr = Raw.GetIterator(contextObject, out iterator);

            if (hr == HRESULT.S_OK)
                iteratorResult = iterator == null ? null : new ModelIterator(iterator);
            else
                iteratorResult = default(ModelIterator);

            return hr;
        }

        #endregion
        #endregion
    }
}
