using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("D2419F4A-7E8D-4C15-A499-73902B015ABB")]
    [ComImport]
    public interface IDebugHostEvaluator3 : IDebugHostEvaluator2
    {
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
        /// <param name="result">The resulting value of the expression evaluation will be returned here.</param>
        /// <param name="metadata">Any metadata associated with the expression or result is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT EvaluateExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

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
        /// <param name="result">The resulting value of the expression evaluation will be returned here.</param>
        /// <param name="metadata">Any metadata associated with the expression or result is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT EvaluateExtendedExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);

        /// <summary>
        /// The AssignTo method performs assignment according to the semantics of the language being debugged.
        /// </summary>
        /// <param name="assignmentReference">A reference to the thing being assigned. While this can be either a model based reference (e.g.: an ObjectTargetObjectReference) or a language reference (e.g.: a C++ &amp;), it must be some type of reference (an LVALUE).</param>
        /// <param name="assignmentValue">The value being assigned to what is referenced via the assignmentReference argument. Note that this value may be coerced or converted according to language rules before being assigned.</param>
        /// <param name="assignmentResult">The result of assignment, if successful. If not, optionally, an extended error object indicating why the assignment failed.<para/>
        /// Note that result of assignment in this case is what the language defines as the result of an assignment operation.<para/>
        /// For C++, this would be a language reference to the thing assigned.</param>
        /// <param name="assignmentMetadata">Any optional metadata associated with the assignment result is returned here.</param>
        /// <returns>This method returns HRESULT which indicates success or failure.</returns>
        [PreserveSig]
        new HRESULT AssignTo(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject assignmentReference,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject assignmentValue,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject assignmentResult,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore assignmentMetadata);
        
        [PreserveSig]
        HRESULT Compare(
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pLeft,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject pRight,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject ppResult);
    }
}
