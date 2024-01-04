namespace ClrDebug.DbgEng
{
    public class SvcStackProviderPhysicalFrame : ComObject<ISvcStackProviderPhysicalFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcStackProviderPhysicalFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcStackProviderPhysicalFrame(ISvcStackProviderPhysicalFrame raw) : base(raw)
        {
        }

        #region ISvcStackProviderPhysicalFrame
        #region GetFrame

        public SvcRegisterContext GetFrame(ref SVC_STACK_FRAME pStackFrame)
        {
            SvcRegisterContext ppRegisterContextResult;
            TryGetFrame(ref pStackFrame, out ppRegisterContextResult).ThrowDbgEngNotOK();

            return ppRegisterContextResult;
        }

        public HRESULT TryGetFrame(ref SVC_STACK_FRAME pStackFrame, out SvcRegisterContext ppRegisterContextResult)
        {
            /*HRESULT GetFrame(
            [In, Out] ref SVC_STACK_FRAME pStackFrame,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcRegisterContext ppRegisterContext);*/
            ISvcRegisterContext ppRegisterContext;
            HRESULT hr = Raw.GetFrame(ref pStackFrame, out ppRegisterContext);

            if (hr == HRESULT.S_OK)
                ppRegisterContextResult = ppRegisterContext == null ? null : new SvcRegisterContext(ppRegisterContext);
            else
                ppRegisterContextResult = default(SvcRegisterContext);

            return hr;
        }

        #endregion
        #endregion
    }
}
