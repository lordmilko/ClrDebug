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

        public void Initialize(IDebugServiceManager pServiceManager)
        {
            TryInitialize(pServiceManager).ThrowDbgEngNotOK();
        }

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
