namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Represents a way to discover scopes and their contents (variables and arguments) including that of inlined functions.<para/>
    /// Symbol sets which support inline frame resolution along with the enumeration of locals and arguments must support this interface.
    /// </summary>
    public class SvcSymbolSetInlineScopeResolution : ComObject<ISvcSymbolSetInlineScopeResolution>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcSymbolSetInlineScopeResolution"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcSymbolSetInlineScopeResolution(ISvcSymbolSetInlineScopeResolution raw) : base(raw)
        {
        }

        #region ISvcSymbolSetInlineScopeResolution
        #region FindScopeByOffsetAndInlineSymbol

        /// <summary>
        /// Finds a scope by an offset within the image and the inline function symbol representing a certain level of inlining at that location.<para/>
        /// A caller which passes nullptr for the inlineSymbol or passes a function symbol which does not represent an inlined function instance will get the behavior of the ISvcSymbolSetScopeResolution variant of this method.
        /// </summary>
        public SvcSymbolSetScope FindScopeByOffsetAndInlineSymbol(long moduleOffset, ISvcSymbol inlineSymbol)
        {
            SvcSymbolSetScope scopeResult;
            TryFindScopeByOffsetAndInlineSymbol(moduleOffset, inlineSymbol, out scopeResult).ThrowDbgEngNotOK();

            return scopeResult;
        }

        /// <summary>
        /// Finds a scope by an offset within the image and the inline function symbol representing a certain level of inlining at that location.<para/>
        /// A caller which passes nullptr for the inlineSymbol or passes a function symbol which does not represent an inlined function instance will get the behavior of the ISvcSymbolSetScopeResolution variant of this method.
        /// </summary>
        public HRESULT TryFindScopeByOffsetAndInlineSymbol(long moduleOffset, ISvcSymbol inlineSymbol, out SvcSymbolSetScope scopeResult)
        {
            /*HRESULT FindScopeByOffsetAndInlineSymbol(
            [In] long moduleOffset,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScope scope);*/
            ISvcSymbolSetScope scope;
            HRESULT hr = Raw.FindScopeByOffsetAndInlineSymbol(moduleOffset, inlineSymbol, out scope);

            if (hr == HRESULT.S_OK)
                scopeResult = scope == null ? null : new SvcSymbolSetScope(scope);
            else
                scopeResult = default(SvcSymbolSetScope);

            return hr;
        }

        #endregion
        #region FindScopeFrameForInlineSymbol

        public SvcSymbolSetScopeFrame FindScopeFrameForInlineSymbol(ISvcProcess process, ISvcRegisterContext frameContext, ISvcSymbol inlineSymbol)
        {
            SvcSymbolSetScopeFrame scopeFrameResult;
            TryFindScopeFrameForInlineSymbol(process, frameContext, inlineSymbol, out scopeFrameResult).ThrowDbgEngNotOK();

            return scopeFrameResult;
        }

        public HRESULT TryFindScopeFrameForInlineSymbol(ISvcProcess process, ISvcRegisterContext frameContext, ISvcSymbol inlineSymbol, out SvcSymbolSetScopeFrame scopeFrameResult)
        {
            /*HRESULT FindScopeFrameForInlineSymbol(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess process,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcRegisterContext frameContext,
            [In, MarshalAs(UnmanagedType.Interface)] ISvcSymbol inlineSymbol,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcSymbolSetScopeFrame scopeFrame);*/
            ISvcSymbolSetScopeFrame scopeFrame;
            HRESULT hr = Raw.FindScopeFrameForInlineSymbol(process, frameContext, inlineSymbol, out scopeFrame);

            if (hr == HRESULT.S_OK)
                scopeFrameResult = scopeFrame == null ? null : new SvcSymbolSetScopeFrame(scopeFrame);
            else
                scopeFrameResult = default(SvcSymbolSetScopeFrame);

            return hr;
        }

        #endregion
        #endregion
    }
}
