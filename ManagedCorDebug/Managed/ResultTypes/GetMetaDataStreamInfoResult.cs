using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetMetaDataStreamInfo"/> method.
    /// </summary>
    [DebuggerDisplay("ppv = {ppv}, pcb = {pcb}")]
    public struct GetMetaDataStreamInfoResult
    {
        /// <summary>
        /// A pointer to the metadata stream.
        /// </summary>
        public IntPtr ppv { get; }

        /// <summary>
        /// The size, in bytes, of ppv.
        /// </summary>
        public int pcb { get; }

        public GetMetaDataStreamInfoResult(IntPtr ppv, int pcb)
        {
            this.ppv = ppv;
            this.pcb = pcb;
        }
    }
}