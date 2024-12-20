namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Enumerates breakpoints.
    /// </summary>
    public class SvcBreakpointEnumerator : ComObject<ISvcBreakpointEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcBreakpointEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcBreakpointEnumerator(ISvcBreakpointEnumerator raw) : base(raw)
        {
        }

        #region ISvcBreakpointEnumerator
        #region Next

        /// <summary>
        /// Gets the next breakpoint in the collection.
        /// </summary>
        public SvcBreakpoint Next
        {
            get
            {
                SvcBreakpoint ppBreakpointResult;
                TryGetNext(out ppBreakpointResult).ThrowDbgEngNotOK();

                return ppBreakpointResult;
            }
        }

        /// <summary>
        /// Gets the next breakpoint in the collection.
        /// </summary>
        public HRESULT TryGetNext(out SvcBreakpoint ppBreakpointResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);*/
            ISvcBreakpoint ppBreakpoint;
            HRESULT hr = Raw.GetNext(out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = ppBreakpoint == null ? null : new SvcBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(SvcBreakpoint);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// Resets the enumerator so that the first breakpoint in the collection is returned from the subsequent GetNext call.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Resets the enumerator so that the first breakpoint in the collection is returned from the subsequent GetNext call.
        /// </summary>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
