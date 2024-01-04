using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The object is a container and can be iterated.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("F5D49D0C-0B02-4301-9C9B-B3A6037628F3")]
    [ComImport]
    public interface IIterableConcept
    {
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
        [PreserveSig]
        HRESULT GetDefaultIndexDimensionality(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out] out long dimensionality);

        /// <summary>
        /// The GetIterator method on the iterable concept returns an iterator interface which can be used to iterate the object.<para/>
        /// The returned iterator must remember the context object that was passed to the GetIterator method. It will not be passed to methods on the iterator itself.
        /// </summary>
        /// <param name="contextObject">The instance (this pointer) for which to acquire an iterator.</param>
        /// <param name="iterator">An implementation of <see cref="IModelIterator"/> which iterates the instance object is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        /// <remarks>
        /// Example Implementation:
        /// </remarks>
        [PreserveSig]
        HRESULT GetIterator(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject contextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelIterator iterator);
    }
}
