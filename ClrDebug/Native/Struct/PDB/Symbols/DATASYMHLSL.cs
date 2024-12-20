using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DATASYMHLSL
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_GDATA_HLSL, S_LDATA_HLSL
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// register type from CV_HLSLREG_e
        /// </summary>
        public short regType; //todo: enum?

        /// <summary>
        /// Base data (cbuffer, groupshared, etc.) slot
        /// </summary>
        public short dataslot;

        /// <summary>
        /// Base data byte offset start
        /// </summary>
        public short dataoff;

        /// <summary>
        /// Texture slot start
        /// </summary>
        public short texslot;

        /// <summary>
        /// Sampler slot start
        /// </summary>
        public short sampslot;

        /// <summary>
        /// UAV slot start
        /// </summary>
        public short uavslot;

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
