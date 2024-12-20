using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record describing using of a type server
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfTypeServer
    {
        /// <summary>
        /// LF_TYPESERVER
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// signature
        /// </summary>
        public int signature;

        /// <summary>
        /// age of database used by this module
        /// </summary>
        public int age;

        /// <summary>
        /// length prefixed name of PDB
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
