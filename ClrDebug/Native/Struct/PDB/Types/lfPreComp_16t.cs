using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record describing inclusion of precompiled types
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct lfPreComp_16t
    {
        /// <summary>
        /// LF_PRECOMP_16t
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// starting type index included
        /// </summary>
        public short start;

        /// <summary>
        /// number of types in inclusion
        /// </summary>
        public short count;

        /// <summary>
        /// signature
        /// </summary>
        public int signature;

        /// <summary>
        /// length prefixed name of included type file
        /// </summary>
        public fixed byte name[1];

        public override string ToString()
        {
            //It seems strings are only length prefixed when they're not UTF 8 (pre-v7.0)
            fixed (byte* ptr = name)
                return CreateString(ptr);
        }
    }
}
