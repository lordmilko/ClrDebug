using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The core interface that a script provider must provide in order to make a script debuggable. The implementation class of the <see cref="IDataModelScript"/> interface must QueryInterface for IDataModelScriptDebug if the script is debuggable.<para/>
    /// Any script which is debuggable indicates this capability via the presence of the IDataModelScriptDebug interface on the same component which implements <see cref="IDataModelScript"/>.<para/>
    /// The query for this interface by the debug host or the debugger application hosting the data model is what indicates the presence of the debug capability.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("DE8E0945-9750-4471-AB76-A8F79D6EC350")]
    [ComImport]
    public interface IDataModelScriptDebug
    {
        /// <summary>
        /// The GetDebugState method returns the current state of the script (e.g.: whether it is executing or not). The state is defined by a value within the ScriptDebugState enumeration which is defined as follows.
        /// </summary>
        /// <returns>The debug state of the script as indicated by a value in the ScriptDebugState enumeration.</returns>
        [PreserveSig]
        ScriptDebugState GetDebugState();

        /// <summary>
        /// The GetCurrentPosition' method returns the current position within the script. This may only be called when the script is broken into the debugger where a call to GetScriptState would return ScriptDebugBreak.<para/>
        /// Any other call to this method is invalid and will fail. The position of the script is defined as a span of characters.<para/>
        /// The start of the span must always be returned (both the line and column numbers). If the particular debugger is capable of returning the full span of the "current position" within the script, an ending position can optionally be returned in the positionSpanEnd argument.<para/>
        /// If the debugger is not capable of this, the line and column values in the span end (if requested) should be set to zero.<para/>
        /// If the debugger can pass the source code for the line of code where the debugger is broken, it may return such from this method.<para/>
        /// If possible, it is strongly encouraged to provide this information. There is, however, no requirement that any more information than the starting line and column of the break position is returned.<para/>
        /// If source line information is not supported, a nullptr value may be returned for that argument.
        /// </summary>
        /// <param name="currentPosition">The current break position of the script must be returned here. The Line and Column fields of the returned structure are one based.<para/>
        /// A zero value in either indicates that the information is unavailable.</param>
        /// <param name="positionSpanEnd">If the debugger is capable of determining the full span of the break position, the ending position of the span can be returned here.<para/>
        /// If not, zero values should be filled into the Line and Column fields of the returned structure.</param>
        /// <param name="lineText">If the debugger is capable of returning the source code for the line (or the span) of the break, such can be returned here as a string allocated by the SysAllocString function.<para/>
        /// The caller is responsible for freeing the returned string with SysFreeString. If the debugger is incapable of producing this source information, nullptr should be returned.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetCurrentPosition(
            [Out] out ScriptDebugPosition currentPosition,
            [Out] out ScriptDebugPosition positionSpanEnd,
            [Out, MarshalAs(UnmanagedType.BStr)] out string lineText);

        /// <summary>
        /// The GetStack method gets the current call stack at the break position. This method may only be called when the script is broken into the debugger.
        /// </summary>
        /// <param name="stack">A component implementing <see cref="IDataModelScriptDebugStack"/> is returned here representing the call stack state at the position of the break.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetStack(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugStack stack);

        /// <summary>
        /// The SetBreakpoint method sets a breakpoint within the script. Note that the implementation is free to adjust the inpassed line and column positions to move forward to an appropriate code position.<para/>
        /// The actual line and column numbers where the breakpoint was placed can be retrieved by method calls on the returned <see cref="IDataModelScriptDebugBreakpoint"/> interface.<para/>
        /// Note that it is the responsibility of the implementation to "remember" all of the breakpoints which have been set and assign a unique identifier to each.<para/>
        /// That identifier must be unique within the domain of a single script. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.<para/>
        /// A breakpoint may be set before any execution occurs.
        /// </summary>
        /// <param name="linePosition">The one based line number of the location in source code where the breakpoint is being set.</param>
        /// <param name="columnPosition">The one based column number on the given line where the breakpoint is being set.</param>
        /// <param name="breakpoint">An <see cref="IDataModelScriptDebugBreakpoint"/> interface representing the newly created breakpoint is returned here.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT SetBreakpoint(
            [In] int linePosition,
            [In] int columnPosition,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);

        /// <summary>
        /// Each breakpoint which is created within the script via the SetBreakpoint method is assigned a unique identifier (a 64-bit unsigned integer) by the implementation.<para/>
        /// The FindBreakpointById method is used to get an interface to the breakpoint from a given identifier. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="breakpointId">The unique id of the breakpoint being retrieved.</param>
        /// <param name="breakpoint">An interface to the found breakpoint is returned here. If the breakpoint cannot be found, an error is returned.</param>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT FindBreakpointById(
            [In] long breakpointId,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpoint breakpoint);

        /// <summary>
        /// The EnumerateBreakpoints method returns an enumerator capable of enumerating every breakpoint which is set within a particular script.<para/>
        /// As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="breakpointEnum">An enumerator which enumerates every breakpoint which is set within the script (whether enabled or disabled) must be returned here.</param>
        /// <returns>This method returns HRESULT.</returns>
        [PreserveSig]
        HRESULT EnumerateBreakpoints(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugBreakpointEnumerator breakpointEnum);

        /// <summary>
        /// The GetEventFilter method returns whether "break on event" is enabled for a particular event. Events which can cause "break on event" are described by a member of the ScriptDebugEventFilter enumeration which is defined as follows: If a particular event type is not supported by the script debugger, E_NOTIMPL may be returned.<para/>
        /// As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="eventFilter">Indicates for which event the "break on event" behavior is being changed. The event is defined as a member of the ScriptDebugEventFilter enumeration.</param>
        /// <param name="isBreakEnabled">If "break on event" is enabled for the event in question, true is returned; otherwise, false is returned.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT GetEventFilter(
            [In] ScriptDebugEventFilter eventFilter,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isBreakEnabled);

        /// <summary>
        /// The SetEventFilter method changes the "break on event" behavior for a particular event as defined by a member of the ScriptDebugEventFilter enumeration.<para/>
        /// A full list of available events (and a description of this enumeration) can be found in the documentation for the GetEventFilter method.<para/>
        /// If a particular event type is not supported by the script debugger, E_NOTIMPL may be returned. As long as the script debugger is enabled via a call to the StartDebugging method, it is legal to call this method.
        /// </summary>
        /// <param name="eventFilter">Indicates for which event the "break on event" behavior is being changed. The event is defined as a member of the ScriptDebugEventFilter enumeration.</param>
        /// <param name="isBreakEnabled">If true, indicates that the caller wants the debugger to break into the debugger when the given event occurs; if false, indicates that the caller does not want the debugger to break into the debugger when the given event occurs.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT SetEventFilter(
            [In] ScriptDebugEventFilter eventFilter,
            [In, MarshalAs(UnmanagedType.U1)] bool isBreakEnabled);

        /// <summary>
        /// The StartDebugging method "turns on" the debugger for a particular script. The act of starting debugging does not actively cause any execution break or stepping.<para/>
        /// It merely makes the script debuggable and provides a set of interfaces for the client to communicate with the debugging interface.<para/>
        /// The debug client which is passed to the StartDebugging method must be saved by the implementation. When any event occurs that "breaks into the debugger", that break is implemented by a synchronous call to notify the client of the event.<para/>
        /// Execution resumes when the client returns from notification call. A return argument indicates how execution should resume.<para/>
        /// This method should only be called when the script debugger is not enabled for the given script. Any other call is illegal.
        /// </summary>
        /// <param name="debugClient">An interface to the client of the script debugger. Debug events are passed to this interface.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT StartDebugging(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptDebugClient debugClient);

        /// <summary>
        /// The StopDebugging method is called by a client that wants to stop debugging. This method call may be made at any point after StartDebugging was made successfully (e.g.: during a break, while the script is executing, etc...).<para/>
        /// The call immediately ceases all debugging activity and resets the state back to before StartDebugging was called.
        /// </summary>
        /// <param name="debugClient">The debug client which is stopping debugging. This should match the debug client passed to the StartDebugging call.<para/>
        /// A non-matching client is an illegal call.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        [PreserveSig]
        HRESULT StopDebugging(
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScriptDebugClient debugClient);
    }
}
