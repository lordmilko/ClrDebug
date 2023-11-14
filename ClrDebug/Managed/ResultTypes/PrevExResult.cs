using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaEnumSymbolsByAddr.PrevEx"/> method.
    /// </summary>
    [DebuggerDisplay("rgelt = {rgelt.ToString(),nq}, pceltFetched = {pceltFetched}")]
    public struct PrevExResult
    {
        public DiaSymbol rgelt { get; }

        public int pceltFetched { get; }

        public PrevExResult(DiaSymbol rgelt, int pceltFetched)
        {
            this.rgelt = rgelt;
            this.pceltFetched = pceltFetched;
        }
    }
}
