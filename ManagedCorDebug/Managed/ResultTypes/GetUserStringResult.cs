using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetUserString"/> method.
    /// </summary>
    [DebuggerDisplay("pcbData = {pcbData}, ppData = {ppData}")]
    public struct GetUserStringResult
    {
        /// <summary>
        /// A pointer to the size of ppData.
        /// </summary>
        public int pcbData { get; }

        /// <summary>
        /// A pointer to a pointer to the returned string.
        /// </summary>
        public IntPtr ppData { get; }

        public GetUserStringResult(int pcbData, IntPtr ppData)
        {
            this.pcbData = pcbData;
            this.ppData = ppData;
        }
    }
}