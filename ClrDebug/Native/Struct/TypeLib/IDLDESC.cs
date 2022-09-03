using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Contains information needed for transferring a structure element, parameter, or function return value between processes.
    /// </summary>
    [DebuggerDisplay("dwReserved = {dwReserved.ToString(),nq}, wIDLFlags = {wIDLFlags.ToString(),nq}")]
    public struct IDLDESC
    {
        /// <summary>
        /// Reserved; set to null.
        /// </summary>
        public IntPtr dwReserved;

        /// <summary>
        /// Indicates an <see cref="IDLFLAG"/> value describing the type.
        /// </summary>
        public IDLFLAG wIDLFlags;
    }
}
