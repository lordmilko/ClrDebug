namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The low level interface exposed from a DEBUG_SERVICE_BREAKPOINT_CONTROLLER which handles the fundamental low level breakpoint operations.<para/>
    /// Higher level breakpoint operations (e.g.: source level / deferred / etc...) are handled at the breakpoint manager level.
    /// </summary>
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

        /// <summary>
        /// Enumerates all breakpoints known to the breakpoint controller. Note that this will *ONLY* enumerate breakpoints known to the controller.<para/>
        /// There may be logically higher level breakpoints which are not realized as a single underlying breakpoint and are handled at the manager level.
        /// </summary>
        public SvcBreakpointEnumerator EnumerateBreakpoints(ISvcProcess pProcess)
        {
            SvcBreakpointEnumerator ppBreakpointEnumResult;
            TryEnumerateBreakpoints(pProcess, out ppBreakpointEnumResult).ThrowDbgEngNotOK();

            return ppBreakpointEnumResult;
        }

        /// <summary>
        /// Enumerates all breakpoints known to the breakpoint controller. Note that this will *ONLY* enumerate breakpoints known to the controller.<para/>
        /// There may be logically higher level breakpoints which are not realized as a single underlying breakpoint and are handled at the manager level.
        /// </summary>
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

        /// <summary>
        /// Creates a new code breakpoint at a given address.
        /// </summary>
        public SvcBreakpoint CreateCodeBreakpoint(ISvcProcess pProcess, long address)
        {
            SvcBreakpoint ppBreakpointResult;
            TryCreateCodeBreakpoint(pProcess, address, out ppBreakpointResult).ThrowDbgEngNotOK();

            return ppBreakpointResult;
        }

        /// <summary>
        /// Creates a new code breakpoint at a given address.
        /// </summary>
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

        /// <summary>
        /// Creates a new data breakpoint at a given address.
        /// </summary>
        public SvcBreakpoint CreateDataBreakpoint(ISvcProcess pProcess, long address, long dataWidth, DataAccessFlags accessFlags)
        {
            SvcBreakpoint ppBreakpointResult;
            TryCreateDataBreakpoint(pProcess, address, dataWidth, accessFlags, out ppBreakpointResult).ThrowDbgEngNotOK();

            return ppBreakpointResult;
        }

        /// <summary>
        /// Creates a new data breakpoint at a given address.
        /// </summary>
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
