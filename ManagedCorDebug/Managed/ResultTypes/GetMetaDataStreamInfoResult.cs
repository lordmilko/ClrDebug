using System;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetMetaDataStreamInfo"/> method.
    /// </summary>
    public struct GetMetaDataStreamInfoResult
    {
        /// <summary>
        /// [out] A pointer to the metadata stream.
        /// </summary>
        public IntPtr ppv { get; }

        /// <summary>
        /// [out] The size, in bytes, of ppv.
        /// </summary>
        public int pcb { get; }

        public GetMetaDataStreamInfoResult(IntPtr ppv, int pcb)
        {
            this.ppv = ppv;
            this.pcb = pcb;
        }
    }
}