using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugILCode.GetInstrumentedILMap"/> method.
    /// </summary>
    [DebuggerDisplay("pcMap = {pcMap}, map = {map}")]
    public struct GetInstrumentedILMapResult
    {
        /// <summary>
        /// [out] The number of <see cref="COR_IL_MAP"/> values written to the map array.
        /// </summary>
        public int pcMap { get; }

        /// <summary>
        /// [out] An array of <see cref="COR_IL_MAP"/> values that provide information on mappings from profiler-instrumented IL to the IL of the original method.
        /// </summary>
        public COR_IL_MAP[] map { get; }

        public GetInstrumentedILMapResult(int pcMap, COR_IL_MAP[] map)
        {
            this.pcMap = pcMap;
            this.map = map;
        }
    }
}