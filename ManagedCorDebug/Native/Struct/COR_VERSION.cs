using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Stores the standard four-part version number of the common language runtime.
    /// </summary>
    /// <remarks>
    /// If the version number is 1.0.3705.288, 1 is the major version number, 0 is the minor version number, 3705 is the
    /// build number, and 288 is the sub-build number.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_VERSION
    {
        /// <summary>
        /// The major version number.
        /// </summary>
        public uint dwMajor;

        /// <summary>
        /// The minor version number.
        /// </summary>
        public uint dwMinor;

        /// <summary>
        /// The build number.
        /// </summary>
        public uint dwBuild;

        /// <summary>
        /// The sub-build number.
        /// </summary>
        public uint dwSubBuild;
    }
}