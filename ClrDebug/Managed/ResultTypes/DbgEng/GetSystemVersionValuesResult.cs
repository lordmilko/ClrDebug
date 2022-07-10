using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.SystemVersionValues"/> property.
    /// </summary>
    [DebuggerDisplay("PlatformId = {PlatformId}, Win32Major = {Win32Major}, Win32Minor = {Win32Minor}, KdMajor = {KdMajor}, KdMinor = {KdMinor}")]
    public struct GetSystemVersionValuesResult
    {
        /// <summary>
        /// Receives the platform ID. PlatformId is always VER_PLATFORM_WIN32_NT for NT-based Windows.
        /// </summary>
        public uint PlatformId { get; }

        /// <summary>
        /// Receives the major version number of the target's operating system. For Windows 2000, Windows XP, and Windows Server 2003, this number is 5.<para/>
        /// For Windows Vista, Windows 7, and Windows 8, this number is 6.
        /// </summary>
        public uint Win32Major { get; }

        /// <summary>
        /// Receives the minor version number for the target's operating system. For Windows 2000 this is 0; for Windows XP, 1; for Windows Server 2003, 2.<para/>
        /// For Windows Vista, this is 0; for Windows 7, 1; for Windows 8, 2.
        /// </summary>
        public uint Win32Minor { get; }

        /// <summary>
        /// Receives 0xF if the target's operating system is a free build, and 0xC if it is a checked build.
        /// </summary>
        public uint KdMajor { get; }

        /// <summary>
        /// Receives the build number for the target's operating system.
        /// </summary>
        public uint KdMinor { get; }

        public GetSystemVersionValuesResult(uint platformId, uint win32Major, uint win32Minor, uint kdMajor, uint kdMinor)
        {
            PlatformId = platformId;
            Win32Major = win32Major;
            Win32Minor = win32Minor;
            KdMajor = kdMajor;
            KdMinor = kdMinor;
        }
    }
}
