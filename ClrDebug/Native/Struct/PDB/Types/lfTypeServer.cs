using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// type record describing using of a type server
    /// </summary>
    [DebuggerDisplay("leaf = {leaf.ToString(),nq}, signature = {signature}, age = {age}, name = {name}")]
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
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
    }
}
