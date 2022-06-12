using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugComObjectValue.GetCachedInterfacePointers"/> method.
    /// </summary>
    [DebuggerDisplay("pceltFetched = {pceltFetched}, ptrs = {ptrs}")]
    public struct GetCachedInterfacePointersResult
    {
        /// <summary>
        /// [out] A pointer to the number of <see cref="CORDB_ADDRESS"/> values actually returned in ptrs.
        /// </summary>
        public int pceltFetched { get; }

        /// <summary>
        /// A pointer to the starting address of an array of <see cref="CORDB_ADDRESS"/> values that contain the addresses of cached interface objects.
        /// </summary>
        public CORDB_ADDRESS[] ptrs { get; }

        public GetCachedInterfacePointersResult(int pceltFetched, CORDB_ADDRESS[] ptrs)
        {
            this.pceltFetched = pceltFetched;
            this.ptrs = ptrs;
        }
    }
}