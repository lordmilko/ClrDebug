namespace ClrDebug.DbgEng
{
    public class DebugHostSymbolsTargetComposition : ComObject<IDebugHostSymbolsTargetComposition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostSymbolsTargetComposition"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostSymbolsTargetComposition(IDebugHostSymbolsTargetComposition raw) : base(raw)
        {
        }

        #region IDebugHostSymbolsTargetComposition
        #region GetTypeForServiceType

        public DebugHostType GetTypeForServiceType(IDebugServiceManager pServiceManager, ISvcModule pModule, ISvcSymbolType pType)
        {
            DebugHostType ppHostTypeResult;
            TryGetTypeForServiceType(pServiceManager, pModule, pType, out ppHostTypeResult).ThrowDbgEngNotOK();

            return ppHostTypeResult;
        }

        public HRESULT TryGetTypeForServiceType(IDebugServiceManager pServiceManager, ISvcModule pModule, ISvcSymbolType pType, out DebugHostType ppHostTypeResult)
        {
            /*HRESULT GetTypeForServiceType(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugServiceManager pServiceManager,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcModule pModule,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbolType pType,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostType ppHostType);*/
            IDebugHostType ppHostType;
            HRESULT hr = Raw.GetTypeForServiceType(pServiceManager, pModule, pType, out ppHostType);

            if (hr == HRESULT.S_OK)
                ppHostTypeResult = ppHostType == null ? null : new DebugHostType(ppHostType);
            else
                ppHostTypeResult = default(DebugHostType);

            return hr;
        }

        #endregion
        #endregion
    }
}
