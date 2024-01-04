using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The expression evaluator interface to the underlying debugger.
    /// </summary>
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("0FEF9A21-577E-4997-AC7B-1C4883241D99")]
    [ComImport]
    public interface IDebugHostEvaluator
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
        HRESULT EvaluateExpression(
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
        HRESULT EvaluateExtendedExpression(
            [In, MarshalAs(UnmanagedType.Interface)] IDebugHostContext context,
            [In, MarshalAs(UnmanagedType.LPWStr)] string expression,
            [In, MarshalAs(UnmanagedType.Interface)] IModelObject bindingContext,
            [Out, MarshalAs(UnmanagedType.Interface)] out IModelObject result,
            [Out, MarshalAs(UnmanagedType.Interface)] out IKeyStore metadata);
    }
}
