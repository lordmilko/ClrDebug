using System.Diagnostics;

namespace ClrDebug.DIA
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DiaEnumSymbolsByAddr.Prev"/> method.
    /// </summary>
    [DebuggerDisplay("rgelt = {rgelt.ToString(),nq}, pceltFetched = {pceltFetched}")]
    public struct PrevResult
    {
        /// <summary>
        /// An array that is to be filled in with IDiaSymbol objects that represent the desired symbols.
        /// </summary>
        public DiaSymbol rgelt { get; }

        /// <summary>
        /// Returns the number of symbols in the fetched enumerator.
        /// </summary>
        public int pceltFetched { get; }

        public PrevResult(DiaSymbol rgelt, int pceltFetched)
        {
            this.rgelt = rgelt;
            this.pceltFetched = pceltFetched;
        }
    }
}
