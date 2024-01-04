namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface to a stack in the script. The script provider implements this interface to expose the notion of a call stack to the script debugger.
    /// </summary>
    public class DataModelScriptDebugStack : ComObject<IDataModelScriptDebugStack>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptDebugStack"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptDebugStack(IDataModelScriptDebugStack raw) : base(raw)
        {
        }

        #region IDataModelScriptDebugStack
        #region FrameCount

        /// <summary>
        /// The GetFrameCount method returns the number of stack frames in this segment of the call stack. If the provider can detect frames in different script contexts or of different providers, it should indicate this to the caller by implementation of the IsTransitionPoint and GetTransition methods on the entry frame into this stack segment.
        /// </summary>
        public long FrameCount
        {
            get
            {
                /*long GetFrameCount();*/
                return Raw.GetFrameCount();
            }
        }

        #endregion
        #region GetStackFrame

        /// <summary>
        /// The GetStackFrame gets a particular stack frame from the stack segment. The call stack has a zero based indexing system: the current stack frame where the break event occurred is frame 0.<para/>
        /// The caller of the current method is frame 1 (and so forth).
        /// </summary>
        /// <param name="frameNumber">The zero based index of the stack frame within this stack segment to retrieve. The top frame representing the current point where the debugger broke is frame 0.<para/>
        /// It's caller is frame 1 (and so forth).</param>
        /// <returns>An interface to the given stack frame will be returned here.</returns>
        public DataModelScriptDebugStackFrame GetStackFrame(long frameNumber)
        {
            DataModelScriptDebugStackFrame stackFrameResult;
            TryGetStackFrame(frameNumber, out stackFrameResult).ThrowDbgEngNotOK();

            return stackFrameResult;
        }

        /// <summary>
        /// The GetStackFrame gets a particular stack frame from the stack segment. The call stack has a zero based indexing system: the current stack frame where the break event occurred is frame 0.<para/>
        /// The caller of the current method is frame 1 (and so forth).
        /// </summary>
        /// <param name="frameNumber">The zero based index of the stack frame within this stack segment to retrieve. The top frame representing the current point where the debugger broke is frame 0.<para/>
        /// It's caller is frame 1 (and so forth).</param>
        /// <param name="stackFrameResult">An interface to the given stack frame will be returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetStackFrame(long frameNumber, out DataModelScriptDebugStackFrame stackFrameResult)
        {
            /*HRESULT GetStackFrame(
            [In] long frameNumber,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugStackFrame stackFrame);*/
            IDataModelScriptDebugStackFrame stackFrame;
            HRESULT hr = Raw.GetStackFrame(frameNumber, out stackFrame);

            if (hr == HRESULT.S_OK)
                stackFrameResult = stackFrame == null ? null : new DataModelScriptDebugStackFrame(stackFrame);
            else
                stackFrameResult = default(DataModelScriptDebugStackFrame);

            return hr;
        }

        #endregion
        #endregion
    }
}
