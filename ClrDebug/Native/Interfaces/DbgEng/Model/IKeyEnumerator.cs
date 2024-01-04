using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator which runs through keys on an object.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("345FA92E-5E00-4319-9CAE-971F7601CDCF")]
    [ComImport]
    public interface IKeyEnumerator
    {
        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first key in enumerator order.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Moves the iterator forward and fetches the name of the next key and, optionally, its value (or a reference to it) and associated metadata.<para/>
        /// Note that depending on how this enumerator was acquired, the object returned in the value field may be the value associated with the key (EnumerateKeys), the resolved value of any property that the key refers to (EnumerateKeyValues), or a reference to the key (EnumerateKeyReferences).<para/>
        /// If there was an error in resolving the value of the key (for EnumerateKeyValues, for instance), the method may return an error AND fill value with an error object.<para/>
        /// When the enumerator hits the end of the sequence, E_BOUNDS will be returned.
        /// </summary>
        /// <param name="key">The name of the key being enumerated is returned here. The caller is responsible for freeing this string with the SysFreeString method.</param>
        /// <param name="value">The value of the key being enumerated is returned here. Depending on how the enumerator was acquired, this value may be the value associated with the key (EnumerateKeys), the resolved value of any property that the key refers to (EnumerateKeyValues), or a reference to the key (EnumerateKeyReferences).</param>
        /// <param name="metadata">Any metadata associated with the key is optionally returned in this argument.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string key,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
    }
}
