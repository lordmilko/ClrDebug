using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Provides a unique representation of a function by combining its ID with the ID of its recompiled version.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct COR_PRF_FUNCTION
    {
        /// <summary>
        /// The ID of the function.
        /// </summary>
        public FunctionID functionId;

        /// <summary>
        /// The ID of the recompiled function. A value of 0 (zero) represents the original version of the function.
        /// </summary>
        public ReJITID reJitId;
    }
}
