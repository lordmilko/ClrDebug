using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SOSDacInterface.GetStackLimits"/> method.
    /// </summary>
    [DebuggerDisplay("lower = {lower}, upper = {upper}, fp = {fp}")]
    public struct GetStackLimitsResult
    {
        public CLRDATA_ADDRESS lower { get; }

        public CLRDATA_ADDRESS upper { get; }

        public CLRDATA_ADDRESS fp { get; }

        public GetStackLimitsResult(CLRDATA_ADDRESS lower, CLRDATA_ADDRESS upper, CLRDATA_ADDRESS fp)
        {
            this.lower = lower;
            this.upper = upper;
            this.fp = fp;
        }
    }
}