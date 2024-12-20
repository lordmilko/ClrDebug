namespace ClrDebug.DbgEng
{
    public class ComponentViewSourceInitializer : ComObject<IComponentViewSourceInitializer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentViewSourceInitializer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComponentViewSourceInitializer(IComponentViewSourceInitializer raw) : base(raw)
        {
        }

        #region IComponentViewSourceInitializer
        #region Initialize

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_VIEWSOURCE component.
        /// </summary>
        public void Initialize(IDebugServiceManager pServiceManager)
        {
            TryInitialize(pServiceManager).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the DEBUG_COMPONENTSVC_VIEWSOURCE component.
        /// </summary>
        public HRESULT TryInitialize(IDebugServiceManager pServiceManager)
        {
            /*HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager);*/
            return Raw.Initialize(pServiceManager);
        }

        #endregion
        #endregion
    }
}
