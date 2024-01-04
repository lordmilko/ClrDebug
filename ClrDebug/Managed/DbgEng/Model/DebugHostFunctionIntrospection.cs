using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    public class DebugHostFunctionIntrospection : ComObject<IDebugHostFunctionIntrospection>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostFunctionIntrospection"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostFunctionIntrospection(IDebugHostFunctionIntrospection raw) : base(raw)
        {
        }

        #region IDebugHostFunctionIntrospection
        #region EnumerateLocalsDetails

        public DebugHostFunctionLocalDetailsEnumerator EnumerateLocalsDetails()
        {
            DebugHostFunctionLocalDetailsEnumerator localsEnumResult;
            TryEnumerateLocalsDetails(out localsEnumResult).ThrowDbgEngNotOK();

            return localsEnumResult;
        }

        public HRESULT TryEnumerateLocalsDetails(out DebugHostFunctionLocalDetailsEnumerator localsEnumResult)
        {
            /*HRESULT EnumerateLocalsDetails(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetailsEnumerator localsEnum);*/
            IDebugHostFunctionLocalDetailsEnumerator localsEnum;
            HRESULT hr = Raw.EnumerateLocalsDetails(out localsEnum);

            if (hr == HRESULT.S_OK)
                localsEnumResult = localsEnum == null ? null : new DebugHostFunctionLocalDetailsEnumerator(localsEnum);
            else
                localsEnumResult = default(DebugHostFunctionLocalDetailsEnumerator);

            return hr;
        }

        #endregion
        #region EnumerateInlineFunctionsByRVA

        public DebugHostSymbolEnumerator EnumerateInlineFunctionsByRVA(long rva)
        {
            DebugHostSymbolEnumerator inlinesEnumResult;
            TryEnumerateInlineFunctionsByRVA(rva, out inlinesEnumResult).ThrowDbgEngNotOK();

            return inlinesEnumResult;
        }

        public HRESULT TryEnumerateInlineFunctionsByRVA(long rva, out DebugHostSymbolEnumerator inlinesEnumResult)
        {
            /*HRESULT EnumerateInlineFunctionsByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostSymbolEnumerator inlinesEnum);*/
            IDebugHostSymbolEnumerator inlinesEnum;
            HRESULT hr = Raw.EnumerateInlineFunctionsByRVA(rva, out inlinesEnum);

            if (hr == HRESULT.S_OK)
                inlinesEnumResult = DebugHostSymbolEnumerator.New(inlinesEnum);
            else
                inlinesEnumResult = default(DebugHostSymbolEnumerator);

            return hr;
        }

        #endregion
        #region FindContainingCodeRangeByRVA

        public FindContainingCodeRangeByRVAResult FindContainingCodeRangeByRVA(long rva)
        {
            FindContainingCodeRangeByRVAResult result;
            TryFindContainingCodeRangeByRVA(rva, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryFindContainingCodeRangeByRVA(long rva, out FindContainingCodeRangeByRVAResult result)
        {
            /*HRESULT FindContainingCodeRangeByRVA(
            [In] long rva,
            [Out] out Location rangeStart,
            [Out] out Location rangeEnd);*/
            Location rangeStart;
            Location rangeEnd;
            HRESULT hr = Raw.FindContainingCodeRangeByRVA(rva, out rangeStart, out rangeEnd);

            if (hr == HRESULT.S_OK)
                result = new FindContainingCodeRangeByRVAResult(rangeStart, rangeEnd);
            else
                result = default(FindContainingCodeRangeByRVAResult);

            return hr;
        }

        #endregion
        #region FindSourceLocationByRVA

        public FindSourceLocationByRVAResult FindSourceLocationByRVA(long rva)
        {
            FindSourceLocationByRVAResult result;
            TryFindSourceLocationByRVA(rva, out result).ThrowDbgEngNotOK();

            return result;
        }

        public HRESULT TryFindSourceLocationByRVA(long rva, out FindSourceLocationByRVAResult result)
        {
            /*HRESULT FindSourceLocationByRVA(
            [In] long rva,
            [Out, MarshalAs(UnmanagedType.BStr)] out string sourceFile,
            [Out] out long sourceLine);*/
            string sourceFile;
            long sourceLine;
            HRESULT hr = Raw.FindSourceLocationByRVA(rva, out sourceFile, out sourceLine);

            if (hr == HRESULT.S_OK)
                result = new FindSourceLocationByRVAResult(sourceFile, sourceLine);
            else
                result = default(FindSourceLocationByRVAResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostFunctionIntrospection2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostFunctionIntrospection2 Raw2 => (IDebugHostFunctionIntrospection2) Raw;

        #region EnumerateLocalsDetailsEx

        public DebugHostFunctionLocalDetailsEnumerator EnumerateLocalsDetailsEx(bool enumerateInlinedLocals)
        {
            DebugHostFunctionLocalDetailsEnumerator localsEnumResult;
            TryEnumerateLocalsDetailsEx(enumerateInlinedLocals, out localsEnumResult).ThrowDbgEngNotOK();

            return localsEnumResult;
        }

        public HRESULT TryEnumerateLocalsDetailsEx(bool enumerateInlinedLocals, out DebugHostFunctionLocalDetailsEnumerator localsEnumResult)
        {
            /*HRESULT EnumerateLocalsDetailsEx(
            [In, MarshalAs(UnmanagedType.U1)] bool enumerateInlinedLocals,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDebugHostFunctionLocalDetailsEnumerator localsEnum);*/
            IDebugHostFunctionLocalDetailsEnumerator localsEnum;
            HRESULT hr = Raw2.EnumerateLocalsDetailsEx(enumerateInlinedLocals, out localsEnum);

            if (hr == HRESULT.S_OK)
                localsEnumResult = localsEnum == null ? null : new DebugHostFunctionLocalDetailsEnumerator(localsEnum);
            else
                localsEnumResult = default(DebugHostFunctionLocalDetailsEnumerator);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostFunctionIntrospection3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostFunctionIntrospection3 Raw3 => (IDebugHostFunctionIntrospection3) Raw;

        #region IsNoReturnFunction

        public bool IsNoReturnFunction
        {
            get
            {
                bool pIsNoReturnFunction;
                TryIsNoReturnFunction(out pIsNoReturnFunction).ThrowDbgEngNotOK();

                return pIsNoReturnFunction;
            }
        }

        public HRESULT TryIsNoReturnFunction(out bool pIsNoReturnFunction)
        {
            /*HRESULT IsNoReturnFunction(
            [Out, MarshalAs(UnmanagedType.U1)] out bool pIsNoReturnFunction);*/
            return Raw3.IsNoReturnFunction(out pIsNoReturnFunction);
        }

        #endregion
        #endregion
    }
}
