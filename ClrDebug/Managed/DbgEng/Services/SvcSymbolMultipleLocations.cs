namespace ClrDebug.DbgEng
{
    public class SvcSymbolMultipleLocations : ComObject<ISvcSymbolMultipleLocations>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolMultipleLocations"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolMultipleLocations(ISvcSymbolMultipleLocations raw) : base(raw)
        {
        }

        #region ISvcSymbolMultipleLocations
        #region LocationCount

        public long LocationCount
        {
            get
            {
                long pCount;
                TryGetLocationCount(out pCount).ThrowDbgEngNotOK();

                return pCount;
            }
        }

        public HRESULT TryGetLocationCount(out long pCount)
        {
            /*HRESULT GetLocationCount(
            [Out] out long pCount);*/
            return Raw.GetLocationCount(out pCount);
        }

        #endregion
        #region GetLocations

        public GetLocationsResult GetLocations(long maxSize)
        {
            GetLocationsResult result;
            TryGetLocations(maxSize, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetLocations(long maxSize, out GetLocationsResult result)
        {
            /*HRESULT GetLocations(
            [In] long maxSize,
            [SRI.Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SvcSymbolLocation[] pLocation,
            [Out] out long pSize);*/
            SvcSymbolLocation[] pLocation = new SvcSymbolLocation[(int) maxSize];
            long pSize;
            HRESULT hr = Raw.GetLocations(maxSize, pLocation, out pSize);

            if (hr == HRESULT.S_OK)
                result = new GetLocationsResult(pLocation, pSize);
            else
                result = default(GetLocationsResult);

            return hr;
        }

        #endregion
        #region GetLocationAtIndex

        public SvcSymbolLocation GetLocationAtIndex(long index)
        {
            SvcSymbolLocation pLocation;
            TryGetLocationAtIndex(index, out pLocation).ThrowDbgEngNotOK();

            return pLocation;
        }

        public HRESULT TryGetLocationAtIndex(long index, out SvcSymbolLocation pLocation)
        {
            /*HRESULT GetLocationAtIndex(
            [In] long index,
            [Out] out SvcSymbolLocation pLocation);*/
            return Raw.GetLocationAtIndex(index, out pLocation);
        }

        #endregion
        #region GetLocationOffsetAtIndex

        public long GetLocationOffsetAtIndex(long index)
        {
            long pOffset;
            TryGetLocationOffsetAtIndex(index, out pOffset).ThrowDbgEngNotOK();

            return pOffset;
        }

        public HRESULT TryGetLocationOffsetAtIndex(long index, out long pOffset)
        {
            /*HRESULT GetLocationOffsetAtIndex(
            [In] long index,
            [Out] out long pOffset);*/
            return Raw.GetLocationOffsetAtIndex(index, out pOffset);
        }

        #endregion
        #region GetConstantValueAtIndex

        public object GetConstantValueAtIndex(long index)
        {
            object pValue;
            TryGetConstantValueAtIndex(index, out pValue).ThrowDbgEngNotOK();

            return pValue;
        }

        public HRESULT TryGetConstantValueAtIndex(long index, out object pValue)
        {
            /*HRESULT GetConstantValueAtIndex(
            [In] long index,
            [Out, MarshalAs(UnmanagedType.Struct)] out object pValue);*/
            return Raw.GetConstantValueAtIndex(index, out pValue);
        }

        #endregion
        #endregion
    }
}
