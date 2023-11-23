namespace ClrDebug
{
    public class CorDebugDelegateObjectValue : ComObject<ICorDebugDelegateObjectValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CorDebugDelegateObjectValue"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public CorDebugDelegateObjectValue(ICorDebugDelegateObjectValue raw) : base(raw)
        {
        }

        #region ICorDebugDelegateObjectValue
        #region Target

        public CorDebugReferenceValue Target
        {
            get
            {
                CorDebugReferenceValue ppObjectResult;
                TryGetTarget(out ppObjectResult).ThrowOnNotOK();

                return ppObjectResult;
            }
        }

        public HRESULT TryGetTarget(out CorDebugReferenceValue ppObjectResult)
        {
            /*HRESULT GetTarget(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugReferenceValue ppObject);*/
            ICorDebugReferenceValue ppObject;
            HRESULT hr = Raw.GetTarget(out ppObject);

            if (hr == HRESULT.S_OK)
                ppObjectResult = ppObject == null ? null : new CorDebugReferenceValue(ppObject);
            else
                ppObjectResult = default(CorDebugReferenceValue);

            return hr;
        }

        #endregion
        #region Function

        public CorDebugFunction Function
        {
            get
            {
                CorDebugFunction ppFunctionResult;
                TryGetFunction(out ppFunctionResult).ThrowOnNotOK();

                return ppFunctionResult;
            }
        }

        public HRESULT TryGetFunction(out CorDebugFunction ppFunctionResult)
        {
            /*HRESULT GetFunction(
            [Out, MarshalAs(UnmanagedType.Interface)] out ICorDebugFunction ppFunction);*/
            ICorDebugFunction ppFunction;
            HRESULT hr = Raw.GetFunction(out ppFunction);

            if (hr == HRESULT.S_OK)
                ppFunctionResult = ppFunction == null ? null : new CorDebugFunction(ppFunction);
            else
                ppFunctionResult = default(CorDebugFunction);

            return hr;
        }

        #endregion
        #endregion
    }
}
