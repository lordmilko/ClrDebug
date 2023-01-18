using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.IsTrackedType"/> method.
    /// </summary>
    [DebuggerDisplay("isTrackedType = {isTrackedType}, hasTaggedMemory = {hasTaggedMemory}")]
    public struct IsTrackedTypeResult
    {
        public bool isTrackedType { get; }

        public bool hasTaggedMemory { get; }

        public IsTrackedTypeResult(bool isTrackedType, bool hasTaggedMemory)
        {
            this.isTrackedType = isTrackedType;
            this.hasTaggedMemory = hasTaggedMemory;
        }
    }
}
