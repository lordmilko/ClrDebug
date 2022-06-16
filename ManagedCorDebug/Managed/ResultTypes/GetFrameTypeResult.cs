using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="XCLRDataStackWalk.FrameType"/> property.
    /// </summary>
    [DebuggerDisplay("simpleType = {simpleType}, detailedType = {detailedType}")]
    public struct GetFrameTypeResult
    {
        public CLRDataSimpleFrameType simpleType { get; }

        public CLRDataDetailedFrameType detailedType { get; }

        public GetFrameTypeResult(CLRDataSimpleFrameType simpleType, CLRDataDetailedFrameType detailedType)
        {
            this.simpleType = simpleType;
            this.detailedType = detailedType;
        }
    }
}