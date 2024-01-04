namespace ClrDebug.DbgEng
{
    /// <summary>
    /// An interface to a stack frame in the script. The script provider implements this interface to expose the notion of a particular stack frame within the call stack.
    /// </summary>
    public class DataModelScriptDebugStackFrame : ComObject<IDataModelScriptDebugStackFrame>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataModelScriptDebugStackFrame"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DataModelScriptDebugStackFrame(IDataModelScriptDebugStackFrame raw) : base(raw)
        {
        }

        #region IDataModelScriptDebugStackFrame
        #region Name

        /// <summary>
        /// The GetName method returns the display name (e.g.: function name) of this frame. Such name will be displayed within the stack backtrace presented to the user in the debugger interface.
        /// </summary>
        public string Name
        {
            get
            {
                string name;
                TryGetName(out name).ThrowDbgEngNotOK();

                return name;
            }
        }

        /// <summary>
        /// The GetName method returns the display name (e.g.: function name) of this frame. Such name will be displayed within the stack backtrace presented to the user in the debugger interface.
        /// </summary>
        /// <param name="name">The display name (e.g.: function name) of the frame is returned here as a string allocated via the SysAllocString method.<para/>
        /// The caller is responsible for freeing this string with SysFreeString.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetName(out string name)
        {
            /*HRESULT GetName(
            [Out, MarshalAs(UnmanagedType.BStr)] out string name);*/
            return Raw.GetName(out name);
        }

        #endregion
        #region Position

        /// <summary>
        /// The GetPosition method returns the position within the script represented by the stack frame. This method may only be called when the script is within a break represented by the stack in which this frame is contained.<para/>
        /// The line and column position within this frame is always returned. If the debugger is capable of returning the span of the "execution position" within the script, an ending position can be returned in the positionSpanEnd argument.<para/>
        /// If the debugger is not capable of this, the line and column values in the span end (if requested) should be set to zero.<para/>
        /// The line of text (or the span of text) representing this frame can optionally be passed back by debuggers which support it.<para/>
        /// While it is strongly recommended that script debuggers make every attempt to return this text, there is no requirement that such debuggers return more than the line and column position of the frame.<para/>
        /// If return text is not supported, a nullptr can be returned in the lineText argument.
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
        /// The GetPosition method returns the position within the script represented by the stack frame. This method may only be called when the script is within a break represented by the stack in which this frame is contained.<para/>
        /// The line and column position within this frame is always returned. If the debugger is capable of returning the span of the "execution position" within the script, an ending position can be returned in the positionSpanEnd argument.<para/>
        /// If the debugger is not capable of this, the line and column values in the span end (if requested) should be set to zero.<para/>
        /// The line of text (or the span of text) representing this frame can optionally be passed back by debuggers which support it.<para/>
        /// While it is strongly recommended that script debuggers make every attempt to return this text, there is no requirement that such debuggers return more than the line and column position of the frame.<para/>
        /// If return text is not supported, a nullptr can be returned in the lineText argument.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
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
        #region IsTransitionPoint

        /// <summary>
        /// The <see cref="IDataModelScriptDebugStack"/> interface represents a segment of a call stack -- that portion of the call stack which is contained within the context of one script.<para/>
        /// If the debugger is capable of detecting the transition from one script to another (or one script provider to another), it can indicate this by implementing the IsTransitionPoint method and returning true or false as appropriate.<para/>
        /// The call stack frame which entered the script where the segment applies should be considered a transition point.<para/>
        /// All other frames are not. It is perfectly legal for any script debugger which is incapable of doing cross-script debugging or detection to simply return E_NOTIMPL from this method.<para/>
        /// In such cases, the debug interface may only be able to show a stack backtrace for the current script even if the overall call stack spans multiple scripts.
        /// </summary>
        public bool IsTransitionPoint
        {
            get
            {
                bool isTransitionPoint;
                TryIsTransitionPoint(out isTransitionPoint).ThrowDbgEngNotOK();

                return isTransitionPoint;
            }
        }

        /// <summary>
        /// The <see cref="IDataModelScriptDebugStack"/> interface represents a segment of a call stack -- that portion of the call stack which is contained within the context of one script.<para/>
        /// If the debugger is capable of detecting the transition from one script to another (or one script provider to another), it can indicate this by implementing the IsTransitionPoint method and returning true or false as appropriate.<para/>
        /// The call stack frame which entered the script where the segment applies should be considered a transition point.<para/>
        /// All other frames are not. It is perfectly legal for any script debugger which is incapable of doing cross-script debugging or detection to simply return E_NOTIMPL from this method.<para/>
        /// In such cases, the debug interface may only be able to show a stack backtrace for the current script even if the overall call stack spans multiple scripts.
        /// </summary>
        /// <param name="isTransitionPoint">If this stack frame is the first frame which entered a particular script or script provider, it should return true here indicating that the frame is a transition point from one script/provider to another.<para/>
        /// For any other stack frame, false should be returned.</param>
        /// <returns>This method returns HRESULT which indicates success or failure. Debuggers which are incapable of detecting transition points may return E_NOTIMPL from this method.</returns>
        public HRESULT TryIsTransitionPoint(out bool isTransitionPoint)
        {
            /*HRESULT IsTransitionPoint(
            [Out, MarshalAs(UnmanagedType.U1)] out bool isTransitionPoint);*/
            return Raw.IsTransitionPoint(out isTransitionPoint);
        }

        #endregion
        #region Transition

        /// <summary>
        /// If a given stack frame is a transition point as determined by the IsTransition method (see the documentation there for a definition of transition points), the GetTransition method returns information about the transition.<para/>
        /// In particular, this method returns the previous script -- the one which made a call into the script represented by the stack segment containing this <see cref="IDataModelScriptDebugStackFrame"/>.<para/>
        /// In addition to returning the <see cref="IDataModelScript"/> interface for the previous script, this call is expected to make an attempt to determine whether the transition is contiguous or not.<para/>
        /// A contiguous transition is one where one script/provider directly called another (ignoring whatever proxy/stub code may exist to facilitate communication between script contexts).<para/>
        /// A non-contiguous transition is one where there is intermediate code -- either native or another script/provider which cannot be detected -- in between.<para/>
        /// An example of a contiguous transition stack (where all properties are extensions on the same object): An example of a non-contiguous transition stack (where all properties are extensions on the same object) where we imagine two different script providers -- one JavaScript and one Python: In the second case, it is entirely possible that the debugger for the imagined JavaScript debugger can see get firstProperty and get secondProperty without visibility into get intermediateProperty because it is an entirely different script provider (an imagined Python one here).<para/>
        /// The script debugger may indicate in the GetTransition method that the transition was from Script1 to Script2 as a non-contiguous transition.<para/>
        /// If the overall debug interface is capable of stitching together information for the imagined Python portion, it will do so.<para/>
        /// The imagined JavaScript provider simply indicates the discontinuity.
        /// </summary>
        public GetTransitionResult Transition
        {
            get
            {
                GetTransitionResult result;
                TryGetTransition(out result).ThrowDbgEngNotOK();

                return result;
            }
        }

        /// <summary>
        /// If a given stack frame is a transition point as determined by the IsTransition method (see the documentation there for a definition of transition points), the GetTransition method returns information about the transition.<para/>
        /// In particular, this method returns the previous script -- the one which made a call into the script represented by the stack segment containing this <see cref="IDataModelScriptDebugStackFrame"/>.<para/>
        /// In addition to returning the <see cref="IDataModelScript"/> interface for the previous script, this call is expected to make an attempt to determine whether the transition is contiguous or not.<para/>
        /// A contiguous transition is one where one script/provider directly called another (ignoring whatever proxy/stub code may exist to facilitate communication between script contexts).<para/>
        /// A non-contiguous transition is one where there is intermediate code -- either native or another script/provider which cannot be detected -- in between.<para/>
        /// An example of a contiguous transition stack (where all properties are extensions on the same object): An example of a non-contiguous transition stack (where all properties are extensions on the same object) where we imagine two different script providers -- one JavaScript and one Python: In the second case, it is entirely possible that the debugger for the imagined JavaScript debugger can see get firstProperty and get secondProperty without visibility into get intermediateProperty because it is an entirely different script provider (an imagined Python one here).<para/>
        /// The script debugger may indicate in the GetTransition method that the transition was from Script1 to Script2 as a non-contiguous transition.<para/>
        /// If the overall debug interface is capable of stitching together information for the imagined Python portion, it will do so.<para/>
        /// The imagined JavaScript provider simply indicates the discontinuity.
        /// </summary>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryGetTransition(out GetTransitionResult result)
        {
            /*HRESULT GetTransition(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScript transitionScript,
            [Out, MarshalAs(UnmanagedType.U1)] out bool isTransitionContiguous);*/
            IDataModelScript transitionScript;
            bool isTransitionContiguous;
            HRESULT hr = Raw.GetTransition(out transitionScript, out isTransitionContiguous);

            if (hr == HRESULT.S_OK)
                result = new GetTransitionResult(transitionScript == null ? null : new DataModelScript(transitionScript), isTransitionContiguous);
            else
                result = default(GetTransitionResult);

            return hr;
        }

        #endregion
        #region Evaluate

        /// <summary>
        /// The Evaluate method evaluates an expression (of the language of the script provider) in the context of the stack frame represented by the <see cref="IDataModelScriptDebugStackFrame"/> interface on which this method was called.<para/>
        /// The result of the expression evaluation must be marshaled out of the script provider as an <see cref="IModelObject"/>.<para/>
        /// The properties and other constructs on the resulting <see cref="IModelObject"/> must all be able to be acquired while the debugger is in a break state.
        /// </summary>
        /// <param name="pwszExpression">An expression (of the language of the script provider) to evaluate in the context of the stack frame represented by the <see cref="IDataModelScriptDebugStackFrame"/> on which this method was called.</param>
        /// <returns>The result of the expression evaluation. The script provider construct must be marshaled out to an <see cref="IModelObject"/> representation and all properties and constructs on that object must be able to be acquired while the debugger is in a break state.</returns>
        public ModelObject Evaluate(string pwszExpression)
        {
            ModelObject ppResultResult;
            TryEvaluate(pwszExpression, out ppResultResult).ThrowDbgEngNotOK();

            return ppResultResult;
        }

        /// <summary>
        /// The Evaluate method evaluates an expression (of the language of the script provider) in the context of the stack frame represented by the <see cref="IDataModelScriptDebugStackFrame"/> interface on which this method was called.<para/>
        /// The result of the expression evaluation must be marshaled out of the script provider as an <see cref="IModelObject"/>.<para/>
        /// The properties and other constructs on the resulting <see cref="IModelObject"/> must all be able to be acquired while the debugger is in a break state.
        /// </summary>
        /// <param name="pwszExpression">An expression (of the language of the script provider) to evaluate in the context of the stack frame represented by the <see cref="IDataModelScriptDebugStackFrame"/> on which this method was called.</param>
        /// <param name="ppResultResult">The result of the expression evaluation. The script provider construct must be marshaled out to an <see cref="IModelObject"/> representation and all properties and constructs on that object must be able to be acquired while the debugger is in a break state.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryEvaluate(string pwszExpression, out ModelObject ppResultResult)
        {
            /*HRESULT Evaluate(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszExpression,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult);*/
            IModelObject ppResult;
            HRESULT hr = Raw.Evaluate(pwszExpression, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new ModelObject(ppResult);
            else
                ppResultResult = default(ModelObject);

            return hr;
        }

        #endregion
        #region EnumerateLocals

        /// <summary>
        /// The EnumerateLocals method returns a variable set (represented by an <see cref="IDataModelScriptDebugVariableSetEnumerator"/> interface) for all local variables which are in scope in the context of the stack frame represented by the <see cref="IDataModelScriptDebugStackFrame"/> interface on which this method was called.<para/>
        /// Note that if there are multiple definitions of a single variable where an inner scope eclipses an outer scope, only a single definition should be returned -- the definition which is in scope at the code position represented by the frame.
        /// </summary>
        /// <returns>A variable set enumerator which enumerates all in-scope local variables at the code position represented by the stack frame.</returns>
        public DataModelScriptDebugVariableSetEnumerator EnumerateLocals()
        {
            DataModelScriptDebugVariableSetEnumerator variablesEnumResult;
            TryEnumerateLocals(out variablesEnumResult).ThrowDbgEngNotOK();

            return variablesEnumResult;
        }

        /// <summary>
        /// The EnumerateLocals method returns a variable set (represented by an <see cref="IDataModelScriptDebugVariableSetEnumerator"/> interface) for all local variables which are in scope in the context of the stack frame represented by the <see cref="IDataModelScriptDebugStackFrame"/> interface on which this method was called.<para/>
        /// Note that if there are multiple definitions of a single variable where an inner scope eclipses an outer scope, only a single definition should be returned -- the definition which is in scope at the code position represented by the frame.
        /// </summary>
        /// <param name="variablesEnumResult">A variable set enumerator which enumerates all in-scope local variables at the code position represented by the stack frame.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryEnumerateLocals(out DataModelScriptDebugVariableSetEnumerator variablesEnumResult)
        {
            /*HRESULT EnumerateLocals(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugVariableSetEnumerator variablesEnum);*/
            IDataModelScriptDebugVariableSetEnumerator variablesEnum;
            HRESULT hr = Raw.EnumerateLocals(out variablesEnum);

            if (hr == HRESULT.S_OK)
                variablesEnumResult = variablesEnum == null ? null : new DataModelScriptDebugVariableSetEnumerator(variablesEnum);
            else
                variablesEnumResult = default(DataModelScriptDebugVariableSetEnumerator);

            return hr;
        }

        #endregion
        #region EnumerateArguments

        /// <summary>
        /// Enumerates arguments to the function in this frame. The EnumerateArguments method returns a variable set (represented by an <see cref="IDataModelScriptDebugVariableSetEnumerator"/> interface) for all function arguments of the function called in the stack frame represented by the <see cref="IDataModelScriptDebugStackFrame"/> interface on which this method was called.
        /// </summary>
        /// <returns>A variable set enumerator which enumerates all function arguments of the function called in the given stack frame.</returns>
        public DataModelScriptDebugVariableSetEnumerator EnumerateArguments()
        {
            DataModelScriptDebugVariableSetEnumerator variablesEnumResult;
            TryEnumerateArguments(out variablesEnumResult).ThrowDbgEngNotOK();

            return variablesEnumResult;
        }

        /// <summary>
        /// Enumerates arguments to the function in this frame. The EnumerateArguments method returns a variable set (represented by an <see cref="IDataModelScriptDebugVariableSetEnumerator"/> interface) for all function arguments of the function called in the stack frame represented by the <see cref="IDataModelScriptDebugStackFrame"/> interface on which this method was called.
        /// </summary>
        /// <param name="variablesEnumResult">A variable set enumerator which enumerates all function arguments of the function called in the given stack frame.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryEnumerateArguments(out DataModelScriptDebugVariableSetEnumerator variablesEnumResult)
        {
            /*HRESULT EnumerateArguments(
            [Out, MarshalAs(UnmanagedType.Interface)] out IDataModelScriptDebugVariableSetEnumerator variablesEnum);*/
            IDataModelScriptDebugVariableSetEnumerator variablesEnum;
            HRESULT hr = Raw.EnumerateArguments(out variablesEnum);

            if (hr == HRESULT.S_OK)
                variablesEnumResult = variablesEnum == null ? null : new DataModelScriptDebugVariableSetEnumerator(variablesEnum);
            else
                variablesEnumResult = default(DataModelScriptDebugVariableSetEnumerator);

            return hr;
        }

        #endregion
        #endregion

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
