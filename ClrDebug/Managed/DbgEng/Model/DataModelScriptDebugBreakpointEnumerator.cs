namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An enumerator of breakpoints within the script. The script provider implements this to enumerate all of the breakpoints which currently exist within the script (whether enabled or not).
    /// </summary>
    public class DataModelScriptDebugBreakpointEnumerator : ComObject<IDataModelScriptDebugBreakpointEnumerator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptDebugBreakpointEnumerator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptDebugBreakpointEnumerator(IDataModelScriptDebugBreakpointEnumerator raw) : base(raw)
        {
        }

        #region IDataModelScriptDebugBreakpointEnumerator
        #region Next

        /// <summary>
        /// The GetNext method moves the enumerator forward to the next breakpoint to be enumerated and returns the <see cref="IDataModelScriptDebugBreakpoint"/> interface for that breakpoint.<para/>
        /// If the enumerator has reached the end of the enumeration, it returns E_BOUNDS. Once the E_BOUNDS error has been produced, subsequent calls to the GetNext method will continue to produce E_BOUNDS unless an intervening call to the Reset method has been made.
        /// </summary>
        public DataModelScriptDebugBreakpoint Next
        {
            get
            {
                DataModelScriptDebugBreakpoint breakpointResult;
                TryGetNext(out breakpointResult).ThrowDbgEngNotOK();

                return breakpointResult;
            }
        }

        /// <summary>
        /// The GetNext method moves the enumerator forward to the next breakpoint to be enumerated and returns the <see cref="IDataModelScriptDebugBreakpoint"/> interface for that breakpoint.<para/>
        /// If the enumerator has reached the end of the enumeration, it returns E_BOUNDS. Once the E_BOUNDS error has been produced, subsequent calls to the GetNext method will continue to produce E_BOUNDS unless an intervening call to the Reset method has been made.
        /// </summary>
        /// <param name="breakpointResult">The next enumerated breakpoint is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetNext(out DataModelScriptDebugBreakpoint breakpointResult)
        {
            /*HRESULT GetNext(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);*/
            IDataModelScriptDebugBreakpoint breakpoint;
            HRESULT hr = Raw.GetNext(out breakpoint);

            if (hr == HRESULT.S_OK)
                breakpointResult = breakpoint == null ? null : new DataModelScriptDebugBreakpoint(breakpoint);
            else
                breakpointResult = default(DataModelScriptDebugBreakpoint);

            return hr;
        }

        #endregion
        #region Reset

        /// <summary>
        /// The Reset method resets the position of the enumerator to where it was just after the enumerator was created -- that is, before the first enumerated breakpoint.
        /// </summary>
        public void Reset()
        {
            TryReset().ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The Reset method resets the position of the enumerator to where it was just after the enumerator was created -- that is, before the first enumerated breakpoint.
        /// </summary>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryReset()
        {
            /*HRESULT Reset();*/
            return Raw.Reset();
        }

        #endregion
        #endregion
    }
}
