using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetUserString"/> method.
    /// </summary>
    public struct GetUserStringResult
    {
        /// <summary>
        /// [out] A pointer to the size of ppData.
        /// </summary>
        public int pcbData { get; }

        /// <summary>
        /// [out] A pointer to a pointer to the returned string.
        /// </summary>
        public IntPtr ppData { get; }

        public GetUserStringResult(int pcbData, IntPtr ppData)
        {
            this.pcbData = pcbData;
            this.ppData = ppData;
        }
    }
}