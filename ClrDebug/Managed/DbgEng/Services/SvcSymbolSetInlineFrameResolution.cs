namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to describe how a compiler/optimizer has inlined functions at a particular location in the the module.
    /// </summary>
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

        /// <summary>
        /// For a given offset representing a code location within the image, return the depth of inlining at this particular offset.
        /// </summary>
        public long GetInlineDepthAtOffset(long moduleOffset)
        {
            long inlineDepth;
            TryGetInlineDepthAtOffset(moduleOffset, out inlineDepth).ThrowDbgEngNotOK();

            return inlineDepth;
        }

        /// <summary>
        /// For a given offset representing a code location within the image, return the depth of inlining at this particular offset.
        /// </summary>
        public HRESULT TryGetInlineDepthAtOffset(long moduleOffset, out long inlineDepth)
        {
            /*HRESULT GetInlineDepthAtOffset(
            [In] long moduleOffset,
            [Out] out long inlineDepth);*/
            return Raw.GetInlineDepthAtOffset(moduleOffset, out inlineDepth);
        }

        #endregion
        #region GetInlinedFunctionAtOffset

        /// <summary>
        /// For a given offset representing a code location within the image, return the N-th inline function at this particular offset.<para/>
        /// If there was nested inlining such as inlined_bat() { ... } inlined_bar() { noninlined_baz(); inlined_bat(); } foo() { inlined_bar(); } A call to GetInlineDepthAtOffset for an instruction in foo which was actually inlined from inlined_bat via inlined_bar would return 2.<para/>
        /// Similarly, GetInlinedFunctionAtOffset() passing an inlineDepth of 1: Would return inlined_bar 2: Would return inlined_bat This method returns a SvcSymbolInlinedFunction which represents the inlined function.
        /// </summary>
        public SvcSymbol GetInlinedFunctionAtOffset(long moduleOffset, long inlineDepth)
        {
            SvcSymbol inlineFunctionResult;
            TryGetInlinedFunctionAtOffset(moduleOffset, inlineDepth, out inlineFunctionResult).ThrowDbgEngNotOK();

            return inlineFunctionResult;
        }

        /// <summary>
        /// For a given offset representing a code location within the image, return the N-th inline function at this particular offset.<para/>
        /// If there was nested inlining such as inlined_bat() { ... } inlined_bar() { noninlined_baz(); inlined_bat(); } foo() { inlined_bar(); } A call to GetInlineDepthAtOffset for an instruction in foo which was actually inlined from inlined_bat via inlined_bar would return 2.<para/>
        /// Similarly, GetInlinedFunctionAtOffset() passing an inlineDepth of 1: Would return inlined_bar 2: Would return inlined_bat This method returns a SvcSymbolInlinedFunction which represents the inlined function.
        /// </summary>
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
