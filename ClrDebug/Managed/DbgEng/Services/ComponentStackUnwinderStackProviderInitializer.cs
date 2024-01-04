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

        public void Initialize(bool provideInlineFrames)
        {
            TryInitialize(provideInlineFrames).ThrowDbgEngNotOK();
        }

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
