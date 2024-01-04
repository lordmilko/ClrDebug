using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcSymbolDiscriminatorValuesEnumerator.Next"/> property.
    /// </summary>
    [DebuggerDisplay("pLowValue = {pLowValue}, pHighValue = {pHighValue}")]
    public struct SvcSymbolDiscriminatorValuesEnumerator_GetNextResult
    {
        public object pLowValue { get; }

        public object pHighValue { get; }

        public SvcSymbolDiscriminatorValuesEnumerator_GetNextResult(object pLowValue, object pHighValue)
        {
            this.pLowValue = pLowValue;
            this.pHighValue = pHighValue;
        }
    }
}
