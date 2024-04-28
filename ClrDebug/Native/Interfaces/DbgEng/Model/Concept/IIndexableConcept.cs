using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any object which is a container that supports random access retrieval of elements from given N-dimensional indexers implements this concept.<para/>
    /// It is legal for an object to be indexable (via support of IIndexableConcept) and not iterable (via lack of support for <see cref="IIterableConcept"/>).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D1FAD99F-3F53-4457-850C-8051DF2D3FB5")]
    [ComImport]
    public interface IIndexableConcept
    {
        /// <summary>
        /// The GetDimensionality method returns the number of dimensions that the object is indexed in. Note that if the object is both iterable and indexable, the implementation of GetDefaultIndexDimensionality must agree with the implementation of GetDimensionality as to how many dimensions the indexer has.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) which is being indexed is passed here.</param>
        /// <param name="dimensionality">The number of dimensions that the object is indexed in is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        [PreserveSig]
        HRESULT GetDimensionality(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out] out long dimensionality);

        /// <summary>
        /// The GetAt method retrieves the value at a particular N-dimensional index from within the indexed object. An indexer of N-dimensions where N is the value returned from GetDimensionality must be supported.<para/>
        /// Note that an object may be indexable in different domains by different types (e.g.: indexable via both ordinals and strings).<para/>
        /// If the index is out of range (or could not be accessed), the method will return a failure; however, in such cases, the output object may still be set to an error object.
        /// </summary>
        /// <param name="contextObject">The instance object (this pointer) which is being indexed is passed here.</param>
        /// <param name="indexerCount">The number of dimensions that the object is being indexed in.</param>
        /// <param name="indexers">An array (sized according to the indexerCount) of indicies indicating where inside the instance object to access.</param>
        /// <param name="object">The value of the element at the specified indicies is returned here. If the method fails, extended error information may be returned here as an error object.</param>
        /// <param name="metadata">Optional metadata about the indexed element may be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        [PreserveSig]
        HRESULT GetAt(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In] long indexerCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

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
        [PreserveSig]
        HRESULT SetAt(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [In] long indexerCount,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject value);
    }
}
