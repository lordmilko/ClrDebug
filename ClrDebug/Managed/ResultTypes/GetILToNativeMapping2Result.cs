using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetILToNativeMapping2"/> method.
    /// </summary>
    [DebuggerDisplay("pcMap = {pcMap}, map = {map.ToString(),nq}")]
    public struct GetILToNativeMapping2Result
    {
        /// <summary>
        /// The total number of available COR_DEBUG_IL_TO_NATIVE_MAP structures.
        /// </summary>
        public int pcMap { get; }

        /// <summary>
        /// An array of COR_DEBUG_IL_TO_NATIVE_MAP structures, each of which specifies the offsets. After the GetILToNativeMapping2 method returns, map will contain some or all of the COR_DEBUG_IL_TO_NATIVE_MAP structures.
        /// </summary>
        public COR_DEBUG_IL_TO_NATIVE_MAP map { get; }

        public GetILToNativeMapping2Result(int pcMap, COR_DEBUG_IL_TO_NATIVE_MAP map)
        {
            this.pcMap = pcMap;
            this.map = map;
        }
    }
}
