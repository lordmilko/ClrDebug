using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="SvcOSPlatformInformation.OSVersion"/> property.
    /// </summary>
    [DebuggerDisplay("pMajor = {pMajor}, pMinor = {pMinor}, pBuild = {pBuild}, pRevision = {pRevision}")]
    public struct GetOSVersionResult
    {
        public short pMajor { get; }

        public short pMinor { get; }

        public short pBuild { get; }

        public short pRevision { get; }

        public GetOSVersionResult(short pMajor, short pMinor, short pBuild, short pRevision)
        {
            this.pMajor = pMajor;
            this.pMinor = pMinor;
            this.pBuild = pBuild;
            this.pRevision = pRevision;
        }
    }
}
