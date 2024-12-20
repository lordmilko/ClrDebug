namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to create type representations which do not exist in the symbols (e.g.: arrays of things that are in symbols, etc...).<para/>
    /// Such can act as an aide to a higher level expression evaluator, etc...
    /// </summary>
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

        /// <summary>
        /// Returns an ISvcSymbolType representing an array from a partial description of what that array may look like at a linguistic level.<para/>
        /// The only mandatory piece of information to this method is the number of dimensions of the array. Languages for which array types are otherwise dynamic (e.g.: C#) require only this bit of information.<para/>
        /// Other languages may require an explicit specification of the sizes and/or lower bounds of dimensions. There is no guarantee that this method will succeed.
        /// </summary>
        public SvcSymbolType CreateArrayType(ISvcSymbolType baseType, long dimensions, long[] dimensionSizes, long[] lowerBounds)
        {
            SvcSymbolType arrayTypeResult;
            TryCreateArrayType(baseType, dimensions, dimensionSizes, lowerBounds, out arrayTypeResult).ThrowDbgEngNotOK();

            return arrayTypeResult;
        }

        /// <summary>
        /// Returns an ISvcSymbolType representing an array from a partial description of what that array may look like at a linguistic level.<para/>
        /// The only mandatory piece of information to this method is the number of dimensions of the array. Languages for which array types are otherwise dynamic (e.g.: C#) require only this bit of information.<para/>
        /// Other languages may require an explicit specification of the sizes and/or lower bounds of dimensions. There is no guarantee that this method will succeed.
        /// </summary>
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
