namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The client of the script debugger implements this interface as a part of a two-way communication channel with the script debugger.<para/>
    /// The user interface which wishes to provide the capability of script debugging implements the IDataModelScriptDebugClient interface.<para/>
    /// The script provider utilizes this interface to pass debug information back and forth (e.g.: events which occur, breakpoints, etc...)
    /// </summary>
    public class DataModelScriptDebugClient : ComObject<IDataModelScriptDebugClient>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptDebugClient"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptDebugClient(IDataModelScriptDebugClient raw) : base(raw)
        {
        }

        #region IDataModelScriptDebugClient
        #region NotifyDebugEvent

        /// <summary>
        /// Whenever any event occurs which breaks into the script debugger, the debug code itself makes a call to the interface via the NotifyDebugEvent method.<para/>
        /// This method is synchronous. No execution of the script will resume until the interface returns from the event. The definition of the script debugger is intended to be simple: there are absolutely no nested events requiring processing.<para/>
        /// A debug event is defined by a variant record known as a ScriptDebugEventInformation. Which fields in the event information are valid is largely defined by the DebugEvent member.<para/>
        /// It defines the kind of event which occurred as described by a member of the ScriptDebugEvent enumeration: When the interface decides how it wants to proceed from the debug event, it fills in the resumeEventKind argument and returns successfully from the NotifyDebugEvent method.<para/>
        /// How the debugger proceeds depends on the value in this field. It is a member of the ScriptExecutionKind enumeration defined as follows:
        /// </summary>
        /// <param name="pEventInfo">A data structure indicating what debug event has just occurred.</param>
        /// <param name="pScript">The script in which the event occurred.</param>
        /// <param name="pEventDataObject">The data object for the event in question. If the event has no data object, nullptr is passed. A data object is, for example, the exception object which was thrown for an exception notification.</param>
        /// <param name="resumeEventKind">An indication from the interface to the debugger of how the debugger should resume execution of script code after the processing of the debug event.<para/>
        /// Such is returned as a member of the ScriptExecutionKind enumeration as described above.</param>
        public void NotifyDebugEvent(ScriptDebugEventInformation pEventInfo, IDataModelScript pScript, IModelObject pEventDataObject, ref ScriptExecutionKind resumeEventKind)
        {
            TryNotifyDebugEvent(pEventInfo, pScript, pEventDataObject, ref resumeEventKind).ThrowDbgEngNotOK();
        }

        /// <summary>
        /// Whenever any event occurs which breaks into the script debugger, the debug code itself makes a call to the interface via the NotifyDebugEvent method.<para/>
        /// This method is synchronous. No execution of the script will resume until the interface returns from the event. The definition of the script debugger is intended to be simple: there are absolutely no nested events requiring processing.<para/>
        /// A debug event is defined by a variant record known as a ScriptDebugEventInformation. Which fields in the event information are valid is largely defined by the DebugEvent member.<para/>
        /// It defines the kind of event which occurred as described by a member of the ScriptDebugEvent enumeration: When the interface decides how it wants to proceed from the debug event, it fills in the resumeEventKind argument and returns successfully from the NotifyDebugEvent method.<para/>
        /// How the debugger proceeds depends on the value in this field. It is a member of the ScriptExecutionKind enumeration defined as follows:
        /// </summary>
        /// <param name="pEventInfo">A data structure indicating what debug event has just occurred.</param>
        /// <param name="pScript">The script in which the event occurred.</param>
        /// <param name="pEventDataObject">The data object for the event in question. If the event has no data object, nullptr is passed. A data object is, for example, the exception object which was thrown for an exception notification.</param>
        /// <param name="resumeEventKind">An indication from the interface to the debugger of how the debugger should resume execution of script code after the processing of the debug event.<para/>
        /// Such is returned as a member of the ScriptExecutionKind enumeration as described above.</param>
        /// <returns>This method returns HRESULT that indicates success or failure.</returns>
        public HRESULT TryNotifyDebugEvent(ScriptDebugEventInformation pEventInfo, IDataModelScript pScript, IModelObject pEventDataObject, ref ScriptExecutionKind resumeEventKind)
        {
            /*HRESULT NotifyDebugEvent(
            [In] ref ScriptDebugEventInformation pEventInfo,
            [In, MarshalAs(UnmanagedType.Interface)] IDataModelScript pScript,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pEventDataObject,
            [In, Out] ref ScriptExecutionKind resumeEventKind);*/
            return Raw.NotifyDebugEvent(ref pEventInfo, pScript, pEventDataObject, ref resumeEventKind);
        }

        #endregion
        #endregion
    }
}
