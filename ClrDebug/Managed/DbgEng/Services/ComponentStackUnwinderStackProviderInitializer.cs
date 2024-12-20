namespace ClrDebug.DbgEng
{
    public class ComponentStackUnwinderStackProviderInitializer : ComObject<IComponentStackUnwinderStackProviderInitializer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentStackUnwinderStackProviderInitializer"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public ComponentStackUnwinderStackProviderInitializer(IComponentStackUnwinderStackProviderInitializer raw) : base(raw)
        {
        }

        #region IComponentStackUnwinderStackProviderInitializer
        #region Initialize

        /// <summary>
        /// Initializes the stack provider. If 'provideInlineFrames' is set to true, the stack provider will directly look at symbols for each stack frame, ask about inline information at each call site, and insert inline frames into the frames provided.<para/>
        /// The default value for 'provideInlineFrames' without the initializer called is false. NOTE: The stack provider can only provide inline frames for symbol formats which are exposed through the use of a symbol provider.<para/>
        /// PDBs do not yet meet that classification.
        /// </summary>
        public void Initialize(bool provideInlineFrames)
        {
            TryInitialize(provideInlineFrames).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Initializes the stack provider. If 'provideInlineFrames' is set to true, the stack provider will directly look at symbols for each stack frame, ask about inline information at each call site, and insert inline frames into the frames provided.<para/>
        /// The default value for 'provideInlineFrames' without the initializer called is false. NOTE: The stack provider can only provide inline frames for symbol formats which are exposed through the use of a symbol provider.<para/>
        /// PDBs do not yet meet that classification.
        /// </summary>
        public HRESULT TryInitialize(bool provideInlineFrames)
        {
            /*HRESULT Initialize(
            [In, MarshalAs(UnmanagedType.U1)] bool provideInlineFrames);*/
            return Raw.Initialize(provideInlineFrames);
        }

        #endregion
        #endregion
    }
}
