using System;
using System.Diagnostics;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Contains information about how to transfer a structure element, parameter, or function return value between processes.
    /// </summary>
    [DebuggerDisplay("pparamdescex = {pparamdescex.ToString(),nq}, wParamFlags = {wParamFlags.ToString(),nq}")]
    public unsafe struct PARAMDESC
    {
        /// <summary>
        /// The default value for the parameter, if <see cref="PARAMFLAG.PARAMFLAG_FHASDEFAULT"/> is specified in wParamFlags.
        /// </summary>
        public IntPtr pparamdescex; //PARAMDESCEX

        /// <summary>
        /// Represents bitmask values that describe the structure element, parameter, or return value.
        /// </summary>
        public PARAMFLAG wParamFlags;
    }
}
