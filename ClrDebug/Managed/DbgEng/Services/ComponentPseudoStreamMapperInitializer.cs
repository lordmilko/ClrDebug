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

        /// <summary>
        /// Initializes the component.
        /// </summary>
        public void Initialize(ISvcDebugSourceFile pUnderlyingFile)
        {
            TryInitialize(pUnderlyingFile).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the component.
        /// </summary>
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
