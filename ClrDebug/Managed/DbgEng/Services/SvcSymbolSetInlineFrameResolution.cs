namespace ClrDebug.DbgEng
{
    public class SvcSymbolSetInlineFrameResolution : ComObject<ISvcSymbolSetInlineFrameResolution>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetInlineFrameResolution"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetInlineFrameResolution(ISvcSymbolSetInlineFrameResolution raw) : base(raw)
        {
        }

        #region ISvcSymbolSetInlineFrameResolution
        #region GetInlineDepthAtOffset

        public long GetInlineDepthAtOffset(long moduleOffset)
        {
            long inlineDepth;
            TryGetInlineDepthAtOffset(moduleOffset, out inlineDepth).ThrowDbgEngNotOK();

            return inlineDepth;
        }

        public HRESULT TryGetInlineDepthAtOffset(long moduleOffset, out long inlineDepth)
        {
            /*HRESULT GetInlineDepthAtOffset(
            [In] long moduleOffset,
            [Out] out long inlineDepth);*/
            return Raw.GetInlineDepthAtOffset(moduleOffset, out inlineDepth);
        }

        #endregion
        #region GetInlinedFunctionAtOffset

        public SvcSymbol GetInlinedFunctionAtOffset(long moduleOffset, long inlineDepth)
        {
            SvcSymbol inlineFunctionResult;
            TryGetInlinedFunctionAtOffset(moduleOffset, inlineDepth, out inlineFunctionResult).ThrowDbgEngNotOK();

            return inlineFunctionResult;
        }

        public HRESULT TryGetInlinedFunctionAtOffset(long moduleOffset, long inlineDepth, out SvcSymbol inlineFunctionResult)
        {
            /*HRESULT GetInlinedFunctionAtOffset(
            [In] long moduleOffset,
            [In] long inlineDepth,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbol inlineFunction);*/
            ISvcSymbol inlineFunction;
            HRESULT hr = Raw.GetInlinedFunctionAtOffset(moduleOffset, inlineDepth, out inlineFunction);

            if (hr == HRESULT.S_OK)
                inlineFunctionResult = inlineFunction == null ? null : new SvcSymbol(inlineFunction);
            else
                inlineFunctionResult = default(SvcSymbol);

            return hr;
        }

        #endregion
        #endregion
    }
}
