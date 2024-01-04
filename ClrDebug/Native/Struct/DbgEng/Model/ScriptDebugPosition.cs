using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a position within a script.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ScriptDebugPosition
    {
        /// <summary>
        /// A zero value indicates that the line cannot be determined.
        /// </summary>
        public int Line;

        /// <summary>
        /// A zero value indicates that the column cannot be determined.
        /// </summary>
        public int Column;
    }
}
