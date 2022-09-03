using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Encapsulates the results of the <see cref="TypeInfo.ContainingTypeLib"/> property.
    /// </summary>
    [DebuggerDisplay("ppTLB = {ppTLB.ToString(),nq}, pIndex = {pIndex}")]
    public struct GetContainingTypeLibResult
    {
        /// <summary>
        /// When this method returns, contains a reference to the containing type library. This parameter is passed uninitialized.
        /// </summary>
        public ComTypeLib ppTLB { get; }

        /// <summary>
        /// When this method returns, contains a reference to the index of the type description within the containing type library. This parameter is passed uninitialized.
        /// </summary>
        public int pIndex { get; }

        public GetContainingTypeLibResult(ComTypeLib ppTLB, int pIndex)
        {
            this.ppTLB = ppTLB;
            this.pIndex = pIndex;
        }
    }
}
