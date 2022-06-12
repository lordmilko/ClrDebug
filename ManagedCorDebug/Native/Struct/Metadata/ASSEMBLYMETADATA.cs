using System;
using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains information about the referenced assembly, including its version and its level of support for locales, processors, and operating systems.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ASSEMBLYMETADATA
    {
        /// <summary>
        /// The major version number of the referenced assembly. This value cannot be zero. If all the bits of usMajorVersion are set, the major version is not specified.
        /// </summary>
        public ushort usMajorVersion;    // Major Version.

        /// <summary>
        /// The minor version number of the referenced assembly. This value cannot be zero. If all the bits of usMinorVersion are set, the minor version is not specified.
        /// </summary>
        public ushort usMinorVersion;    // Minor Version.

        /// <summary>
        /// The build number of the referenced assembly. This value cannot be zero. If all the bits of usBuildNumber are set, the build number is not specified.
        /// </summary>
        public ushort usBuildNumber;     // Build Number.

        /// <summary>
        /// The revision number of the referenced assembly. This value cannot be zero. If all the bits of usRevisionNumber are set, the revision number is not specified.
        /// </summary>
        public ushort usRevisionNumber;  // Revision Number.

        /// <summary>
        /// A list of locale names conforming to the RFC1766 specification, separated by semicolons, specifying the locales supported by the referenced assembly.<para/>
        /// A null value indicates locale independence. Note: In the .NET Framework version 1.0 you cannot specify more than one locale.
        /// </summary>
        public IntPtr szLocale;          // Locale.

        /// <summary>
        /// The size in wide characters of szLocale.
        /// </summary>
        public int cbLocale;        // [IN/OUT] Size of the deployablesBuffer in wide chars/Actual size.
        public IntPtr rProcessor;        // Processor ID array.

        /// <summary>
        /// The length of the rdwProcessor array.
        /// </summary>
        public int ulProcessor;         // [IN/OUT] Size of the Processor ID array/Actual # of entries filled in.

        /// <summary>
        /// An array of <see cref="OSINFO"/> instances specifying the operating systems that are supported by the referenced assembly.<para/>
        /// A NULL value indicates operating-system independence.
        /// </summary>
        public IntPtr rOS;           // OSINFO array.

        /// <summary>
        /// The length of the rOS array.
        /// </summary>
        public int ulOS;            // [IN/OUT]Size of the OSINFO array/Actual # of entries filled in.
    }
}