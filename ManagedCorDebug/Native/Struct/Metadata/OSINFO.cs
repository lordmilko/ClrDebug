﻿using System.Runtime.InteropServices;

namespace ManagedCorDebug
{
    /// <summary>
    /// Contains details about the operating system for an assembly or module.
    /// </summary>
    /// <remarks>
    /// OSINFO is based on the OSVERSIONINFOEX structure that is used in calls to the Microsoft Windows platform function
    /// GetVersionEx. This structure is used by the ASSEMBLYMETADATA structure to indicate its operating system support.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct OSINFO
    {
        /// <summary>
        /// One of the identifier values defined by the Microsoft Windows platform function GetVersionEx. The following values are supported:<para/>
        /// -   VER_PLATFORM_WIN32s, or 0x0000, to specify Microsoft Windows 3.1.<para/>
        /// -   VER_PLATFORM_WIN32_WINDOWS, or 0x0001, to specify Windows 95, Windows 98, or operating systems descended from them.<para/>
        /// -   VER_PLATFORM_WIN32_NT, or 0x0002, to specify Windows NT or operating systems descended from it.
        /// </summary>
        public uint dwOSPlatformId;     // Operating system platform.

        /// <summary>
        /// The operating system major version, or a NULL value to indicate any version.
        /// </summary>
        public uint dwOSMajorVersion;   // OS Major version.

        /// <summary>
        /// The operating system minor version, or a NULL value to indicate any version.
        /// </summary>
        public uint dwOSMinorVersion;   // OS Minor version.
    }
}