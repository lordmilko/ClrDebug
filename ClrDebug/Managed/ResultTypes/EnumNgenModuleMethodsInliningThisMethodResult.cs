using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.EnumNgenModuleMethodsInliningThisMethod"/> method.
    /// </summary>
    [DebuggerDisplay("incompleteData = {incompleteData}, ppEnum = {ppEnum?.ToString(),nq}")]
    public struct EnumNgenModuleMethodsInliningThisMethodResult
    {
        /// <summary>
        /// A flag that indicates whether ppEnum contains all methods inlining a given method. See the Remarks section for more information.
        /// </summary>
        public bool incompleteData { get; }

        /// <summary>
        /// A pointer to the address of an enumerator
        /// </summary>
        public CorProfilerMethodEnum ppEnum { get; }

        public EnumNgenModuleMethodsInliningThisMethodResult(bool incompleteData, CorProfilerMethodEnum ppEnum)
        {
            this.incompleteData = incompleteData;
            this.ppEnum = ppEnum;
        }
    }
}
