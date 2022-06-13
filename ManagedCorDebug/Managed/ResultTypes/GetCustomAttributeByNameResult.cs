using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataImport.GetCustomAttributeByName"/> method.
    /// </summary>
    [DebuggerDisplay("ppData = {ppData}, pcbData = {pcbData}")]
    public struct GetCustomAttributeByNameResult
    {
        /// <summary>
        /// A pointer to an array of data that is the value of the custom attribute.
        /// </summary>
        public IntPtr ppData { get; }

        /// <summary>
        /// The size in bytes of the data returned in *ppData.
        /// </summary>
        public int pcbData { get; }

        public GetCustomAttributeByNameResult(IntPtr ppData, int pcbData)
        {
            this.ppData = ppData;
            this.pcbData = pcbData;
        }
    }
}