using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.EventMask2"/> property.
    /// </summary>
    [DebuggerDisplay("pdwEventsLow = {pdwEventsLow.ToString(),nq}, pdwEventsHigh = {pdwEventsHigh.ToString(),nq}")]
    public struct GetEventMask2Result
    {
        /// <summary>
        /// A pointer to a 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_MONITOR enumeration.
        /// </summary>
        public COR_PRF_MONITOR pdwEventsLow { get; }

        /// <summary>
        /// A pointer to a 4-byte value that specifies the categories of events. Each bit controls a different capability, behavior, or type of event.<para/>
        /// The bits are described in the COR_PRF_HIGH_MONITOR enumeration.
        /// </summary>
        public COR_PRF_HIGH_MONITOR pdwEventsHigh { get; }

        public GetEventMask2Result(COR_PRF_MONITOR pdwEventsLow, COR_PRF_HIGH_MONITOR pdwEventsHigh)
        {
            this.pdwEventsLow = pdwEventsLow;
            this.pdwEventsHigh = pdwEventsHigh;
        }
    }
}
