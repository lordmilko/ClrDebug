namespace ClrDebug.DbgEng
{
    public class ComponentPseudoStreamMapperInitializer : ComObject<IComponentPseudoStreamMapperInitializer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentPseudoStreamMapperInitializer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComponentPseudoStreamMapperInitializer(IComponentPseudoStreamMapperInitializer raw) : base(raw)
        {
        }

        #region IComponentPseudoStreamMapperInitializer
        #region Initialize

        public void Initialize(ISvcDebugSourceFile pUnderlyingFile)
        {
            TryInitialize(pUnderlyingFile).ThrowDbgEngNotOK();
        }

        public HRESULT TryInitialize(ISvcDebugSourceFile pUnderlyingFile)
        {
            /*HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcDebugSourceFile pUnderlyingFile);*/
            return Raw.Initialize(pUnderlyingFile);
        }

        #endregion
        #endregion
    }
}
