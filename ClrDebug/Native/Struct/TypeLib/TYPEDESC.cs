using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.TypeLib
{
    /// <summary>
    /// Describes the type of a variable, return type of a function, or the type of a function parameter.
    /// </summary>
    [DebuggerDisplay("desc = {desc.ToString(),nq}, vt = {vt.ToString(),nq}")]
    public unsafe struct TYPEDESC
    {
        /// <summary>
        /// If the variable is VT_SAFEARRAY or VT_PTR, the lpValue field contains a pointer to a TYPEDESC that specifies the element type.
        /// </summary>
        public DESCUNION desc;

        /// <summary>
        /// Indicates the variant type for the item described by this TYPEDESC.
        /// </summary>
        public VarEnum vt;
        [DebuggerDisplay("lptdesc = {lptdesc}, lpadesc = {lpadesc}, hreftype = {hreftype}")]
        [StructLayout(LayoutKind.Explicit)]
        public struct DESCUNION
        {
            [FieldOffset(0)]
            public TYPEDESC* lptdesc;

            [FieldOffset(0)]
            public ARRAYDESC* lpadesc;

            [FieldOffset(0)]
            public int hreftype;
        }
    }
}
