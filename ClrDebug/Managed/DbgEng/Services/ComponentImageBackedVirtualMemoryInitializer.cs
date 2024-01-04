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

        public void Initialize(IDebugServiceLayer pUnderlyingVirtualMemoryService, bool projectNonFileMappedBytes)
        {
            TryInitialize(pUnderlyingVirtualMemoryService, projectNonFileMappedBytes).ThrowDbgEngNotOK();
        }

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
