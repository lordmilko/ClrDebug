using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.IsTrackedType"/> method.
    /// </summary>
    [DebuggerDisplay("isTrackedType = {isTrackedType}, hasTaggedMemory = {hasTaggedMemory}")]
    public struct IsTrackedTypeResult
    {
        public int isTrackedType { get; }

        public int hasTaggedMemory { get; }

        public IsTrackedTypeResult(int isTrackedType, int hasTaggedMemory)
        {
            this.isTrackedType = isTrackedType;
            this.hasTaggedMemory = hasTaggedMemory;
        }
    }
}
