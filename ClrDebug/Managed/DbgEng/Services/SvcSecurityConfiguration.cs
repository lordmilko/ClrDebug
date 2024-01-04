namespace ClrDebug.DbgEng
{
    public class SvcSecurityConfiguration : ComObject<ISvcSecurityConfiguration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSecurityConfiguration"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSecurityConfiguration(ISvcSecurityConfiguration raw) : base(raw)
        {
        }

        #region ISvcSecurityConfiguration
        #region GetPointerAuthenticationMask

        public GetPointerAuthenticationMaskResult GetPointerAuthenticationMask(ISvcProcess pProcess, long ptr)
        {
            GetPointerAuthenticationMaskResult result;
            TryGetPointerAuthenticationMask(pProcess, ptr, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryGetPointerAuthenticationMask(ISvcProcess pProcess, long ptr, out GetPointerAuthenticationMaskResult result)
        {
            /*HRESULT GetPointerAuthenticationMask(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [In] long ptr,
            [Out] out long pDataMask,
            [Out] out long pInstructionMask);*/
            long pDataMask;
            long pInstructionMask;
            HRESULT hr = Raw.GetPointerAuthenticationMask(pProcess, ptr, out pDataMask, out pInstructionMask);

            if (hr == HRESULT.S_OK)
                result = new GetPointerAuthenticationMaskResult(pDataMask, pInstructionMask);
            else
                result = default(GetPointerAuthenticationMaskResult);

            return hr;
        }

        #endregion
        #endregion
    }
}
