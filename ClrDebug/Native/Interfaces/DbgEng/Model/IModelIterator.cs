using System.Runtime.InteropServices;
using SRI = System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An iterator of contained objects (client implemented and returned by <see cref="IIterableConcept"/>).
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E4622136-927D-4490-874F-581F3E4E3688")]
    [ComImport]
    public interface IModelIterator
    {
        /// <summary>
        /// The Reset method on an iterator returned from the iterable concept will restore the position of the iterator to where it was when the iterator was first created (before the first element).<para/>
        /// While it is strongly recommended that iterator's support the Reset method, it is not required. An iterator can be the equivalent of a C++ input iterator and only allow a single pass of forward iteration.<para/>
        /// In such case, the Reset method may fail with E_NOTIMPL.
        /// </summary>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// The GetNext method moves the iterator forward and fetches the next iterated element. If the object is indexable in addition to being iterable and this is indicated by the GetDefaultIndexDimensionality argument returning a non-zero value, this method may optionally return the default indicies to get back to the produced value from the indexer.<para/>
        /// Note that a caller may choose to pass 0/nullptr and not retrieve any indicies. It is considered illegal for the caller to request partial indicies (e.g.: less than the number produced by GetDefaultIndexDimensionality).<para/>
        /// If the iterator moved forward successfully but there was an error in reading the value of the iterated element, the method may return an error AND fill "object" with an error object.At the end of iteration of the contained elements, the iterator will return E_BOUNDS from the GetNext method.<para/>
        /// Any subsequent call (unless there has been an intervening Reset call) will also return E_BOUNDS.
        /// </summary>
        /// <param name="object">The object produced from the iterator is returned here.</param>
        /// <param name="dimensions">The number of dimensions of the default index that the caller is requesting. If this is zero, the caller does not wish the default index returned.<para/>
        /// If it is non-zero, it should be at least as high as the default index's dimensionality.</param>
        /// <param name="indexers">A buffer of size dimensions which will be filled in with the default indicies to get back to the returned element from the indexer.</param>
        /// <param name="metadata">If there is any metadata associated with the iterated element, it is returned (optionally) in this argument.</param>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject @object,
            [In] long dimensions,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 1)] IModelObject[] indexers,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
    }
}
