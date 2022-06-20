using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetTaggedMemory"/> method.
    /// </summary>
    [DebuggerDisplay("taggedMemory = {taggedMemory.ToString(),nq}, taggedMemorySizeInBytes = {taggedMemorySizeInBytes}")]
    public struct GetTaggedMemoryResult
    {
        public CLRDATA_ADDRESS taggedMemory { get; }

        public long taggedMemorySizeInBytes { get; }

        public GetTaggedMemoryResult(CLRDATA_ADDRESS taggedMemory, long taggedMemorySizeInBytes)
        {
            this.taggedMemory = taggedMemory;
            this.taggedMemorySizeInBytes = taggedMemorySizeInBytes;
        }
    }
}