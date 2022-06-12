using System;
using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataTables.MetaDataStorage"/> property.
    /// </summary>
    [DebuggerDisplay("ppvMd = {ppvMd}, pcbMd = {pcbMd}")]
    public struct GetMetaDataStorageResult
    {
        /// <summary>
        /// [in, out] A pointer to a metadata section.
        /// </summary>
        public IntPtr ppvMd { get; }

        /// <summary>
        /// [out] The size of the metadata stream.
        /// </summary>
        public int pcbMd { get; }

        public GetMetaDataStorageResult(IntPtr ppvMd, int pcbMd)
        {
            this.ppvMd = ppvMd;
            this.pcbMd = pcbMd;
        }
    }
}