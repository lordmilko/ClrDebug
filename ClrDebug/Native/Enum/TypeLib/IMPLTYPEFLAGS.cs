using System;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Defines the attributes of an implemented or inherited interface of a type.
    /// </summary>
    [Flags]
    public enum IMPLTYPEFLAGS
    {
        /// <summary>
        /// The interface or dispinterface represents the default for the source or sink.
        /// </summary>
        IMPLTYPEFLAG_FDEFAULT = 1,

        /// <summary>
        /// Sinks receive events through the virtual function table (VTBL).
        /// </summary>
        IMPLTYPEFLAG_FDEFAULTVTABLE = 8,

        /// <summary>
        /// The member should not be displayed or programmable by users.
        /// </summary>
        IMPLTYPEFLAG_FRESTRICTED = 4,

        /// <summary>
        /// This member of a coclass is called rather than implemented.
        /// </summary>
        IMPLTYPEFLAG_FSOURCE = 2,
    }
}
