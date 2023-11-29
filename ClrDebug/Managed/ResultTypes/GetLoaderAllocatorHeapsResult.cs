using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetLoaderAllocatorHeaps"/> method.
    /// </summary>
    [DebuggerDisplay("pLoaderHeaps = {pLoaderHeaps}, pKinds = {pKinds}")]
    public struct GetLoaderAllocatorHeapsResult
    {
        public CLRDATA_ADDRESS[] pLoaderHeaps { get; }

        public LoaderHeapKind[] pKinds { get; }

        public GetLoaderAllocatorHeapsResult(CLRDATA_ADDRESS[] pLoaderHeaps, LoaderHeapKind[] pKinds)
        {
            this.pLoaderHeaps = pLoaderHeaps;
            this.pKinds = pKinds;
        }
    }
}
