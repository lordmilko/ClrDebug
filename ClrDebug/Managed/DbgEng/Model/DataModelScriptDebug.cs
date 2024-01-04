using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The core interface that a script provider must provide in order to make a script debuggable. The implementation class of the <see cref="IDataModelScript"/> interface must QueryInterface for IDataModelScriptDebug if the script is debuggable.<para/>
    /// Any script which is debuggable indicates this capability via the presence of the IDataModelScriptDebug interface on the same component which implements <see cref="IDataModelScript"/>.<para/>
    /// The query for this interface by the debug host or the debugger application hosting the data model is what indicates the presence of the debug capability.
    /// </summary>
    public class DataModelScriptDebug : ComObject<IDataModelScriptDebug>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptDebug"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptDebug(IDataModelScriptDebug raw) : base(raw)
        {
        }

        #region IDataModelScriptDebug
        #region DebugState

        /// <summary>
        /// The GetDebugState method returns the current state of the script (e.g.: whether it is executing or not). The state is defined by a value within the ScriptDebugState enumeration which is defined as follows.
        /// </summary>
        public ScriptDebugState DebugState
        {
            get
            {
                /*ScriptDebugState GetDebugState();*/
                return Raw.GetDebugState();
            }
        }

        #endregion
        #region CurrentPosition

        /// <summary>
        /// The GetCurrentPosition' method returns the current position within the script. This may only be called when the script is broken into the debugger where a call to GetScriptState would return ScriptDebugBreak.<para/>
        /// Any other call to this method is invalid and will fail. The position of the script is defined as a span of characters.<para/>
        /// The start of the span must always be returned (both the line and column numbers). If the particular debugger is capable of returning the full span of the "current position" within the script, an ending position can optionally be returned in the positionSpanEnd argument.<para/>
        /// If the debugger is not capable of this, the line and column values in the span end (if requested) should be set to zero.<para/>
        /// If the debugger can pass the source code for the line of code where the debugger is broken, it may return such from this method.<para/>
        /// If possible, it is strongly encouraged to provide this information. There is, however, no requirement that any more information than the starting line and column of the break position is returned.<para/>
        /// If source line information is not supported, a nullptr value may be returned for that argument.
        /// </summary>
        public GetCurrentPositionResult CurrentPosition
        {
            get
            {
                GetCurrentPositionResult result;
                TryGetCurrentPosition(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// The GetCurrentPosition' method returns the current position within the script. This may only be called when the script is broken into the debugger where a call to GetScriptState would return ScriptDebugBreak.<para/>
        /// Any other call to this method is invalid and will fail. The position of the script is defined as a span of characters.<para/>
        /// The start of the span must always be returned (both the line and column numbers). If the particular debugger is capable of returning the full span of the "current position" within the script, an ending position can optionally be returned in the positionSpanEnd argument.<para/>
        /// If the debugger is not capable of this, the line and column values in the span end (if requested) should be set to zero.<para/>
        /// If the debugger can pass the source code for the line of code where the debugger is broken, it may return such from this method.<para/>
        /// If possible, it is strongly encouraged to provide this information. There is, however, no requirement that any more information than the starting line and column of the break position is returned.<para/>
        /// If source line information is not supported, a nullptr value may be returned for that argument.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetCurrentPosition(out GetCurrentPositionResult result)
        {
            /*HRESULT GetCurrentPosition(
            [Out] out ScriptDebugPosition currentPosition,
            [Out] out ScriptDebugPosition positionSpanEnd,
            [Out, MarshalAs(UnmanagedType.BStr)] out string lineText);*/
            ScriptDebugPosition currentPosition;
            ScriptDebugPosition positionSpanEnd;
            string lineText;
            HRESULT hr = Raw.GetCurrentPosition(out currentPosition, out positionSpanEnd, out lineText);

            if (hr == HRESULT.S_OK)
                result = new GetCurrentPositionResult(currentPosition, positionSpanEnd, lineText);
            else
                result = default(GetCurrentPositionResult);

            return hr;
        }

        #endregion
        #region Stack

        /// <summary>
        /// The GetStack method gets the current call stack at the break position. This method may only be called when the script is broken into the debugger.
        /// </summary>
        public DataModelScriptDebugStack Stack
        {
            get
            {
                DataModelScriptDebugStack stackResult;
                TryGetStack(out stackResult).ThrowDbgEngNotOK();

                return stackResult;
            }
        }

        /// <summary>
        /// The GetStack method gets the current call stack at the break position. This method may only be called when the script is broken into the debugger.
        /// </summary>
        /// <param name="stackResult">A component implementing <see cref="IDataModelScriptDebugStack"/> is returned here representing the call stack state at the position of the break.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetStack(out DataModelScriptDebugStack stackResult)
        {
            /*HRESULT GetStack(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugStack stack);*/
            IDataModelScriptDebugStack stack;
            HRESULT hr = Raw.GetStack(out stack);

            if (hr == HRESULT.S_OK)
                stackResult = stack == null ? null : new DataModelScriptDebugStack(stack);
            else
                stackResult = default(DataModelScriptDebugStack);

            return hr;
        }

        #endregion
        #region SetBreakpoint

        /// <summary>
        /// The SetBreakpoint method sets a breakpoint within the script. Note that the implementation is free to adjust the inpassed line and column positions to move forward to an appropriate code position.<para/>
        /// The actual line and column numbers where the breakpoint was placed can be retrieved by method calls on the returned <see cref="IDataModelScriptDebugBreakpoint"/> interface.<para/>
        /// Note that it is the responsibility of the implementation to "remember" all of the breakpoints which have been set and assign a unique identifier to each.<para/>
        /// That identifier must be unique within the domain of a single script. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.<para/>
        /// A breakpoint may be set before any execution occurs.
        /// </summary>
        /// <param name="linePosition">The one based line number of the location in source code where the breakpoint is being set.</param>
        /// <param name="columnPosition">The one based column number on the given line where the breakpoint is being set.</param>
        /// <returns>An <see cref="IDataModelScriptDebugBreakpoint"/> interface representing the newly created breakpoint is returned here.</returns>
        public DataModelScriptDebugBreakpoint SetBreakpoint(int linePosition, int columnPosition)
        {
            DataModelScriptDebugBreakpoint breakpointResult;
            TrySetBreakpoint(linePosition, columnPosition, out breakpointResult).ThrowDbgEngNotOK();

            return breakpointResult;
        }

        /// <summary>
        /// The SetBreakpoint method sets a breakpoint within the script. Note that the implementation is free to adjust the inpassed line and column positions to move forward to an appropriate code position.<para/>
        /// The actual line and column numbers where the breakpoint was placed can be retrieved by method calls on the returned <see cref="IDataModelScriptDebugBreakpoint"/> interface.<para/>
        /// Note that it is the responsibility of the implementation to "remember" all of the breakpoints which have been set and assign a unique identifier to each.<para/>
        /// That identifier must be unique within the domain of a single script. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.<para/>
        /// A breakpoint may be set before any execution occurs.
        /// </summary>
        /// <param name="linePosition">The one based line number of the location in source code where the breakpoint is being set.</param>
        /// <param name="columnPosition">The one based column number on the given line where the breakpoint is being set.</param>
        /// <param name="breakpointResult">An <see cref="IDataModelScriptDebugBreakpoint"/> interface representing the newly created breakpoint is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TrySetBreakpoint(int linePosition, int columnPosition, out DataModelScriptDebugBreakpoint breakpointResult)
        {
            /*HRESULT SetBreakpoint(
            [In] int linePosition,
            [In] int columnPosition,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);*/
            IDataModelScriptDebugBreakpoint breakpoint;
            HRESULT hr = Raw.SetBreakpoint(linePosition, columnPosition, out breakpoint);

            if (hr == HRESULT.S_OK)
                breakpointResult = breakpoint == null ? null : new DataModelScriptDebugBreakpoint(breakpoint);
            else
                breakpointResult = default(DataModelScriptDebugBreakpoint);

            return hr;
        }

        #endregion
        #region FindBreakpointById

        /// <summary>
        /// Each breakpoint which is created within the script via the SetBreakpoint method is assigned a unique identifier (a 64-bit unsigned integer) by the implementation.<para/>
        /// The FindBreakpointById method is used to get an interface to the breakpoint from a given identifier. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="breakpointId">The unique id of the breakpoint being retrieved.</param>
        /// <returns>An interface to the found breakpoint is returned here. If the breakpoint cannot be found, an error is returned.</returns>
        public DataModelScriptDebugBreakpoint FindBreakpointById(long breakpointId)
        {
            DataModelScriptDebugBreakpoint breakpointResult;
            TryFindBreakpointById(breakpointId, out breakpointResult).ThrowDbgEngNotOK();

            return breakpointResult;
        }

        /// <summary>
        /// Each breakpoint which is created within the script via the SetBreakpoint method is assigned a unique identifier (a 64-bit unsigned integer) by the implementation.<para/>
        /// The FindBreakpointById method is used to get an interface to the breakpoint from a given identifier. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="breakpointId">The unique id of the breakpoint being retrieved.</param>
        /// <param name="breakpointResult">An interface to the found breakpoint is returned here. If the breakpoint cannot be found, an error is returned.</param>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryFindBreakpointById(long breakpointId, out DataModelScriptDebugBreakpoint breakpointResult)
        {
            /*HRESULT FindBreakpointById(
            [In] long breakpointId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);*/
            IDataModelScriptDebugBreakpoint breakpoint;
            HRESULT hr = Raw.FindBreakpointById(breakpointId, out breakpoint);

            if (hr == HRESULT.S_OK)
                breakpointResult = breakpoint == null ? null : new DataModelScriptDebugBreakpoint(breakpoint);
            else
                breakpointResult = default(DataModelScriptDebugBreakpoint);

            return hr;
        }

        #endregion
        #region EnumerateBreakpoints

        /// <summary>
        /// The EnumerateBreakpoints method returns an enumerator capable of enumerating every breakpoint which is set within a particular script.<para/>
        /// As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <returns>An enumerator which enumerates every breakpoint which is set within the script (whether enabled or disabled) must be returned here.</returns>
        public DataModelScriptDebugBreakpointEnumerator EnumerateBreakpoints()
        {
            DataModelScriptDebugBreakpointEnumerator breakpointEnumResult;
            TryEnumerateBreakpoints(out breakpointEnumResult).ThrowDbgEngNotOK();

            return breakpointEnumResult;
        }

        /// <summary>
        /// The EnumerateBreakpoints method returns an enumerator capable of enumerating every breakpoint which is set within a particular script.<para/>
        /// As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="breakpointEnumResult">An enumerator which enumerates every breakpoint which is set within the script (whether enabled or disabled) must be returned here.</param>
        /// <returns>This method returns HRESULT.</returns>
        public HRESULT TryEnumerateBreakpoints(out DataModelScriptDebugBreakpointEnumerator breakpointEnumResult)
        {
            /*HRESULT EnumerateBreakpoints(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpointEnumerator breakpointEnum);*/
            IDataModelScriptDebugBreakpointEnumerator breakpointEnum;
            HRESULT hr = Raw.EnumerateBreakpoints(out breakpointEnum);

            if (hr == HRESULT.S_OK)
                breakpointEnumResult = breakpointEnum == null ? null : new DataModelScriptDebugBreakpointEnumerator(breakpointEnum);
            else
                breakpointEnumResult = default(DataModelScriptDebugBreakpointEnumerator);

            return hr;
        }

        #endregion
        #region GetEventFilter

        /// <summary>
        /// The GetEventFilter method returns whether "break on event" is enabled for a particular event. Events which can cause "break on event" are described by a member of the ScriptDebugEventFilter enumeration which is defined as follows: If a particular event type is not supported by the script debugger, E_NOTIMPL may be returned.<para/>
        /// As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="eventFilter">Indicates for which event the "break on event" behavior is being changed. The event is defined as a member of the ScriptDebugEventFilter enumeration.</param>
        /// <returns>If "break on event" is enabled for the event in question, true is returned; otherwise, false is returned.</returns>
        public bool GetEventFilter(ScriptDebugEventFilter eventFilter)
        {
            bool isBreakEnabled;
            TryGetEventFilter(eventFilter, out isBreakEnabled).ThrowDbgEngNotOK();

            return isBreakEnabled;
        }

        /// <summary>
        /// The GetEventFilter method returns whether "break on event" is enabled for a particular event. Events which can cause "break on event" are described by a member of the ScriptDebugEventFilter enumeration which is defined as follows: If a particular event type is not supported by the script debugger, E_NOTIMPL may be returned.<para/>
        /// As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="eventFilter">Indicates for which event the "break on event" behavior is being changed. The event is defined as a member of the ScriptDebugEventFilter enumeration.</param>
        /// <param name="isBreakEnabled">If "break on event" is enabled for the event in question, true is returned; otherwise, false is returned.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryGetEventFilter(ScriptDebugEventFilter eventFilter, out bool isBreakEnabled)
        {
            /*HRESULT GetEventFilter(
            [In] ScriptDebugEventFilter eventFilter,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isBreakEnabled);*/
            return Raw.GetEventFilter(eventFilter, out isBreakEnabled);
        }

        #endregion
        #region SetEventFilter

        /// <summary>
        /// The SetEventFilter method changes the "break on event" behavior for a particular event as defined by a member of the ScriptDebugEventFilter enumeration.<para/>
        /// A full list of available events (and a description of this enumeration) can be found in the documentation for the GetEventFilter method.<para/>
        /// If a particular event type is not supported by the script debugger, E_NOTIMPL may be returned. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="eventFilter">Indicates for which event the "break on event" behavior is being changed. The event is defined as a member of the ScriptDebugEventFilter enumeration.</param>
        /// <param name="isBreakEnabled">If true, indicates that the caller wants the debugger to break into the debugger when the given event occurs; if false, indicates that the caller does not want the debugger to break into the debugger when the given event occurs.</param>
        public void SetEventFilter(ScriptDebugEventFilter eventFilter, bool isBreakEnabled)
        {
            TrySetEventFilter(eventFilter, isBreakEnabled).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The SetEventFilter method changes the "break on event" behavior for a particular event as defined by a member of the ScriptDebugEventFilter enumeration.<para/>
        /// A full list of available events (and a description of this enumeration) can be found in the documentation for the GetEventFilter method.<para/>
        /// If a particular event type is not supported by the script debugger, E_NOTIMPL may be returned. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="eventFilter">Indicates for which event the "break on event" behavior is being changed. The event is defined as a member of the ScriptDebugEventFilter enumeration.</param>
        /// <param name="isBreakEnabled">If true, indicates that the caller wants the debugger to break into the debugger when the given event occurs; if false, indicates that the caller does not want the debugger to break into the debugger when the given event occurs.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TrySetEventFilter(ScriptDebugEventFilter eventFilter, bool isBreakEnabled)
        {
            /*HRESULT SetEventFilter(
            [In] ScriptDebugEventFilter eventFilter,
            [In, MarshalAs(UnmanagedType.U1)] bool isBreakEnabled);*/
            return Raw.SetEventFilter(eventFilter, isBreakEnabled);
        }

        #endregion
        #region StartDebugging

        /// <summary>
        /// The StartDebugging method "turns on" the debugger for a particular script. The act of starting debugging does not actively cause any execution break or stepping.<para/>
        /// It merely makes the script debuggable and provides a set of interfaces for the client to communicate with the debugging interface.<para/>
        /// The debug client which is passed to the StartDebugging method must be saved by the implementation. When any event occurs that "breaks into the debugger", that break is implemented by a synchronous call to notify the client of the event.<para/>
        /// Execution resumes when the client returns from notification call. A return argument indicates how execution should resume.<para/>
        /// This method should only be called when the script debugger is not enabled for the given script. Any other call is illegal.
        /// </summary>
        /// <param name="debugClient">An interface to the client of the script debugger. Debug events are passed to this interface.</param>
        public void StartDebugging(IDataModelScriptDebugClient debugClient)
        {
            TryStartDebugging(debugClient).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The StartDebugging method "turns on" the debugger for a particular script. The act of starting debugging does not actively cause any execution break or stepping.<para/>
        /// It merely makes the script debuggable and provides a set of interfaces for the client to communicate with the debugging interface.<para/>
        /// The debug client which is passed to the StartDebugging method must be saved by the implementation. When any event occurs that "breaks into the debugger", that break is implemented by a synchronous call to notify the client of the event.<para/>
        /// Execution resumes when the client returns from notification call. A return argument indicates how execution should resume.<para/>
        /// This method should only be called when the script debugger is not enabled for the given script. Any other call is illegal.
        /// </summary>
        /// <param name="debugClient">An interface to the client of the script debugger. Debug events are passed to this interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryStartDebugging(IDataModelScriptDebugClient debugClient)
        {
            /*HRESULT StartDebugging(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptDebugClient debugClient);*/
            return Raw.StartDebugging(debugClient);
        }

        #endregion
        #region StopDebugging

        /// <summary>
        /// The StopDebugging method is called by a client that wants to stop debugging. This method call may be made at any point after StartDebugging was made successfully (e.g.: during a break, while the script is executing, etc...).<para/>
        /// The call immediately ceases all debugging activity and resets the state back to before StartDebugging was called.
        /// </summary>
        /// <param name="debugClient">The debug client which is stopping debugging. This should match the debug client passed to the StartDebugging call.<para/>
        /// A non-matching client is an illegal call.</param>
        public void StopDebugging(IDataModelScriptDebugClient debugClient)
        {
            TryStopDebugging(debugClient).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// The StopDebugging method is called by a client that wants to stop debugging. This method call may be made at any point after StartDebugging was made successfully (e.g.: during a break, while the script is executing, etc...).<para/>
        /// The call immediately ceases all debugging activity and resets the state back to before StartDebugging was called.
        /// </summary>
        /// <param name="debugClient">The debug client which is stopping debugging. This should match the debug client passed to the StartDebugging call.<para/>
        /// A non-matching client is an illegal call.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryStopDebugging(IDataModelScriptDebugClient debugClient)
        {
            /*HRESULT StopDebugging(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptDebugClient debugClient);*/
            return Raw.StopDebugging(debugClient);
        }

        #endregion
        #endregion
        #region IDataModelScriptDebug2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDataModelScriptDebug2 Raw2 => (IDataModelScriptDebug2) Raw;

        #region SetBreakpointAtFunction

        /// <summary>
        /// Sets a breakpoint on the function given by the supplied name.
        /// </summary>
        /// <param name="functionName">The name of the function you want a breakpoint set on.</param>
        /// <returns>The newly created breakpoint will be returned here.</returns>
        public DataModelScriptDebugBreakpoint SetBreakpointAtFunction(string functionName)
        {
            DataModelScriptDebugBreakpoint breakpointResult;
            TrySetBreakpointAtFunction(functionName, out breakpointResult).ThrowDbgEngNotOK();

            return breakpointResult;
        }

        /// <summary>
        /// Sets a breakpoint on the function given by the supplied name.
        /// </summary>
        /// <param name="functionName">The name of the function you want a breakpoint set on.</param>
        /// <param name="breakpointResult">The newly created breakpoint will be returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TrySetBreakpointAtFunction(string functionName, out DataModelScriptDebugBreakpoint breakpointResult)
        {
            /*HRESULT SetBreakpointAtFunction(
            [In, MarshalAs(UnmanagedType.LPWStr)] string functionName,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);*/
            IDataModelScriptDebugBreakpoint breakpoint;
            HRESULT hr = Raw2.SetBreakpointAtFunction(functionName, out breakpoint);

            if (hr == HRESULT.S_OK)
                breakpointResult = breakpoint == null ? null : new DataModelScriptDebugBreakpoint(breakpoint);
            else
                breakpointResult = default(DataModelScriptDebugBreakpoint);

            return hr;
        }

        #endregion
        #endregion
    }
}
