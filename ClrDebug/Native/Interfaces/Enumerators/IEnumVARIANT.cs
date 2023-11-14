using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides a method for enumerating a collection of variants, including heterogeneous collections
    /// of objects and intrinsic types. Callers of this interface do not need to know the specific type
    /// (or types) of the elements in the collection.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00020404-0000-0000-C000-000000000046")]
    [ComImport]
    public interface IEnumVARIANT
    {
        /// <summary>
        /// Retrieves the specified items in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of elements to be retrieved</param>
        /// <param name="rgVar">An array of at least size celt in which the elements are to be returned.</param>
        /// <param name="pCeltFetched">The number of elements returned in rgVar, or NULL.</param>
        /// <returns>
        /// This method can return one of these values.
        /// 
        /// | HRESULT | Description                                        |
        /// | ------- | -------------------------------------------------- |
        /// | S_OK    | The number of elements returned is celt.           |
        /// | S_FALSE | The number of elements returned is less than celt. |
        /// </returns>
        [PreserveSig]
        HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Struct)] out object rgVar,
            [Out] out int pCeltFetched);

        /// <summary>
        /// Attempts to skip over the next celt elements in the enumeration sequence.
        /// </summary>
        /// <param name="celt">The number of elements to skip.</param>
        /// <returns>
        /// This method can return one of these values.
        /// 
        /// | HRESULT | Description                                                                           |
        /// | ------- | ------------------------------------------------------------------------------------- |
        /// | S_OK    | The specified number of elements was skipped.                                         |
        /// | S_FALSE | The end of the sequence was reached before skipping the requested number of elements. |
        /// </returns>
        [PreserveSig]
        HRESULT Skip(
            [In] int celt);

        /// <summary>
        /// Resets the enumeration sequence to the beginning.
        /// </summary>
        /// <returns>
        /// This method can return one of these values.
        /// 
        /// | HRESULT | Description                                                                           |
        /// | ------- | ------------------------------------------------------------------------------------- |
        /// | S_OK    | Success. |
        /// | S_FALSE | Failure. |
        /// </returns>
        /// <remarks>
        /// There is no guarantee that exactly the same set of variants will be enumerated the second time
        /// as was enumerated the first time. Although an exact duplicate is desirable, the outcome depends
        /// on the collection being enumerated. You may find that it is impractical for some collections to
        /// maintain this condition (for example, an enumeration of the files in a directory).
        /// </remarks>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Creates a copy of the current state of enumeration.
        /// </summary>
        /// <param name="ppEnum">The clone enumerator.</param>
        /// <returns>
        /// This method can return one of these values.
        /// 
        /// | HRESULT       | Description                                                                           |
        /// | ------------- | ---------------------------------------------- |
        /// | S_OK          | Success.                                       |
        /// | E_OUTOFMEMORY | Insufficient memory to complete the operation. |
        /// </returns>
        /// <remarks>
        /// Using this function, a particular point in the enumeration sequence can be recorded, and then
        /// returned to at a later time. The returned enumerator is of the same actual interface as the one
        /// that is being cloned.
        /// 
        /// There is no guarantee that exactly the same set of variants will be enumerated the second time
        /// as was enumerated the first. Although an exact duplicate is desirable, the outcome depends on
        /// the collection being enumerated. You may find that it is impractical for some collections to
        /// maintain this condition (for example, an enumeration of the files in a directory).
        /// </remarks>
        [PreserveSig]
        HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumVARIANT ppEnum);
    }
}
