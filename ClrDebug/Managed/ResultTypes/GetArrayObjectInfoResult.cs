using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.GetArrayObjectInfo"/> method.
    /// </summary>
    [DebuggerDisplay("pDimensionSizes = {pDimensionSizes}, ppData = {ppData.ToString(),nq}")]
    public struct GetArrayObjectInfoResult
    {
        /// <summary>
        /// An array that contains integers, each representing the size of a dimension of the array.
        /// </summary>
        public int[] pDimensionSizes { get; }

        /// <summary>
        /// A pointer to the address of the raw buffer for the array, which is laid out according to the C++ convention.
        /// </summary>
        public IntPtr ppData { get; }

        public GetArrayObjectInfoResult(int[] pDimensionSizes, IntPtr ppData)
        {
            this.pDimensionSizes = pDimensionSizes;
            this.ppData = ppData;
        }
    }
}
