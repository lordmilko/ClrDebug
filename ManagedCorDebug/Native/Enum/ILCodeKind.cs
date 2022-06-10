namespace ManagedCorDebug
{
    /// <summary>
    /// [Supported in the .NET Framework 4.5.2 and later versions] Provides values that specify whether the debugger is able to access local variables or code added in profiler ReJIT instrumentation.
    /// </summary>
    /// <remarks>
    /// A member of the <see cref="ILCodeKind"/> enumeration can be passed to the <see cref="ICorDebugILFrame4.EnumerateLocalVariablesEx"/>
    /// and <see cref="ICorDebugILFrame4.GetLocalVariableEx"/> methods to determine whether the debugger can access variables
    /// added in profiler ReJIT instrumentation, and to the <see cref="ICorDebugILFrame4.GetCodeEx"/> method to determine
    /// whether the debugger can access instrumented IL.
    /// </remarks>
    public enum ILCodeKind
    {
        /// <summary>
        /// The debugger does not have access to information from ReJIT instrumentation.
        /// </summary>
        ILCODE_ORIGINAL_IL = 1,

        /// <summary>
        /// The debugger has access to information from ReJIT instrumentation.
        /// </summary>
        ILCODE_REJIT_IL = 2
    }
}