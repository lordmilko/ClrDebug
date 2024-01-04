using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugHostModule.Version"/> property.
    /// </summary>
    [DebuggerDisplay("fileVersion = {fileVersion}, productVersion = {productVersion}")]
    public struct GetVersionResult
    {
        /// <summary>
        /// If a non-nullptr address is supplied, the file version of the module will be returned here. If the file version cannot be read from the module headers, this method will fail if a non-nullptr address is provided here.<para/>
        /// If the file version cannot be read from the module headers and this value is provided as nullptr, it will not cause a failure.
        /// </summary>
        public long fileVersion { get; }

        /// <summary>
        /// If a non-nullptr address is supplied, the product version of the module as indicated in the module headers is returned here.<para/>
        /// If the product version cannot be read from the module headers, this method will fail if a non-nullptr address is provided here.<para/>
        /// If the product version cannot be read from the module headers and this value is provided as nullptr, it will not cause a failure.
        /// </summary>
        public long productVersion { get; }

        public GetVersionResult(long fileVersion, long productVersion)
        {
            this.fileVersion = fileVersion;
            this.productVersion = productVersion;
        }
    }
}
