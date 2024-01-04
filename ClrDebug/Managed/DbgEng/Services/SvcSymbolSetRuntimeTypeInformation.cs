namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetRuntimeTypeInformation : ComObject<ISvcSymbolSetRuntimeTypeInformation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetRuntimeTypeInformation"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetRuntimeTypeInformation(ISvcSymbolSetRuntimeTypeInformation raw) : base(raw)
        {
        }

        #region ISvcSymbolSetRuntimeTypeInformation
        #region GetRuntimeType

        public GetRuntimeTypeResult GetRuntimeType(ISvcAddressContext addressContext, long staticObjectOffset, ISvcSymbolType staticObjectType)
        {
            GetRuntimeTypeResult result;
            TryGetRuntimeType(addressContext, staticObjectOffset, staticObjectType, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetRuntimeType(ISvcAddressContext addressContext, long staticObjectOffset, ISvcSymbolType staticObjectType, out GetRuntimeTypeResult result)
        {
            /*HRESULT GetRuntimeType(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcAddressContext addressContext,
            [In] long staticObjectOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbolType staticObjectType,
            [Out] out long runtimeObjectOffset,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolType runtimeObjectType);*/
            long runtimeObjectOffset;
            ISvcSymbolType runtimeObjectType;
            HRESULT hr = Raw.GetRuntimeType(addressContext, staticObjectOffset, staticObjectType, out runtimeObjectOffset, out runtimeObjectType);

            if (hr == HRESULT.S_OK)
                result = new GetRuntimeTypeResult(runtimeObjectOffset, runtimeObjectType == null ? null : new SvcSymbolType(runtimeObjectType));
            else
                result = default(GetRuntimeTypeResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
