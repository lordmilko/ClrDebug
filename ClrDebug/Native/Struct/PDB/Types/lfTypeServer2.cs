using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record describing using of a type server with v7 (GUID) signatures
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, sig70 = {sig70.ToString(),nq}, age = {age}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
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
    }
}
