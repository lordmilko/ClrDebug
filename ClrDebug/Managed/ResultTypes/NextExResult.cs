using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaEnumSymbolsByAddr.NextEx"/> method.
    /// </summary>
    [DebuggerDisplay("rgelt = {rgelt.ToString(),nq}, pceltFetched = {pceltFetched}")]
    public struct NextExResult
    {
        public DiaSymbol rgelt { get; }

        public int pceltFetched { get; }

        public NextExResult(DiaSymbol rgelt, int pceltFetched)
        {
            this.rgelt = rgelt;
            this.pceltFetched = pceltFetched;
        }
    }
}
