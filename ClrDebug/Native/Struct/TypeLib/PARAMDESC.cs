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
        /// The default value for the parameter, if <see cref="PARAMFLAG.PARAMFLAG_FHASDEFAULT"/> is specified in wParamFlags.<para/>
        /// This value is a pointer to a <see cref="PARAMDESCEX"/>.
        /// </summary>
        public IntPtr pparamdescex; //Can't be PARAMDESCEX as it contains an "object" field for the VARIANTARG

        /// <summary>
        /// Represents bitmask values that describe the structure element, parameter, or return value.
        /// </summary>
        public PARAMFLAG wParamFlags;
    }
}
