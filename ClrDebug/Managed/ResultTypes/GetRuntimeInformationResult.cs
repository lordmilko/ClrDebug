using System.Diagnostics;

namespace ClrDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorProfilerInfo.RuntimeInformation"/> property.
    /// </summary>
    [DebuggerDisplay("pClrInstanceId = {pClrInstanceId}, pRuntimeType = {pRuntimeType.ToString(),nq}, pMajorVersion = {pMajorVersion}, pMinorVersion = {pMinorVersion}, pBuildNumber = {pBuildNumber}, pQFEVersion = {pQFEVersion}, szVersionString = {szVersionString}")]
    public struct GetRuntimeInformationResult
    {
        /// <summary>
        /// The representative ID of a running CLR instance in a process. This is the same as the ClrInstanceID that the event tracing for Windows (ETW) startup event reports.
        /// </summary>
        public ushort pClrInstanceId { get; }

        /// <summary>
        /// The runtime type. This parameter returns COR_PRF_DESKTOP_CLR for the desktop version of the CLR, or COR_PRF_CORE_CLR for the core version of the CLR used in Silverlight.
        /// </summary>
        public COR_PRF_RUNTIME_TYPE pRuntimeType { get; }

        /// <summary>
        /// The major version number of the CLR.
        /// </summary>
        public ushort pMajorVersion { get; }

        /// <summary>
        /// The minor version number of the CLR.
        /// </summary>
        public ushort pMinorVersion { get; }

        /// <summary>
        /// The build version number of the CLR.
        /// </summary>
        public ushort pBuildNumber { get; }

        /// <summary>
        /// The version number of the CLR that is associated with a software update.
        /// </summary>
        public ushort pQFEVersion { get; }

        /// <summary>
        /// The CLR version string.
        /// </summary>
        public string szVersionString { get; }

        public GetRuntimeInformationResult(ushort pClrInstanceId, COR_PRF_RUNTIME_TYPE pRuntimeType, ushort pMajorVersion, ushort pMinorVersion, ushort pBuildNumber, ushort pQFEVersion, string szVersionString)
        {
            this.pClrInstanceId = pClrInstanceId;
            this.pRuntimeType = pRuntimeType;
            this.pMajorVersion = pMajorVersion;
            this.pMinorVersion = pMinorVersion;
            this.pBuildNumber = pBuildNumber;
            this.pQFEVersion = pQFEVersion;
            this.szVersionString = szVersionString;
        }
    }
}
