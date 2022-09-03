using System;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Describes how to transfer a structure element, parameter, or function return value between processes.
    /// </summary>
    [Flags]
    public enum PARAMFLAG : short
    {
        /// <summary>
        /// The parameter has custom data.
        /// </summary>
        PARAMFLAG_FHASCUSTDATA = 64, // 0x0040

        /// <summary>
        /// The parameter has default behaviors defined.
        /// </summary>
        PARAMFLAG_FHASDEFAULT = 32, // 0x0020

        /// <summary>
        /// The parameter passes information from the caller to the callee.
        /// </summary>
        /// 
        PARAMFLAG_FIN = 1,
        /// <summary>
        /// The parameter is the local identifier of a client application.
        /// </summary>
        PARAMFLAG_FLCID = 4,

        /// <summary>
        /// The parameter is optional.
        /// </summary>
        PARAMFLAG_FOPT = 16, // 0x0010

        /// <summary>
        /// The parameter returns information from the callee to the caller.
        /// </summary>
        PARAMFLAG_FOUT = 2,

        /// <summary>
        /// The parameter is the return value of the member.
        /// </summary>
        PARAMFLAG_FRETVAL = 8,

        /// <summary>
        /// Does not specify whether the parameter passes or receives information.
        /// </summary>
        PARAMFLAG_NONE = 0,
    }
}
