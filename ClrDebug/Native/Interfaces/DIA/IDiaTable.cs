using System.Runtime.InteropServices;
#if GENERATED_MARSHALLING
using System.Runtime.InteropServices.Marshalling;
#endif

namespace ClrDebug.DIA
{
    /// <summary>
    /// Enumerates a DIA data source table.
    /// </summary>
    /// <remarks>
    /// This interface implements the IEnumUnknown enumeration methods in the Microsoft.VisualStudio.OLE.Interop namespace.
    /// The IEnumUnknown enumeration interface is much more efficient for iterating over the table contents than the IDiaTable
    /// and IDiaTable methods. The interpretation of the IUnknown interface returned from either the IDiaTable::Item method
    /// or the Next method (in the Microsoft.VisualStudio.OLE.Interop namespace) is dependent on the type of table. For
    /// example, if the IDiaTable interface represents a list of injected sources, the IUnknown interface should be queried
    /// for the IDiaInjectedSource interface. Obtain this interface by calling the IDiaEnumTables or IDiaEnumTables methods.
    /// The following interfaces are implemented with the IDiaTable interface (that is, you can query the IDiaTable interface
    /// for one of the following interfaces):
    /// </remarks>
    [Guid("4A59FB77-ABAC-469B-A30B-9ECC85BFEF14")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
#if !GENERATED_MARSHALLING
    [ComImport]
#else
    [GeneratedComInterface]
#endif
    public partial interface IDiaTable : IEnumUnknown
    {
#if !GENERATED_MARSHALLING
        [PreserveSig]
        new HRESULT Next(
            [In] int celt,
            [Out, MarshalAs(UnmanagedType.Interface)] out object rgelt,
            [Out] out int pceltFetched);

        [PreserveSig]
        new HRESULT Skip(
            [In] int celt);

        [PreserveSig]
        new HRESULT Reset();

        [PreserveSig]
        new HRESULT Clone(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumUnknown ppenum);
#endif

        /// <summary>
        /// Retrieves the <see cref="IEnumVARIANT"/> version of this enumerator.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the IUnknown interface that represents the <see cref="IEnumVARIANT"/> version of this enumerator.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get__NewEnum(
            [Out, MarshalAs(UnmanagedType.Interface)] out IEnumVARIANT pRetVal);

        /// <summary>
        /// Retrieves the name of the table.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the name of the table.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_name(
            [Out, MarshalAs(UnmanagedType.BStr)] out string pRetVal);

        /// <summary>
        /// Retrieves the number of items in the table.
        /// </summary>
        /// <param name="pRetVal">[out] Returns the number of items in the table.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        [PreserveSig]
        HRESULT get_count(
            [Out] out int pRetVal);

        /// <summary>
        /// Retrieves a reference to the specified entry in the table.
        /// </summary>
        /// <param name="index">[in] The index of the table entry in the range 0 to count-1, where count is returned by the IDiaTablemethod.</param>
        /// <param name="element">[out] Returns an IUnknown object that represents the specified table entry.</param>
        /// <returns>If successful, returns S_OK; otherwise, returns an error code.</returns>
        /// <remarks>
        /// A table represents a collection of objects. Depending on those objects, the element parameter can be cast to the
        /// appropriate interface. For example, if a table contains IDiaSegment objects, then the element parameter can be
        /// cast to the IDiaSegment interface. It is a more common approach to call the QueryInterface method in the IDiaTable
        /// interface for the appropriate enumerator interface and use the enumerator's specific methods to access the table
        /// contents. See the IDiaEnumInjectedSources interface for an example.
        /// </remarks>
        [PreserveSig]
        HRESULT Item(
            [In] int index,
            [Out, MarshalAs(UnmanagedType.Interface)] out object element);
    }
}
