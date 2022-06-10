using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Defines the product version of the common language runtime (CLR) for debugging purposes.
    /// </summary>
    /// <remarks>
    /// The <see cref="CLR_DEBUGGING_VERSION"/> structure is the same as the <see cref="COR_VERSION"/> structure, however, the <see cref="CLR_DEBUGGING_VERSION"/>
    /// structure provides an additional structure version field (wStructVersion). Currently, this field must be set to
    /// zero.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public struct CLR_DEBUGGING_VERSION
    {
        /// <summary>
        /// The structure version number
        /// </summary>
        public ushort wStructVersion;

        /// <summary>
        /// The major version number.
        /// </summary>
        public ushort wMajor;

        /// <summary>
        /// The minor version number.
        /// </summary>
        public ushort wMinor;

        /// <summary>
        /// The build number.
        /// </summary>
        public ushort wBuild;

        /// <summary>
        /// The revision number.
        /// </summary>
        public ushort wRevision;
    }
}