using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetFunctionInfo2"/> method.
    /// </summary>
    [DebuggerDisplay("pClassId = {pClassId.ToString(),nq}, pModuleId = {pModuleId.ToString(),nq}, pToken = {pToken.ToString(),nq}, typeArgs = {typeArgs}")]
    public struct GetFunctionInfo2Result
    {
        /// <summary>
        /// A pointer to the parent class of the function.
        /// </summary>
        public ClassID pClassId { get; }

        /// <summary>
        /// A pointer to the module in which the function's parent class is defined.
        /// </summary>
        public ModuleID pModuleId { get; }

        /// <summary>
        /// A pointer to the metadata token for the function.
        /// </summary>
        public mdToken pToken { get; }

        /// <summary>
        /// An array of ClassID values, each of which is the ID of a type argument of the function. When the method returns, typeArgs will contain some or all of the ClassID values.
        /// </summary>
        public ClassID[] typeArgs { get; }

        public GetFunctionInfo2Result(ClassID pClassId, ModuleID pModuleId, mdToken pToken, ClassID[] typeArgs)
        {
            this.pClassId = pClassId;
            this.pModuleId = pModuleId;
            this.pToken = pToken;
            this.typeArgs = typeArgs;
        }
    }
}
