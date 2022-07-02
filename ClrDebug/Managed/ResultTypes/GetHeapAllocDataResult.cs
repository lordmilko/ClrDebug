using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetHeapAllocData"/> method.
    /// </summary>
    [DebuggerDisplay("data = {data.ToString(),nq}, pNeeded = {pNeeded}")]
    public struct GetHeapAllocDataResult
    {
        public DacpGenerationAllocData data { get; }

        public int pNeeded { get; }

        public GetHeapAllocDataResult(DacpGenerationAllocData data, int pNeeded)
        {
            this.data = data;
            this.pNeeded = pNeeded;
        }
    }
}