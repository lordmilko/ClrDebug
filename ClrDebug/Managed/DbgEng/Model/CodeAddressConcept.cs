namespace ClrDebug.DbgEng
{
    public class CodeAddressConcept : ComObject<ICodeAddressConcept>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeAddressConcept"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CodeAddressConcept(ICodeAddressConcept raw) : base(raw)
        {
        }

        #region ICodeAddressConcept
        #region GetContainingSymbol

        public DebugHostSymbol GetContainingSymbol(IModelObject pContextObject)
        {
            DebugHostSymbol ppSymbolResult;
            TryGetContainingSymbol(pContextObject, out ppSymbolResult).ThrowDbgEngNotOK();

            return ppSymbolResult;
        }

        public HRESULT TryGetContainingSymbol(IModelObject pContextObject, out DebugHostSymbol ppSymbolResult)
        {
            /*HRESULT GetContainingSymbol(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pContextObject,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbol ppSymbol);*/
            IDebugHostSymbol ppSymbol;
            HRESULT hr = Raw.GetContainingSymbol(pContextObject, out ppSymbol);

            if (hr == HRESULT.S_OK)
                ppSymbolResult = DebugHostSymbol.New(ppSymbol);
            else
                ppSymbolResult = default(DebugHostSymbol);

            return hr;
        }

        #endregion
        #endregion
    }
}
