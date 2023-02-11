using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.IsArrayClass"/> method.
    /// </summary>
    [DebuggerDisplay("pBaseElemType = {pBaseElemType.ToString(),nq}, pBaseClassId = {pBaseClassId.ToString(),nq}, pcRank = {pcRank}")]
    public struct IsArrayClassResult
    {
        /// <summary>
        /// A pointer to a value of the CorElementType enumeration that indicates the type of the array elements.
        /// </summary>
        public CorElementType pBaseElemType { get; }

        /// <summary>
        /// A pointer to the class ID of the array elements, when available.
        /// </summary>
        public ClassID pBaseClassId { get; }

        /// <summary>
        /// A pointer to an integer that indicates the rank (that is, number of dimensions) of the array.
        /// </summary>
        public int pcRank { get; }

        public IsArrayClassResult(CorElementType pBaseElemType, ClassID pBaseClassId, int pcRank)
        {
            this.pBaseElemType = pBaseElemType;
            this.pBaseClassId = pBaseClassId;
            this.pcRank = pcRank;
        }
    }
}
