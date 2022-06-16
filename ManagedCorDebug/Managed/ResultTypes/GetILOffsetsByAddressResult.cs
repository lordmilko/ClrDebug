using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataMethodInstance.GetILOffsetsByAddress"/> method.
    /// </summary>
    [DebuggerDisplay("offsetsNeeded = {offsetsNeeded}, ilOffsets = {ilOffsets}")]
    public struct GetILOffsetsByAddressResult
    {
        public int offsetsNeeded { get; }

        public int ilOffsets { get; }

        public GetILOffsetsByAddressResult(int offsetsNeeded, int ilOffsets)
        {
            this.offsetsNeeded = offsetsNeeded;
            this.ilOffsets = ilOffsets;
        }
    }
}