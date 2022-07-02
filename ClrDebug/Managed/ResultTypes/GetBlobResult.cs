using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetBlob"/> method.
    /// </summary>
    [DebuggerDisplay("pcbData = {pcbData}, ppData = {ppData.ToString(),nq}")]
    public struct GetBlobResult
    {
        /// <summary>
        /// A pointer to the size, in bytes, of ppData.
        /// </summary>
        public int pcbData { get; }

        /// <summary>
        /// A pointer to a pointer to the binary data retrieved.
        /// </summary>
        public IntPtr ppData { get; }

        public GetBlobResult(int pcbData, IntPtr ppData)
        {
            this.pcbData = pcbData;
            this.ppData = ppData;
        }
    }
}