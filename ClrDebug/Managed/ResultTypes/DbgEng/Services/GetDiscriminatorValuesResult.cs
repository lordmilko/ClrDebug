using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolVariantInfo.DiscriminatorValues"/> property.
    /// </summary>
    [DebuggerDisplay("pLowRange = {pLowRange}, pHighRange = {pHighRange}")]
    public struct GetDiscriminatorValuesResult
    {
        public object pLowRange { get; }

        public object pHighRange { get; }

        public GetDiscriminatorValuesResult(object pLowRange, object pHighRange)
        {
            this.pLowRange = pLowRange;
            this.pHighRange = pHighRange;
        }
    }
}
