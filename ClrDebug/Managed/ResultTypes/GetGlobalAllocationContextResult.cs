using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GlobalAllocationContext"/> property.
    /// </summary>
    [DebuggerDisplay("allocPtr = {allocPtr.ToString(),nq}, allocLimit = {allocLimit.ToString(),nq}")]
    public struct GetGlobalAllocationContextResult
    {
        public CLRDATA_ADDRESS allocPtr { get; }

        public CLRDATA_ADDRESS allocLimit { get; }

        public GetGlobalAllocationContextResult(CLRDATA_ADDRESS allocPtr, CLRDATA_ADDRESS allocLimit)
        {
            this.allocPtr = allocPtr;
            this.allocLimit = allocLimit;
        }
    }
}
