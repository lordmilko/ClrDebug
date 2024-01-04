using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The expression evaluator interface to the underlying debugger.
    /// </summary>
    public class DebugHostEvaluator : ComObject<IDebugHostEvaluator>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugHostEvaluator"/> class.
        /// </summary>
        /// <param name="raw">The raw COM interface that should be contained in this object.</param>
        public DebugHostEvaluator(IDebugHostEvaluator raw) : base(raw)
        {
        }

        #region IDebugHostEvaluator
        #region EvaluateExpression

        /// <summary>
        /// The EvaluateExpression method allows requests the debug host to evaluate a language (e.g.: C++) expression and return the resulting value of that expression evaluation boxed as an <see cref="IModelObject"/>.<para/>
        /// This particular variant of the method only allows language constructs. Any additional functionality which is presented within the expression evaluator of the debug host that is not present in the language (e.g.: LINQ query methods) is turned off for the evaluation.<para/>
        /// Because this method only uses things which are defined by the language being debugged, this method is portable and safe to use from host to host.<para/>
        /// A debug host which implements debugging for a particular language should evaluate an expression via this method in the same way as any other host which debugs the same language.<para/>
        /// As such, this is the preferred method for doing expression evaluation.
        /// </summary>
        /// <param name="context">The host context in which the expression evaluation occurs. If there are, for instance, memory reads of the target due to pointer dereferences, the address space in which those memory reads are made is given by this argument.</param>
        /// <param name="expression">The language expression to be evaluated. This string may only contain an expression which is valid in the language being debugged.<para/>
        /// It may not contain any additional constructs which may be available in the debug host's expression evaluator.</param>
        /// <param name="bindingContext">The binding context in which symbol (variable) names will be looked up. For C++, this is semantically equivalent to the this pointer value.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EvaluateExpressionResult EvaluateExpression(IDebugHostContext context, string expression, IModelObject bindingContext)
        {
            EvaluateExpressionResult result;
            TryEvaluateExpression(context, expression, bindingContext, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The EvaluateExpression method allows requests the debug host to evaluate a language (e.g.: C++) expression and return the resulting value of that expression evaluation boxed as an <see cref="IModelObject"/>.<para/>
        /// This particular variant of the method only allows language constructs. Any additional functionality which is presented within the expression evaluator of the debug host that is not present in the language (e.g.: LINQ query methods) is turned off for the evaluation.<para/>
        /// Because this method only uses things which are defined by the language being debugged, this method is portable and safe to use from host to host.<para/>
        /// A debug host which implements debugging for a particular language should evaluate an expression via this method in the same way as any other host which debugs the same language.<para/>
        /// As such, this is the preferred method for doing expression evaluation.
        /// </summary>
        /// <param name="context">The host context in which the expression evaluation occurs. If there are, for instance, memory reads of the target due to pointer dereferences, the address space in which those memory reads are made is given by this argument.</param>
        /// <param name="expression">The language expression to be evaluated. This string may only contain an expression which is valid in the language being debugged.<para/>
        /// It may not contain any additional constructs which may be available in the debug host's expression evaluator.</param>
        /// <param name="bindingContext">The binding context in which symbol (variable) names will be looked up. For C++, this is semantically equivalent to the this pointer value.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryEvaluateExpression(IDebugHostContext context, string expression, IModelObject bindingContext, out EvaluateExpressionResult result)
        {
            /*HRESULT EvaluateExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject _result;
            IKeyStore metadata;
            HRESULT hr = Raw.EvaluateExpression(context, expression, bindingContext, out _result, out metadata);

            if (hr == HRESULT.S_OK)
                result = new EvaluateExpressionResult(_result == null ? null : new ModelObject(_result), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(EvaluateExpressionResult);

            return hr;
        }

        #endregion
        #region EvaluateExtendedExpression

        /// <summary>
        /// The EvaluateExtendedExpression method is similar to the EvaluateExpression method except that it turns back on additional non-language functionality which a particular debug host chooses to add to its expression evaluator.<para/>
        /// For Debugging Tools for Windows, for example, this enables anonymous types, LINQ queries, module qualifiers, format specifiers, and other non-C/C++ functionality.<para/>
        /// It is important to note that there is no guarantee that an expression which evaluates against one host via EvaluateExtendedExpression will evaluate correctly against another host which debugs the same language.<para/>
        /// Extensions in the expression evaluator are the purview of a given host. It is strongly recommended that clients utilize the EvaluateExpression method instead of the EvaluateExtendedExpression method for this exact reason.<para/>
        /// Using this method reduces the portability of the caller.
        /// </summary>
        /// <param name="context">The host context in which the expression evaluation occurs. If there are, for instance, memory reads of the target due to pointer dereferences, the address space in which those memory reads are made is given by this argument.</param>
        /// <param name="expression">The expression to be evaluated. This may use host private extensions to the language syntax.</param>
        /// <param name="bindingContext">The binding context in which symbol (variable) names will be looked up. For C++, this is semantically equivalent to the this pointer value.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public EvaluateExtendedExpressionResult EvaluateExtendedExpression(IDebugHostContext context, string expression, IModelObject bindingContext)
        {
            EvaluateExtendedExpressionResult result;
            TryEvaluateExtendedExpression(context, expression, bindingContext, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The EvaluateExtendedExpression method is similar to the EvaluateExpression method except that it turns back on additional non-language functionality which a particular debug host chooses to add to its expression evaluator.<para/>
        /// For Debugging Tools for Windows, for example, this enables anonymous types, LINQ queries, module qualifiers, format specifiers, and other non-C/C++ functionality.<para/>
        /// It is important to note that there is no guarantee that an expression which evaluates against one host via EvaluateExtendedExpression will evaluate correctly against another host which debugs the same language.<para/>
        /// Extensions in the expression evaluator are the purview of a given host. It is strongly recommended that clients utilize the EvaluateExpression method instead of the EvaluateExtendedExpression method for this exact reason.<para/>
        /// Using this method reduces the portability of the caller.
        /// </summary>
        /// <param name="context">The host context in which the expression evaluation occurs. If there are, for instance, memory reads of the target due to pointer dereferences, the address space in which those memory reads are made is given by this argument.</param>
        /// <param name="expression">The expression to be evaluated. This may use host private extensions to the language syntax.</param>
        /// <param name="bindingContext">The binding context in which symbol (variable) names will be looked up. For C++, this is semantically equivalent to the this pointer value.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryEvaluateExtendedExpression(IDebugHostContext context, string expression, IModelObject bindingContext, out EvaluateExtendedExpressionResult result)
        {
            /*HRESULT EvaluateExtendedExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);*/
            IModelObject _result;
            IKeyStore metadata;
            HRESULT hr = Raw.EvaluateExtendedExpression(context, expression, bindingContext, out _result, out metadata);

            if (hr == HRESULT.S_OK)
                result = new EvaluateExtendedExpressionResult(_result == null ? null : new ModelObject(_result), metadata == null ? null : new KeyStore(metadata));
            else
                result = default(EvaluateExtendedExpressionResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostEvaluator2

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostEvaluator2 Raw2 => (IDebugHostEvaluator2) Raw;

        #region AssignTo

        /// <summary>
        /// The AssignTo method performs assignment according to the semantics of the language being debugged.
        /// </summary>
        /// <param name="assignmentReference">A reference to the thing being assigned. While this can be either a model based reference (e.g.: an ObjectTargetObjectReference) or a language reference (e.g.: a C++ &amp;), it must be some type of reference (an LVALUE).</param>
        /// <param name="assignmentValue">The value being assigned to what is referenced via the assignmentReference argument. Note that this value may be coerced or converted according to language rules before being assigned.</param>
        /// <returns>The values that were emitted from the COM method.</returns>
        public AssignToResult AssignTo(IModelObject assignmentReference, IModelObject assignmentValue)
        {
            AssignToResult result;
            TryAssignTo(assignmentReference, assignmentValue, out result).ThrowDbgEngNotOK();

            return result;
        }

        /// <summary>
        /// The AssignTo method performs assignment according to the semantics of the language being debugged.
        /// </summary>
        /// <param name="assignmentReference">A reference to the thing being assigned. While this can be either a model based reference (e.g.: an ObjectTargetObjectReference) or a language reference (e.g.: a C++ &amp;), it must be some type of reference (an LVALUE).</param>
        /// <param name="assignmentValue">The value being assigned to what is referenced via the assignmentReference argument. Note that this value may be coerced or converted according to language rules before being assigned.</param>
        /// <param name="result">The values that were emitted from the COM method.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        public HRESULT TryAssignTo(IModelObject assignmentReference, IModelObject assignmentValue, out AssignToResult result)
        {
            /*HRESULT AssignTo(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject assignmentReference,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject assignmentValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject assignmentResult,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore assignmentMetadata);*/
            IModelObject assignmentResult;
            IKeyStore assignmentMetadata;
            HRESULT hr = Raw2.AssignTo(assignmentReference, assignmentValue, out assignmentResult, out assignmentMetadata);

            if (hr == HRESULT.S_OK)
                result = new AssignToResult(assignmentResult == null ? null : new ModelObject(assignmentResult), assignmentMetadata == null ? null : new KeyStore(assignmentMetadata));
            else
                result = default(AssignToResult);

            return hr;
        }

        #endregion
        #endregion
        #region IDebugHostEvaluator3

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public IDebugHostEvaluator3 Raw3 => (IDebugHostEvaluator3) Raw;

        #region Compare

        public ModelObject Compare(IModelObject pLeft, IModelObject pRight)
        {
            ModelObject ppResultResult;
            TryCompare(pLeft, pRight, out ppResultResult).ThrowDbgEngNotOK();

            return ppResultResult;
        }

        public HRESULT TryCompare(IModelObject pLeft, IModelObject pRight, out ModelObject ppResultResult)
        {
            /*HRESULT Compare(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pLeft,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pRight,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult);*/
            IModelObject ppResult;
            HRESULT hr = Raw3.Compare(pLeft, pRight, out ppResult);

            if (hr == HRESULT.S_OK)
                ppResultResult = ppResult == null ? null : new ModelObject(ppResult);
            else
                ppResultResult = default(ModelObject);

            return hr;
        }

        #endregion
        #endregion
    }
}
