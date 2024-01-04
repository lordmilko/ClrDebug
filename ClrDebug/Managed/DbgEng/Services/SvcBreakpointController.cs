namespace ClrDebug.DbgEng
{
    public class SvcBreakpointController : ComObject<ISvcBreakpointController>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SvcBreakpointController"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public SvcBreakpointController(ISvcBreakpointController raw) : base(raw)
        {
        }

        #region ISvcBreakpointController
        #region EnumerateBreakpoints

        public SvcBreakpointEnumerator EnumerateBreakpoints(ISvcProcess pProcess)
        {
            SvcBreakpointEnumerator ppBreakpointEnumResult;
            TryEnumerateBreakpoints(pProcess, out ppBreakpointEnumResult).ThrowDbgEngNotOK();

            return ppBreakpointEnumResult;
        }

        public HRESULT TryEnumerateBreakpoints(ISvcProcess pProcess, out SvcBreakpointEnumerator ppBreakpointEnumResult)
        {
            /*HRESULT EnumerateBreakpoints(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpointEnumerator ppBreakpointEnum);*/
            ISvcBreakpointEnumerator ppBreakpointEnum;
            HRESULT hr = Raw.EnumerateBreakpoints(pProcess, out ppBreakpointEnum);

            if (hr == HRESULT.S_OK)
                ppBreakpointEnumResult = ppBreakpointEnum == null ? null : new SvcBreakpointEnumerator(ppBreakpointEnum);
            else
                ppBreakpointEnumResult = default(SvcBreakpointEnumerator);

            return hr;
        }

        #endregion
        #region CreateCodeBreakpoint

        public SvcBreakpoint CreateCodeBreakpoint(ISvcProcess pProcess, long address)
        {
            SvcBreakpoint ppBreakpointResult;
            TryCreateCodeBreakpoint(pProcess, address, out ppBreakpointResult).ThrowDbgEngNotOK();

            return ppBreakpointResult;
        }

        public HRESULT TryCreateCodeBreakpoint(ISvcProcess pProcess, long address, out SvcBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateCodeBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [In] long address,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);*/
            ISvcBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateCodeBreakpoint(pProcess, address, out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = ppBreakpoint == null ? null : new SvcBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(SvcBreakpoint);

            return hr;
        }

        #endregion
        #region CreateDataBreakpoint

        public SvcBreakpoint CreateDataBreakpoint(ISvcProcess pProcess, long address, long dataWidth, DataAccessFlags accessFlags)
        {
            SvcBreakpoint ppBreakpointResult;
            TryCreateDataBreakpoint(pProcess, address, dataWidth, accessFlags, out ppBreakpointResult).ThrowDbgEngNotOK();

            return ppBreakpointResult;
        }

        public HRESULT TryCreateDataBreakpoint(ISvcProcess pProcess, long address, long dataWidth, DataAccessFlags accessFlags, out SvcBreakpoint ppBreakpointResult)
        {
            /*HRESULT CreateDataBreakpoint(
            [In, MarshalAs(UnmanagedType.Interface)] ISvcProcess pProcess,
            [In] long address,
            [In] long dataWidth,
            [In] DataAccessFlags accessFlags,
            [Out, MarshalAs(UnmanagedType.Interface)] out ISvcBreakpoint ppBreakpoint);*/
            ISvcBreakpoint ppBreakpoint;
            HRESULT hr = Raw.CreateDataBreakpoint(pProcess, address, dataWidth, accessFlags, out ppBreakpoint);

            if (hr == HRESULT.S_OK)
                ppBreakpointResult = ppBreakpoint == null ? null : new SvcBreakpoint(ppBreakpoint);
            else
                ppBreakpointResult = default(SvcBreakpoint);

            return hr;
        }

        #endregion
        #endregion
    }
}
