using System.Diagnostics;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Encapsulates the results of the <see cref="DebugControl.SystemVersion"/> property.
    /// </summary>
    [DebuggerDisplay("PlatformId = {PlatformId}, Major = {Major}, Minor = {Minor}, ServicePackString = {ServicePackString}, ServicePackNumber = {ServicePackNumber}, BuildString = {BuildString}")]
    public struct GetSystemVersionResult
    {
        /// <summary>
        /// Receives the platform ID. PlatformId is always VER_PLATFORM_WIN32_NT for NT-based Windows.
        /// </summary>
        public uint PlatformId { get; }

        /// <summary>
        /// Receives 0xF if the target's operating system is a free build, or 0xC if the operating system is a checked build.
        /// </summary>
        public uint Major { get; }

        /// <summary>
        /// Receives the build number for the target's operating system.
        /// </summary>
        public uint Minor { get; }

        /// <summary>
        /// Receives the string for the service pack level of the target computer. If ServicePackString is NULL, this information is not returned.<para/>
        /// If no service pack is installed, ServicePackString can be empty.
        /// </summary>
        public string ServicePackString { get; }

        /// <summary>
        /// Receives the service pack level of the target's operating system.
        /// </summary>
        public uint ServicePackNumber { get; }

        /// <summary>
        /// Receives the string that identifies the build of the system. If BuildString is NULL, this information is not returned.
        /// </summary>
        public string BuildString { get; }

        public GetSystemVersionResult(uint platformId, uint major, uint minor, string servicePackString, uint servicePackNumber, string buildString)
        {
            PlatformId = platformId;
            Major = major;
            Minor = minor;
            ServicePackString = servicePackString;
            ServicePackNumber = servicePackNumber;
            BuildString = buildString;
        }
    }
}
