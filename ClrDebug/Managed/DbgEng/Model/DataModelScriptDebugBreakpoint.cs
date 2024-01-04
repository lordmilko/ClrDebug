namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface to a breakpoint on the script. The script provider implements this interface to expose the notion of and control of a particular breakpoint within the script.
    /// </summary>
    public class DataModelScriptDebugBreakpoint : ComObject<IDataModelScriptDebugBreakpoint>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptDebugBreakpoint"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptDebugBreakpoint(IDataModelScriptDebugBreakpoint raw) : base(raw)
        {
        }

        #region IDataModelScriptDebugBreakpoint
        #region Id

        /// <summary>
        /// The GetId method returns the unique identifier assigned by the script provider's debug engine to the breakpoint.<para/>
        /// This identifier must be unique within the context of the containing script. The breakpoint identifier may be unique to the provider; however, that is not required.
        /// </summary>
        public long Id
        {
            get
            {
                /*long GetId();*/
                return Raw.GetId();
            }
        }

        #endregion
        #region IsEnabled

        /// <summary>
        /// The IsEnabled method returns whether or not the breakpoint is enabled. A disabled breakpoint still exists and is still in the list of breakpoints for the script, it is merely "turned off" temporarily.<para/>
        /// All breakpoints should be created in the enabled state.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                /*bool IsEnabled();*/
                return Raw.IsEnabled();
            }
        }

        #endregion
        #region Position

        /// <summary>
        /// The GetPosition method returns the position of the breakpoint within the script. The script debugger must return the line and column within source code where the breakpoint is located.<para/>
        /// If it is capable of doing so, it can also return a span of source represented by the breakpoint by filling out an end position as defined by the positionSpanEnd argument.<para/>
        /// If the debugger is not capable of producing this span and the caller requests it, the Line and Column fields of the span's ending position should be filled in as zero indicating that the values cannot be provided.<para/>
        /// The debugger may also return the text of the line (or span) of source code where breakpoint exists in the lineText argument.<para/>
        /// While it is strongly recommended that debuggers return this value, it is not required. Only the line and column position within source are required return values.<para/>
        /// Should the debugger not be capable of producing the source text, nullptr may be returned in the lineText argument.
        /// </summary>
        public GetPositionResult Position
        {
            get
            {
                GetPositionResult result;
                TryGetPosition(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetPosition method returns the position of the breakpoint within the script. The script debugger must return the line and column within source code where the breakpoint is located.<para/>
        /// If it is capable of doing so, it can also return a span of source represented by the breakpoint by filling out an end position as defined by the positionSpanEnd argument.<para/>
        /// If the debugger is not capable of producing this span and the caller requests it, the Line and Column fields of the span's ending position should be filled in as zero indicating that the values cannot be provided.<para/>
        /// The debugger may also return the text of the line (or span) of source code where breakpoint exists in the lineText argument.<para/>
        /// While it is strongly recommended that debuggers return this value, it is not required. Only the line and column position within source are required return values.<para/>
        /// Should the debugger not be capable of producing the source text, nullptr may be returned in the lineText argument.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetPosition(out GetPositionResult result)
        {
            /*HRESULT GetPosition(
            [Out] out ScriptDebugPosition position,
            [Out] out ScriptDebugPosition positionSpanEnd,
            [Out, MarshalAs(UnmanagedType.BStr)] out string lineText);*/
            ScriptDebugPosition position;
            ScriptDebugPosition positionSpanEnd;
            string lineText;
            HRESULT hr = Raw.GetPosition(out position, out positionSpanEnd, out lineText);

            if (hr == HRESULT.S_OK)
                result = new GetPositionResult(position, positionSpanEnd, lineText);
            else
                result = default(GetPositionResult);

            return hr;
        }

        #endregion
        #region Enable

        /// <summary>
        /// The Enable method enables the breakpoint. If the breakpoint was disabled, "hitting the breakpoint" after calling this method will cause a break into the debugger.
        /// </summary>
        public void Enable()
        {
            /*void Enable();*/
            Raw.Enable();
        }

        #endregion
        #region Disable

        /// <summary>
        /// The Disable method disables the breakpoint. After this call, "hitting the breakpoint" after calling this method will not break into the debugger.<para/>
        /// The breakpoint, while still present, is considered "turned off".
        /// </summary>
        public void Disable()
        {
            /*void Disable();*/
            Raw.Disable();
        }

        #endregion
        #region Remove

        /// <summary>
        /// The Remove method removes the breakpoint from its containing list. The breakpoint no longer semantically exists after this method returns.<para/>
        /// The <see cref="IDataModelScriptDebugBreakpoint"/> interface which represented the breakpoint is considered orphaned after the call.<para/>
        /// Nothing else can (legally) be done with it after this call other than releasing it.
        /// </summary>
        public void Remove()
        {
            /*void Remove();*/
            Raw.Remove();
        }

        #endregion
        #endregion
    }
}
