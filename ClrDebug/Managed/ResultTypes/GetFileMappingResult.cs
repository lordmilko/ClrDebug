using System;
using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="MetaDataInfo.FileMapping"/> property.
    /// </summary>
    [DebuggerDisplay("ppvData = {ppvData.ToString(),nq}, pcbData = {pcbData}, pdwMappingType = {pdwMappingType.ToString(),nq}")]
    public struct GetFileMappingResult
    {
        /// <summary>
        /// A pointer to the start of the mapped file.
        /// </summary>
        public IntPtr ppvData { get; }

        /// <summary>
        /// The size of the mapped region. If pdwMappingType is fmFlat, this is the size of the file.
        /// </summary>
        public long pcbData { get; }

        /// <summary>
        /// A <see cref="CorFileMapping"/> value that indicates the type of mapping. The current implementation of the common language runtime (CLR) always returns fmFlat.<para/>
        /// Other values are reserved for future use. However, you should always verify the returned value, because other values may be enabled in future versions or service releases.
        /// </summary>
        public CorFileMapping pdwMappingType { get; }

        public GetFileMappingResult(IntPtr ppvData, long pcbData, CorFileMapping pdwMappingType)
        {
            this.ppvData = ppvData;
            this.pcbData = pcbData;
            this.pdwMappingType = pdwMappingType;
        }
    }
}
