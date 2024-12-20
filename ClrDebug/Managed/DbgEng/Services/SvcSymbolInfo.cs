namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Any symbol which is typed, has type information, or more advanced location capability (other than a simple linear offset within the image) supports this interface.<para/>
    /// Simple symbol providers which only do basic address -&gt; name and name -&gt; address mapping need not implement this interface.
    /// </summary>
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

        /// <summary>
        /// Gets the type of the symbol.
        /// </summary>
        public SvcSymbol Type
        {
            get
            {
                SvcSymbol symbolTypeResult;
                TryGetType(out symbolTypeResult).ThrowDbgEngNotOK();

                return symbolTypeResult;
            }
        }

        /// <summary>
        /// Gets the type of the symbol.
        /// </summary>
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

        /// <summary>
        /// Gets the location of the symbol.
        /// </summary>
        public SvcSymbolLocation Location
        {
            get
            {
                SvcSymbolLocation pLocation;
                TryGetLocation(out pLocation).ThrowDbgEngNotOK();

                return pLocation;
            }
        }

        /// <summary>
        /// Gets the location of the symbol.
        /// </summary>
        public HRESULT TryGetLocation(out SvcSymbolLocation pLocation)
        {
            /*HRESULT GetLocation(
            [Out] out SvcSymbolLocation pLocation);*/
            return Raw.GetLocation(out pLocation);
        }

        #endregion
        #region Value

        /// <summary>
        /// Gets the value of a constant value symbol. GetLocation will return an indication that the symbol has a constant value.<para/>
        /// If this method is called on a symbol without a constant value, it will fail.
        /// </summary>
        public object Value
        {
            get
            {
                object pValue;
                TryGetValue(out pValue).ThrowDbgEngNotOK();

                return pValue;
            }
        }

        /// <summary>
        /// Gets the value of a constant value symbol. GetLocation will return an indication that the symbol has a constant value.<para/>
        /// If this method is called on a symbol without a constant value, it will fail.
        /// </summary>
        public HRESULT TryGetValue(out object pValue)
        {
            /*HRESULT GetValue(
            [Out, MarshalAs(UnmanagedType.Struct)] out object pValue);*/
            return Raw.GetValue(out pValue);
        }

        #endregion
        #region GetAttribute

        /// <summary>
        /// Gets a simple attribute of the symbol. The type of a given attribute is defined by the attribute itself. If the symbol cannot logically provide a value for the attribute, E_NOT_SET should be returned.<para/>
        /// If the provider does not implement the attribute for any symbol, E_NOTIMPL should be returned.
        /// </summary>
        public object GetAttribute(SvcSymbolAttribute attr)
        {
            object pAttributeValue;
            TryGetAttribute(attr, out pAttributeValue).ThrowDbgEngNotOK();

            return pAttributeValue;
        }

        /// <summary>
        /// Gets a simple attribute of the symbol. The type of a given attribute is defined by the attribute itself. If the symbol cannot logically provide a value for the attribute, E_NOT_SET should be returned.<para/>
        /// If the provider does not implement the attribute for any symbol, E_NOTIMPL should be returned.
        /// </summary>
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
