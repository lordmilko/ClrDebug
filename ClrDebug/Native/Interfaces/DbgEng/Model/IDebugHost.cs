using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The core interface to the underlying debugger.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B8C74943-6B2C-4EEB-B5C5-35D378A6D99D")]
    [ComImport]
    public interface IDebugHost
    {
        /// <summary>
        /// The GetHostDefinedInterface method returns the host's main private interface, if such exists for the given host.<para/>
        /// For Debugging Tools for Windows, the interface returned here is an IDebugClient (cast to IUnknown).
        /// </summary>
        /// <param name="hostUnk">The debug host's core private interface is returned here. For Debugging Tools for Windows, this is an IDebugClient interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. A host which does not have a private interface that it wishes to expose to data model clients may return E_NOTIMPL here.</returns>
        [PreserveSig]
        HRESULT GetHostDefinedInterface(
            [Out, MarshalAs(UnmanagedType.Interface)] out object hostUnk);

        /// <summary>
        /// The GetCurrentContext method returns an interface which represents the current state of the debugger host. The exact meaning of this is left up to the host, but it typically includes things such as the session, process, and address space that is active in the user interface of the debug host.<para/>
        /// The returned context object is largely opaque to the caller but it is an important object to pass between calls to the debug host.<para/>
        /// When a caller is, for instance, reading memory, it is important to know which process and address space that memory is being read from.<para/>
        /// That notion is encapsulated in the notion of the context object which is returned from this method. Every object and symbol in the data model optionally has context information such as this associated with it.<para/>
        /// It is also often typical that context is passed from one object to new objects created as properties of existing ones.<para/>
        /// Such objects which are created by the debug host itself may cause additional context information to be embedded within the returned object (e.g.: the Stack property of a thread may embed information about which thread the stack refers to within the context).
        /// </summary>
        /// <param name="context">An object representing the current context of the host is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure. A host which does not have a concept of context information may return E_NOTIMPL here.</returns>
        [PreserveSig]
        HRESULT GetCurrentContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);

        /// <summary>
        /// The GetDefaultMetadata method returns a default metadata store that may be used for certain operations (e.g.: string conversion) when no explicit metadata has been passed.<para/>
        /// This allows the debug host to have some control over the way some data is presented. For example, the default metadata may include a PreferredRadix key, allowing the host to indicate whether ordinals should be displayed in decimal or hexadecimal if not otherwise specified.<para/>
        /// Note that property values on the default metadata store must be manually resolved and must pass the object for which the default metadata is being queried.<para/>
        /// The GetKey method should be used in lieu of GetKeyValue.
        /// </summary>
        /// <param name="defaultMetadataStore">The debug host's default metadata store is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// Usage Example (typically called by the data model itself): Implementation Example (a host would normally do this):
        /// </remarks>
        [PreserveSig]
        HRESULT GetDefaultMetadata(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore defaultMetadataStore);
    }
}
