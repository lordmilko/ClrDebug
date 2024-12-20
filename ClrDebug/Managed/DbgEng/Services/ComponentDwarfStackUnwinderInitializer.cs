namespace ClrDebug.DbgEng
{
    public class ComponentDwarfStackUnwinderInitializer : ComObject<IComponentDwarfStackUnwinderInitializer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentDwarfStackUnwinderInitializer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComponentDwarfStackUnwinderInitializer(IComponentDwarfStackUnwinderInitializer raw) : base(raw)
        {
        }

        #region IComponentDwarfStackUnwinderInitializer
        #region Initialize

        /// <summary>
        /// Initializes the DEBUG_COMPONENT_DWARF_STACK_UNWINDER component. It takes an optional stack unwinder which can be used as a fallback by the DWARF stack unwinder.<para/>
        /// (This is used for ARM targets atm.).
        /// </summary>
        public void Initialize(ISvcStackFrameUnwind pSecondaryUnwinder)
        {
            TryInitialize(pSecondaryUnwinder).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the DEBUG_COMPONENT_DWARF_STACK_UNWINDER component. It takes an optional stack unwinder which can be used as a fallback by the DWARF stack unwinder.<para/>
        /// (This is used for ARM targets atm.).
        /// </summary>
        public HRESULT TryInitialize(ISvcStackFrameUnwind pSecondaryUnwinder)
        {
            /*HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcStackFrameUnwind pSecondaryUnwinder);*/
            return Raw.Initialize(pSecondaryUnwinder);
        }

        #endregion
        #endregion
    }
}
