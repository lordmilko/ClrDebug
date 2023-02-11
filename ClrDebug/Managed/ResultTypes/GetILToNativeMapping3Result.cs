using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetILToNativeMapping3"/> method.
    /// </summary>
    [DebuggerDisplay("pcMap = {pcMap}, map = {map}")]
    public struct GetILToNativeMapping3Result
    {
        /// <summary>
        /// The total number of available COR_DEBUG_IL_TO_NATIVE_MAP structures.
        /// </summary>
        public int pcMap { get; }

        /// <summary>
        /// An array of COR_DEBUG_IL_TO_NATIVE_MAP structures, each of which specifies the offsets. After the GetILToNativeMapping3 method returns, map will contain some or all of the COR_DEBUG_IL_TO_NATIVE_MAP structures.
        /// </summary>
        public COR_DEBUG_IL_TO_NATIVE_MAP[] map { get; }

        public GetILToNativeMapping3Result(int pcMap, COR_DEBUG_IL_TO_NATIVE_MAP[] map)
        {
            this.pcMap = pcMap;
            this.map = map;
        }
    }
}
