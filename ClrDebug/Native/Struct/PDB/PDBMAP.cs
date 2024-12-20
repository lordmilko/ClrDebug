using System.Runtime.InteropServices;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct PDBMAP
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_PDBMAP
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// zero terminated source PDB filename followed by zero
        /// </summary>
        public fixed byte name[1];

        // terminated destination PDB filename, both in wchar_t
    }
}
