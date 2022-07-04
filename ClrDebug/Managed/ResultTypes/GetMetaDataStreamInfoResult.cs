using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.GetMetaDataStreamInfo"/> method.
    /// </summary>
    [DebuggerDisplay("ppchName = {ppchName}, ppv = {ppv.ToString(),nq}, pcb = {pcb}")]
    public struct GetMetaDataStreamInfoResult
    {
        /// <summary>
        /// A pointer to the name of the stream.
        /// </summary>
        public string ppchName { get; }

        /// <summary>
        /// A pointer to the metadata stream.
        /// </summary>
        public IntPtr ppv { get; }

        /// <summary>
        /// The size, in bytes, of ppv.
        /// </summary>
        public int pcb { get; }

        public GetMetaDataStreamInfoResult(string ppchName, IntPtr ppv, int pcb)
        {
            this.ppchName = ppchName;
            this.ppv = ppv;
            this.pcb = pcb;
        }
    }
}
