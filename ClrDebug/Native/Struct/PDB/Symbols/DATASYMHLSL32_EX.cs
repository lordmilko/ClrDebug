using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DATASYMHLSL32_EX
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_GDATA_HLSL32_EX, S_LDATA_HLSL32_EX
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// Type index
        /// </summary>
        public CV_typ_t typind;

        /// <summary>
        /// Register index
        /// </summary>
        public int regID; //todo: enum?

        /// <summary>
        /// Base data byte offset start
        /// </summary>
        public int dataoff;

        /// <summary>
        /// Binding space
        /// </summary>
        public int bindSpace;

        /// <summary>
        /// Lower bound in binding space
        /// </summary>
        public int bindSlot;

        /// <summary>
        /// register type from CV_HLSLREG_e
        /// </summary>
        public short regType; //todo: enum?

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
