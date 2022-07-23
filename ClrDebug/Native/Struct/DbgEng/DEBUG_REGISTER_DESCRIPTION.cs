using System.Runtime.InteropServices;

namespace ClrDebug.DbgEng
{
    /// <summary>
    /// The DEBUG_REGISTER_DESCRIPTION structure is returned by <see cref="IDebugRegisters.GetDescription"/> to describe a processor's register.
    /// </summary>
    /// <remarks>
    /// If this register is a subregister, the value of the full register can be turned into the value of the sub-register
    /// by first shifting SubregShift bits to the right and then combining the result with SubregMask using the bitwise-AND
    /// operator. The size of the sub-register (SubregLength) is the number of bits set in SubregMask. For general information
    /// about registers, see Registers.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUG_REGISTER_DESCRIPTION
    {
        /// <summary>
        /// The type of value that this register holds. The possible values are the same as for the Type field in the <see cref="DEBUG_VALUE"/> structure.
        /// </summary>
        public DEBUG_VALUE_TYPE Type;

        /// <summary>
        /// A bit field of flags for the register. Currently, the only bit that can be set is DEBUG_REGISTER_SUB_REGISTER, which indicates that this register is a subregister.
        /// </summary>
        public DEBUG_REGISTER Flags;

        /// <summary>
        /// The index of the register of which this register is a sub-register. This field is only used if the DEBUG_REGISTER_SUB_REGISTER bit is set in Flags; otherwise, it is set to zero.
        /// </summary>
        public long SubregMaster;

        /// <summary>
        /// The size, in bits, of this sub-register. This field is only used if the DEBUG_REGISTER_SUB_REGISTER bit is set in Flags; otherwise, it is set to zero.
        /// </summary>
        public long SubregLength;

        /// <summary>
        /// The bit mask that converts the register specified in SubregMaster into this sub-register. This field is only used if the DEBUG_REGISTER_SUB_REGISTER bit is set in Flags; otherwise, it is set to zero.
        /// </summary>
        public long SubregMask;

        /// <summary>
        /// The bit shift that converts the register specified in SubregMaster into this sub-register. This field is only used if the DEBUG_REGISTER_SUB_REGISTER bit is set in Flags; otherwise, it is set to zero.
        /// </summary>
        public long SubregShift;

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public long Reserved0;
    }
}