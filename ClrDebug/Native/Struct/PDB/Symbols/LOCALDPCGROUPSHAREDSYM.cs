using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// Defines a local DPC group shared variable and its location.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct LOCALDPCGROUPSHAREDSYM
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_LOCAL_DPC_GROUPSHARED
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// type index
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// local var flags
        /// </summary>
        public CV_LVARFLAGS flags;

        /// <summary>
        /// Base data (cbuffer, groupshared, etc.) slot
        /// </summary>
        public short dataslot;

        /// <summary>
        /// Base data byte offset start
        /// </summary>
        public short dataoff;

        /// <summary>
        /// Name of this symbol, a null terminated array of UTF8 characters.
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
