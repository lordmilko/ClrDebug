namespace ClrDebug.DbgEng
{
    public class ComponentImageBackedVirtualMemoryInitializer : ComObject<IComponentImageBackedVirtualMemoryInitializer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentImageBackedVirtualMemoryInitializer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComponentImageBackedVirtualMemoryInitializer(IComponentImageBackedVirtualMemoryInitializer raw) : base(raw)
        {
        }

        #region IComponentImageBackedVirtualMemoryInitializer
        #region Initialize

        /// <summary>
        /// Initializes the image backed virtual memory service with an underlying virtual memory service. The given service must support ISvcMemoryAccess and *SHOULD* implement ISvcMemoryInformation.<para/>
        /// If the underlying service does not support ISvcMemoryInformation, the image backed virtual memory service will operate in pass through mode only.<para/>
        /// If no pUnderlyingVirtualMemoryService is provided as 'nullptr' or the initializer is not called before the component is inserted into the service container, it will stack on top of whatever virtual memory service is already in the service container.<para/>
        /// 'projectNonFileMappedBytesAsZero' indicates whether bytes attributable to the image which are not contained in the underlying virtual memory service *OR* the image file itself should be provided by this service.<para/>
        /// Such bytes would be things which are zero initialized (or uninitialized) but allocated by a loader (e.g.: the .bss segment).
        /// </summary>
        public void Initialize(IDebugServiceLayer pUnderlyingVirtualMemoryService, bool projectNonFileMappedBytes)
        {
            TryInitialize(pUnderlyingVirtualMemoryService, projectNonFileMappedBytes).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the image backed virtual memory service with an underlying virtual memory service. The given service must support ISvcMemoryAccess and *SHOULD* implement ISvcMemoryInformation.<para/>
        /// If the underlying service does not support ISvcMemoryInformation, the image backed virtual memory service will operate in pass through mode only.<para/>
        /// If no pUnderlyingVirtualMemoryService is provided as 'nullptr' or the initializer is not called before the component is inserted into the service container, it will stack on top of whatever virtual memory service is already in the service container.<para/>
        /// 'projectNonFileMappedBytesAsZero' indicates whether bytes attributable to the image which are not contained in the underlying virtual memory service *OR* the image file itself should be provided by this service.<para/>
        /// Such bytes would be things which are zero initialized (or uninitialized) but allocated by a loader (e.g.: the .bss segment).
        /// </summary>
        public HRESULT TryInitialize(IDebugServiceLayer pUnderlyingVirtualMemoryService, bool projectNonFileMappedBytes)
        {
            /*HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceLayer pUnderlyingVirtualMemoryService,
            [In, MarshalAs(UnmanagedType.U1)] bool projectNonFileMappedBytes);*/
            return Raw.Initialize(pUnderlyingVirtualMemoryService, projectNonFileMappedBytes);
        }

        #endregion
        #endregion
    }
}
