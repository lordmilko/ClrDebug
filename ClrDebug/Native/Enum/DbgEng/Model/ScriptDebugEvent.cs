namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines what debug event occurred. A debug event is defined by a variant record known as a ScriptDebugEventInformation.<para/>
    /// Which fields in the event information are valid is largely defined by the DebugEvent member. It defines the kind of event which occurred as described by a member of the ScriptDebugEvent enumeration.
    /// </summary>
    /// <remarks>
    /// Whenever any event occurs which breaks into the script debugger, the debug code itself makes a call to the interface
    /// via the NotifyDebugEvent method. This method is synchronous. No execution of the script will resume until the interface
    /// returns from the event. The definition of the script debugger is intended to be simple: there are absolutely no
    /// nested events requiring processing.
    /// </remarks>
    public enum ScriptDebugEvent : uint
    {
        /// <summary>
        /// Indicates that a breakpoint was hit. Information about the particular breakpoint which was hit is contained in the BreakpointInformation portion of the union which contains the following:
        /// </summary>
        ScriptDebugBreakpoint,

        /// <summary>
        /// Indicates that a step event occurred. No further information is provided.
        /// </summary>
        ScriptDebugStep,

        /// <summary>
        /// Indicates that an exception occurred. Information about the particular exception which occurred is contained in the ExceptionInformaiton position of the union which contains the following: The data object for the event is the object which was thrown.<para/>
        /// The ScriptDebugEventInformation will fill in .u.ExceptionInformation and the outpassed object is a data model conversion of the actual exception.
        /// </summary>
        ScriptDebugException,

        /// <summary>
        /// Indicates that an asynchronous break into the script occurred. This might be because of something like "break on entry" or "break on event"
        /// </summary>
        ScriptDebugAsyncBreak
    }
}
