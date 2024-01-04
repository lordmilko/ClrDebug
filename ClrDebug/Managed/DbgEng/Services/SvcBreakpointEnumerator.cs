namespace ClrDebug.DbgEng
{
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

        public SvcBreakpoint Next
        {
            get
            {
                SvcBreakpoint ppBreakpointResult;
                TryGetNext(out ppBreakpointResult).ThrowDbgEngNotOK();

                return ppBreakpointResult;
            }
        }

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

        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
