namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetTypeDerivations : ComObject<ISvcSymbolSetTypeDerivations>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetTypeDerivations"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetTypeDerivations(ISvcSymbolSetTypeDerivations raw) : base(raw)
        {
        }

        #region ISvcSymbolSetTypeDerivations
        #region CreateArrayType

        public SvcSymbolType CreateArrayType(ISvcSymbolType baseType, long dimensions, long[] dimensionSizes, long[] lowerBounds)
        {
            SvcSymbolType arrayTypeResult;
            TryCreateArrayType(baseType, dimensions, dimensionSizes, lowerBounds, out arrayTypeResult).ThrowDbgEngNotOK();

            return arrayTypeResult;
        }

        public HRESULT TryCreateArrayType(ISvcSymbolType baseType, long dimensions, long[] dimensionSizes, long[] lowerBounds, out SvcSymbolType arrayTypeResult)
        {
            /*HRESULT CreateArrayType(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbolType baseType,
            [In] long dimensions,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] dimensionSizes,
            [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] lowerBounds,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType arrayType);*/
            ISvcSymbolType arrayType;
            HRESULT hr = Raw.CreateArrayType(baseType, dimensions, dimensionSizes, lowerBounds, out arrayType);

            if (hr == HRESULT.S_OK)
                arrayTypeResult = arrayType == null ? null : new SvcSymbolType(arrayType);
            else
                arrayTypeResult = default(SvcSymbolType);

            return hr;
        }

        #endregion
        #endregion
    }
}
