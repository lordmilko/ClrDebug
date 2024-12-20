using System.Diagnostics;
using System.Runtime.InteropServices;
using static ClrDebug.Extensions;

namespace ClrDebug.PDB
{
    /// <summary>
    /// // A live range of variable related to a symbol in HLSL code.
    /// </summary>
    [DebuggerDisplay("reclen = {reclen}, rectyp = {rectyp.ToString(),nq}, regType = {regType}, regIndices = {regIndices}, spilledUdtMember = {spilledUdtMember}, memorySpace = {memorySpace}, padding = {padding}, data1 = {data1}, offsetParent = {offsetParent}, sizeInParent = {sizeInParent}, range = {range.ToString(),nq}, data = {data}")]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct DEFRANGESYMHLSL
    {
        /// <summary>
        /// Record length
        /// </summary>
        public ushort reclen;

        /// <summary>
        /// S_DEFRANGE_HLSL or S_DEFRANGE_DPC_PTR_TAG
        /// </summary>
        public SYM_ENUM_e rectyp;

        /// <summary>
        /// register type from CV_HLSLREG_e
        /// </summary>
        public short regType; //todo: enum?

        #region BitField

        /// <summary>
        /// 0, 1 or 2, dimensionality of register space
        /// </summary>
        public short regIndices
        {
            get => GetBits(data1, 0, 2); //0-1
            set => SetBits(ref data1, 0, 2, value);
        }

        /// <summary>
        /// this is a spilled member
        /// </summary>
        public bool spilledUdtMember
        {
            get => GetBitFlag(data1, 2);
            set => SetBitFlag(ref data1, 2, value);
        }

        /// <summary>
        /// memory space
        /// </summary>
        public short memorySpace
        {
            get => GetBits(data1, 3, 4); //3-6
            set => SetBits(ref data1, 3, 4, value);
        }

        /// <summary>
        /// for future use
        /// </summary>
        public short padding
        {
            get => GetBits(data1, 7, 9); //7-15
            set => SetBits(ref data1, 7, 9, value);
        }

        public short data1;

        #endregion

        /// <summary>
        /// Offset in parent variable.
        /// </summary>
        public short offsetParent;

        /// <summary>
        /// Size of enregistered portion
        /// </summary>
        public short sizeInParent;

        /// <summary>
        /// Range of addresses where this program is valid
        /// </summary>
        public CV_LVAR_ADDR_RANGE range;

        /// <summary>
        /// variable length data specifying gaps where the value is not available
        /// </summary>
        public fixed byte data[1];

        // followed by multi-dimensional offset of variable location in register
        // space (see CV_DEFRANGESYMHLSL_* macros below)
    }
}
