namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to abstract runtime type information (whether RTTI based or based upon another type system).
    /// </summary>
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

        /// <summary>
        /// For an object of a given type at a given address within a specified address context (e.g.: process), utilize RTTI or other type system information to determine the actual runtime type of the object and its location.<para/>
        /// This method can arbitrarily fail.
        /// </summary>
        public GetRuntimeTypeResult GetRuntimeType(ISvcAddressContext addressContext, long staticObjectOffset, ISvcSymbolType staticObjectType)
        {
            GetRuntimeTypeResult result;
            TryGetRuntimeType(addressContext, staticObjectOffset, staticObjectType, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// For an object of a given type at a given address within a specified address context (e.g.: process), utilize RTTI or other type system information to determine the actual runtime type of the object and its location.<para/>
        /// This method can arbitrarily fail.
        /// </summary>
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
