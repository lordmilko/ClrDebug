namespace ClrDebug.DbgEng
{
    public class SvcSymbolInfo : ComObject<ISvcSymbolInfo>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolInfo"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolInfo(ISvcSymbolInfo raw) : base(raw)
        {
        }

        #region ISvcSymbolInfo
        #region Type

        public SvcSymbol Type
        {
            get
            {
                SvcSymbol symbolTypeResult;
                TryGetType(out symbolTypeResult).ThrowDbgEngNotOK();

                return symbolTypeResult;
            }
        }

        public HRESULT TryGetType(out SvcSymbol symbolTypeResult)
        {
            /*HRESULT GetType(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol symbolType);*/
            ISvcSymbol symbolType;
            HRESULT hr = Raw.GetType(out symbolType);

            if (hr == HRESULT.S_OK)
                symbolTypeResult = symbolType == null ? null : new SvcSymbol(symbolType);
            else
                symbolTypeResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #region Location

        public SvcSymbolLocation Location
        {
            get
            {
                SvcSymbolLocation pLocation;
                TryGetLocation(out pLocation).ThrowDbgEngNotOK();

                return pLocation;
            }
        }

        public HRESULT TryGetLocation(out SvcSymbolLocation pLocation)
        {
            /*HRESULT GetLocation(
            [Out] out SvcSymbolLocation pLocation);*/
            return Raw.GetLocation(out pLocation);
        }

        #endregion
        #region Value

        public object Value
        {
            get
            {
                object pValue;
                TryGetValue(out pValue).ThrowDbgEngNotOK();

                return pValue;
            }
        }

        public HRESULT TryGetValue(out object pValue)
        {
            /*HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pValue);*/
            return Raw.GetValue(out pValue);
        }

        #endregion
        #region GetAttribute

        public object GetAttribute(SvcSymbolAttribute attr)
        {
            object pAttributeValue;
            TryGetAttribute(attr, out pAttributeValue).ThrowDbgEngNotOK();

            return pAttributeValue;
        }

        public HRESULT TryGetAttribute(SvcSymbolAttribute attr, out object pAttributeValue)
        {
            /*HRESULT GetAttribute(
            [In] SvcSymbolAttribute attr,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pAttributeValue);*/
            return Raw.GetAttribute(attr, out pAttributeValue);
        }

        #endregion
        #endregion
    }
}
