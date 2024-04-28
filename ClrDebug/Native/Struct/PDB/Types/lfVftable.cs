using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record for a virtual function table
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, type = {type.ToString(),nq}, baseVftable = {baseVftable.ToString(),nq}, offsetInObjectLayout = {offsetInObjectLayout}, len = {len}, Names = {Names}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfVftable
    {
        /// <summary>
        /// LF_VFTABLE
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// class/structure that owns the vftable
        /// </summary>
        public CV_typ_t type;

        /// <summary>
        /// vftable from which this vftable is derived
        /// </summary>
        public CV_typ_t baseVftable;

        /// <summary>
        /// offset of the vfptr to this table, relative to the start of the object layout.
        /// </summary>
        public int offsetInObjectLayout;

        /// <summary>
        /// length of the Names array below in bytes.
        /// </summary>
        public int len;

        /// <summary>
        /// array of names.<para/>
        /// The first is the name of the vtable.
        /// The others are the names of the methods.
        /// </summary>
        public fixed byte Names[1];
    }
}
