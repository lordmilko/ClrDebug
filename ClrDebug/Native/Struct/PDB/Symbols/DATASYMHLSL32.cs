using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 2)]
    public unsafe struct DATASYMHLSL32
    {
        /// <summary>
        /// Record length
        /// </summary>
        public short reclen;

        /// <summary>
        /// S_GDATA_HLSL32, S_LDATA_HLSL32
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// Base data (cbuffer, groupshared, etc.) slot
        /// </summary>
        public int dataslot;

        /// <summary>
        /// Base data byte offset start
        /// </summary>
        public int dataoff;

        /// <summary>
        /// Texture slot start
        /// </summary>
        public int texslot;

        /// <summary>
        /// Sampler slot start
        /// </summary>
        public int sampslot;

        /// <summary>
        /// UAV slot start
        /// </summary>
        public int uavslot;

        /// <summary>
        /// register type from CV_HLSLREG_e
        /// </summary>
        public short regType;

        /// <summary>
        /// name
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
