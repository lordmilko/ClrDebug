using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Symbol hash table format<para/>
    /// This structure immediately preceeds the global publics table
    /// and global symbol tables.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct OMFSymHash
    {
        /// <summary>
        /// symbol hash function index
        /// </summary>
        public ushort symhash;

        /// <summary>
        /// address hash function index
        /// </summary>
        public ushort addrhash;

        /// <summary>
        /// length of symbol information
        /// </summary>
        public uint cbSymbol;

        /// <summary>
        /// length of symbol hash data
        /// </summary>
        public uint cbHSym;

        /// <summary>
        /// length of address hashdata
        /// </summary>
        public uint cbHAddr;
    }
}
