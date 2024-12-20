namespace ClrDebug.DbgEng
{
    public class SvcThreadLocalStorageProvider : ComObject<ISvcThreadLocalStorageProvider>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcThreadLocalStorageProvider"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcThreadLocalStorageProvider(ISvcThreadLocalStorageProvider raw) : base(raw)
        {
        }

        #region ISvcThreadLocalStorageProvider
        #region GetTLSBlockAddress

        /// <summary>
        /// Returns the base address of a module's TLS block for a given thread.
        /// </summary>
        public long GetTLSBlockAddress(ISvcModule pModule, ISvcThread pThread)
        {
            long pAddress;
            TryGetTLSBlockAddress(pModule, pThread, out pAddress).ThrowDbgEngNotOK();

            return pAddress;
        }

        /// <summary>
        /// Returns the base address of a module's TLS block for a given thread.
        /// </summary>
        public HRESULT TryGetTLSBlockAddress(ISvcModule pModule, ISvcThread pThread, out long pAddress)
        {
            /*HRESULT GetTLSBlockAddress(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcThread pThread,
            [Out] out long pAddress);*/
            return Raw.GetTLSBlockAddress(pModule, pThread, out pAddress);
        }

        #endregion
        #endregion
    }
}
