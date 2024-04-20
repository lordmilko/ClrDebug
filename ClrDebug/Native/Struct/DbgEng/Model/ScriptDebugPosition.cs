using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// Defines a position within a script.
    /// </summary>
    [DebuggerDisplay("Line = {Line}, Column = {Column}")]
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
