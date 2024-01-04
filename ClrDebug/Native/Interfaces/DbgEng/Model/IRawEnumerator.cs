using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface which enumerates the raw children (e.g.: base classes, fields, etc...) of an object (and their values and associated metadata).<para/>
    /// A raw enumerator can be acquired through the EnumerateRawValues or EnumerateRawReferences methods on <see cref="IModelObject"/>.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("E13613F9-3A3C-40B5-8F48-1E5EBFB9B21B")]
    [ComImport]
    public interface IRawEnumerator
    {
        /// <summary>
        /// Resets the enumerator to its initial state. A subsequent GetNext call will return the first raw element (native field, base class, etc...) in enumerator order.
        /// </summary>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT Reset();

        /// <summary>
        /// Moves the iterator forward and fetches the name of the raw element and, optionally, its value (or a reference to it) and what kind of element it is.<para/>
        /// Note that depending on how this enumerator was acquired, the object returned in the value field may be the value of the raw element (EnumerateRawValues) or a reference to the raw element (EnumerateRawReferences).<para/>
        /// If there was an error in reading the value of the raw element (for EnumerateRawValues, for instance), the method may return an error AND fill value with an error object.<para/>
        /// When the enumerator hits the end of the sequence, E_BOUNDS will be returned.
        /// </summary>
        /// <param name="name">The name of the raw element (e.g.: field) being enumerated is returned here. The caller is responsible for freeing this string with the SysFreeString method.</param>
        /// <param name="kind">The kind of symbol being enumerated (e.g.: a type, field, base class, etc…) is returned here.</param>
        /// <param name="value">The value of the raw element (e.g.: field) being enumerated is optionally returned here. Depending on how the enumerator was acquired, this value may be the actual value of the raw element (EnumerateRawValues) or a reference to it (EnumerateRawReferences).</param>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name,
            [Out] out SymbolKind kind,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject value);
    }
}
