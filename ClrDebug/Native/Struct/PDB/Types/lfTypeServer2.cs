using System;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record describing using of a type server with v7 (GUID) signatures
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct lfTypeServer2
    {
        /// <summary>
        /// LF_TYPESERVER2
        /// </summary>
        public LEAF_ENUM_e leaf;

        /// <summary>
        /// guid signature
        /// </summary>
        public Guid sig70;

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
