﻿using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug
{
    /// <summary>
    /// Stores the standard four-part version number of the common language runtime.
    /// </summary>
    /// <remarks>
    /// If the version number is 1.0.3705.288, 1 is the major version number, 0 is the minor version number, 3705 is the
    /// build number, and 288 is the sub-build number.
    /// </remarks>
    [DebuggerDisplay("dwMajor = {dwMajor}, dwMinor = {dwMinor}, dwBuild = {dwBuild}, dwSubBuild = {dwSubBuild}")]
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct COR_VERSION
    {
        /// <summary>
        /// The major version number.
        /// </summary>
        public int dwMajor;

        /// <summary>
        /// The minor version number.
        /// </summary>
        public int dwMinor;

        /// <summary>
        /// The build number.
        /// </summary>
        public int dwBuild;

        /// <summary>
        /// The sub-build number.
        /// </summary>
        public int dwSubBuild;
    }
}
