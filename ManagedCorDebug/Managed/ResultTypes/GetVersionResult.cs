using System.Diagnostics;

namespace ManagedCorDebug
{
    /// <summary>
    /// Encapsulates the results of the <see cref="CorDebugMergedAssemblyRecord.Version"/> property.
    /// </summary>
    [DebuggerDisplay("pMajor = {pMajor}, pMinor = {pMinor}, pBuild = {pBuild}, pRevision = {pRevision}")]
    public struct GetVersionResult
    {
        /// <summary>
        /// A pointer to the major version number.
        /// </summary>
        public ushort pMajor { get; }

        /// <summary>
        /// A pointer to the minor version number.
        /// </summary>
        public ushort pMinor { get; }

        /// <summary>
        /// A pointer to the build number.
        /// </summary>
        public ushort pBuild { get; }

        /// <summary>
        /// A pointer to the revision number.
        /// </summary>
        public ushort pRevision { get; }

        public GetVersionResult(ushort pMajor, ushort pMinor, ushort pBuild, ushort pRevision)
        {
            this.pMajor = pMajor;
            this.pMinor = pMinor;
            this.pBuild = pBuild;
            this.pRevision = pRevision;
        }
    }
}