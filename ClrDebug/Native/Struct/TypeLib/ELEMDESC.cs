using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Contains the type description and process transfer information for a variable, function, or a function parameter.
    /// </summary>
    [DebuggerDisplay("tdesc = {tdesc.ToString(),nq}, desc = {desc.ToString(),nq}")]
    public struct ELEMDESC
    {
        /// <summary>
        /// Identifies the type of the element.
        /// </summary>
        public TYPEDESC tdesc;

        /// <summary>
        /// Contains information about an element.
        /// </summary>
        public DESCUNION desc;

        /// <summary>
        /// Contains information about an element.
        /// </summary>
        [DebuggerDisplay("idldesc = {idldesc.ToString(),nq}, paramdesc = {paramdesc.ToString(),nq}")]
        [StructLayout(LayoutKind.Explicit)]
        public struct DESCUNION
        {
            /// <summary>
            /// Contains information for remoting the element.
            /// </summary>
            [FieldOffset(0)]
            public IDLDESC idldesc;

            /// <summary>
            /// Contains information about the parameter.
            /// </summary>
            [FieldOffset(0)]
            public PARAMDESC paramdesc;
        }
    }
}
