namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The core interface to the underlying debugger.
    /// </summary>
    public class DebugHost : ComObject<IDebugHost>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHost"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHost(IDebugHost raw) : base(raw)
        {
        }

        #region IDebugHost
        #region HostDefinedInterface

        /// <summary>
        /// The GetHostDefinedInterface method returns the host's main private interface, if such exists for the given host.<para/>
        /// For Debugging Tools for Windows, the interface returned here is an IDebugClient (cast to IUnknown).
        /// </summary>
        public object HostDefinedInterface
        {
            get
            {
                object hostUnk;
                TryGetHostDefinedInterface(out hostUnk).ThrowDbgEngNotOK();

                return hostUnk;
            }
        }

        /// <summary>
        /// The GetHostDefinedInterface method returns the host's main private interface, if such exists for the given host.<para/>
        /// For Debugging Tools for Windows, the interface returned here is an IDebugClient (cast to IUnknown).
        /// </summary>
        /// <param name="hostUnk">The debug host's core private interface is returned here. For Debugging Tools for Windows, this is an IDebugClient interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure. A host which does not have a private interface that it wishes to expose to data model clients may return E_NOTIMPL here.</returns>
        public HRESULT TryGetHostDefinedInterface(out object hostUnk)
        {
            /*HRESULT GetHostDefinedInterface(
            [Out, MarshalAs(UnmanagedType.Interface)] out object hostUnk);*/
            return Raw.GetHostDefinedInterface(out hostUnk);
        }

        #endregion
        #region CurrentContext

        /// <summary>
        /// The GetCurrentContext method returns an interface which represents the current state of the debugger host. The exact meaning of this is left up to the host, but it typically includes things such as the session, process, and address space that is active in the user interface of the debug host.<para/>
        /// The returned context object is largely opaque to the caller but it is an important object to pass between calls to the debug host.<para/>
        /// When a caller is, for instance, reading memory, it is important to know which process and address space that memory is being read from.<para/>
        /// That notion is encapsulated in the notion of the context object which is returned from this method. Every object and symbol in the data model optionally has context information such as this associated with it.<para/>
        /// It is also often typical that context is passed from one object to new objects created as properties of existing ones.<para/>
        /// Such objects which are created by the debug host itself may cause additional context information to be embedded within the returned object (e.g.: the Stack property of a thread may embed information about which thread the stack refers to within the context).
        /// </summary>
        public DebugHostContext CurrentContext
        {
            get
            {
                DebugHostContext contextResult;
                TryGetCurrentContext(out contextResult).ThrowDbgEngNotOK();

                return contextResult;
            }
        }

        /// <summary>
        /// The GetCurrentContext method returns an interface which represents the current state of the debugger host. The exact meaning of this is left up to the host, but it typically includes things such as the session, process, and address space that is active in the user interface of the debug host.<para/>
        /// The returned context object is largely opaque to the caller but it is an important object to pass between calls to the debug host.<para/>
        /// When a caller is, for instance, reading memory, it is important to know which process and address space that memory is being read from.<para/>
        /// That notion is encapsulated in the notion of the context object which is returned from this method. Every object and symbol in the data model optionally has context information such as this associated with it.<para/>
        /// It is also often typical that context is passed from one object to new objects created as properties of existing ones.<para/>
        /// Such objects which are created by the debug host itself may cause additional context information to be embedded within the returned object (e.g.: the Stack property of a thread may embed information about which thread the stack refers to within the context).
        /// </summary>
        /// <param name="contextResult">An object representing the current context of the host is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure. A host which does not have a concept of context information may return E_NOTIMPL here.</returns>
        public HRESULT TryGetCurrentContext(out DebugHostContext contextResult)
        {
            /*HRESULT GetCurrentContext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostContext context);*/
            IDebugHostContext context;
            HRESULT hr = Raw.GetCurrentContext(out context);

            if (hr == HRESULT.S_OK)
                contextResult = context == null ? null : new DebugHostContext(context);
            else
                contextResult = default(DebugHostContext);

            return hr;
        }

        #endregion
        #region DefaultMetadata

        /// <summary>
        /// The GetDefaultMetadata method returns a default metadata store that may be used for certain operations (e.g.: string conversion) when no explicit metadata has been passed.<para/>
        /// This allows the debug host to have some control over the way some data is presented. For example, the default metadata may include a PreferredRadix key, allowing the host to indicate whether ordinals should be displayed in decimal or hexadecimal if not otherwise specified.<para/>
        /// Note that property values on the default metadata store must be manually resolved and must pass the object for which the default metadata is being queried.<para/>
        /// The GetKey method should be used in lieu of GetKeyValue.
        /// </summary>
        public KeyStore DefaultMetadata
        {
            get
            {
                KeyStore defaultMetadataStoreResult;
                TryGetDefaultMetadata(out defaultMetadataStoreResult).ThrowDbgEngNotOK();

                return defaultMetadataStoreResult;
            }
        }

        /// <summary>
        /// The GetDefaultMetadata method returns a default metadata store that may be used for certain operations (e.g.: string conversion) when no explicit metadata has been passed.<para/>
        /// This allows the debug host to have some control over the way some data is presented. For example, the default metadata may include a PreferredRadix key, allowing the host to indicate whether ordinals should be displayed in decimal or hexadecimal if not otherwise specified.<para/>
        /// Note that property values on the default metadata store must be manually resolved and must pass the object for which the default metadata is being queried.<para/>
        /// The GetKey method should be used in lieu of GetKeyValue.
        /// </summary>
        /// <param name="defaultMetadataStoreResult">The debug host's default metadata store is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        /// <remarks>
        /// Usage Example (typically called by the data model itself): Implementation Example (a host would normally do this):
        /// </remarks>
        public HRESULT TryGetDefaultMetadata(out KeyStore defaultMetadataStoreResult)
        {
            /*HRESULT GetDefaultMetadata(
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore defaultMetadataStore);*/
            IKeyStore defaultMetadataStore;
            HRESULT hr = Raw.GetDefaultMetadata(out defaultMetadataStore);

            if (hr == HRESULT.S_OK)
                defaultMetadataStoreResult = defaultMetadataStore == null ? null : new KeyStore(defaultMetadataStore);
            else
                defaultMetadataStoreResult = default(KeyStore);

            return hr;
        }

        #endregion
        #endregion
    }
}
