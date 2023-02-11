using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetClassIDInfo2"/> method.
    /// </summary>
    [DebuggerDisplay("pModuleId = {pModuleId.ToString(),nq}, pTypeDefToken = {pTypeDefToken.ToString(),nq}, pParentClassId = {pParentClassId.ToString(),nq}, typeArgs = {typeArgs}")]
    public struct GetClassIDInfo2Result
    {
        /// <summary>
        /// Pointer to the ID of the parent module for the open generic definition of the specified class.
        /// </summary>
        public ModuleID pModuleId { get; }

        /// <summary>
        /// Pointer to the metadata token for the open generic definition of the specified class.
        /// </summary>
        public mdTypeDef pTypeDefToken { get; }

        /// <summary>
        /// Pointer to the ID of the parent class.
        /// </summary>
        public ClassID pParentClassId { get; }

        /// <summary>
        /// An array of ClassID values, each of which represents the ID of a type argument of the class. When the method returns, typeArgs will contain some or all the available ClassID values.
        /// </summary>
        public ClassID[] typeArgs { get; }

        public GetClassIDInfo2Result(ModuleID pModuleId, mdTypeDef pTypeDefToken, ClassID pParentClassId, ClassID[] typeArgs)
        {
            this.pModuleId = pModuleId;
            this.pTypeDefToken = pTypeDefToken;
            this.pParentClassId = pParentClassId;
            this.typeArgs = typeArgs;
        }
    }
}
